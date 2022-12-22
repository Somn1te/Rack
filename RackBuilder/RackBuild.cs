using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using RackParameters;

namespace RackBuilder
{
	public class RackBuild
	{
		/// <summary>
		/// Экземпляр класса параметров
		/// </summary>
		private RackParameter _parameters;

		/// <summary>
		/// Экземпляр компонента сборки
		/// </summary>
		private ksPart _part;

		/// <summary>
		/// Соединение с КОМПАС-3D
		/// </summary>
		private KompasConnector _kompas = new KompasConnector();

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="parameters"></param>
		public RackBuild(RackParameter parameters)
		{
			_kompas.Start();
			var document3D = _kompas.CreateDocument3D();
			_part = document3D.GetPart((short)Part_Type.pTop_Part);
			_parameters = parameters;
		}

		public void Build()
		{
			CreatePathLeg();
			CreateCrossbar();
			CreateHooks();
			CreateSupport();
			CreateStand();
		}

		/// <summary>
		/// Метод постройки ножек
		/// </summary>
		private void CreatePathLeg()
		{
			//Создание траектории
			//создает плосткость
			ksEntity planeYOZ =
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_planeYOZ);
			ksEntity track = CreateSketch(planeYOZ, out var trackDefinition);
			
			//редактирование эскиза 
			ksDocument2D document2D = trackDefinition.BeginEdit();
			double diameterLeg = 50;
			double lengthLeg = _parameters.LengthSupport;
			var rectangle = CreateRectangle(document2D, diameterLeg,
				lengthLeg, -diameterLeg, 0);
			TrimCurve(document2D, rectangle, 0, 0,
				0, lengthLeg, lengthLeg/2, -diameterLeg);
			trackDefinition.EndEdit();
			//Создание сечения
			ksEntity planeXOY =
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_planeXOY);
			ksEntity sketch = CreateSketch(planeXOY, out var sketchDefinition);

			document2D = sketchDefinition.BeginEdit();
			CreateCircle(document2D, diameterLeg, _parameters.WidthRack/2, 0);
			CreateCircle(document2D, diameterLeg, -_parameters.WidthRack/2, 0);

			sketchDefinition.EndEdit();
			//Построение по траектории
			CreateEvolution(sketch, track);
		}
		
		/// <summary>
		/// Метод постройки перекладины
		/// </summary>
		private void CreateCrossbar()
		{
			//Строим сечение
			
			var offset = 50;
			var plane = ksObj3dTypeEnum.o3d_planeXOY;
			ksEntity planeOffset = CreateOffsetPlane(offset, plane);
			ksEntity sketch = CreateSketch(planeOffset, out var sketchDefinition);
			
			ksDocument2D document2D = sketchDefinition.BeginEdit();

			var xCenter = _parameters.WidthRack / 2;
			var yCenter = -(_parameters.LengthSupport / 2 );
			CreateCircle(document2D,25, xCenter, yCenter);
			sketchDefinition.EndEdit();

			ksEntity planeXOZ =
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_planeXOZ);
			ksEntity track = CreateSketch(planeXOZ, out var trackDefinition);
			
			document2D = trackDefinition.BeginEdit();
			double diameterLeg = 50;
			var rectangle = CreateRectangle(document2D, _parameters.WidthRack,
				-_parameters.HeightRack, -_parameters.WidthRack/2, -diameterLeg);
			TrimCurve(document2D, rectangle, -_parameters.WidthRack/2, diameterLeg,
				_parameters.WidthRack/2, diameterLeg, 0, -_parameters.HeightRack);
			trackDefinition.EndEdit();

			CreateEvolution(sketch, track);
		}

		/// <summary>
		/// Метод постройки крючков
		/// </summary>
		private void CreateHooks()
		{
			var yCenter = -(_parameters.LengthSupport / 2);
			double edgeDistance = _parameters.WidthHooks;
			double offsetX = -_parameters.HeightRack - 50;
			double xCenter = 0;
			double offsetY = (_parameters.LengthSupport / 2) - 50;

			ksEntity planeYOZ =
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_planeYOZ);
			ksEntity track = CreateSketch(planeYOZ, out var trackDefinition);

			//редактирование эскиза 
			ksDocument2D document2D = trackDefinition.BeginEdit();

			var rectangle = CreateRectangle(document2D, 50,
				50, offsetX, offsetY);
			TrimCurve(document2D, rectangle, offsetX, offsetY,
				offsetX, offsetY+50, offsetX+10, offsetY);
			trackDefinition.EndEdit();

			var planeXOY = ksObj3dTypeEnum.o3d_planeXOY;

			ksEntity planeOffset = CreateOffsetPlane(-offsetX, planeXOY);

			ksEntity sketch = CreateSketch(planeOffset, out var sketchDefinition);

			document2D = sketchDefinition.BeginEdit();

			for (var hookIndex = 0; hookIndex < _parameters.AmtHooks; hookIndex++)
			{
				
				if (hookIndex % 2 == 0)
				{
					CreateCircle(document2D, 15, xCenter, yCenter);
				}
				else
				{
					xCenter += edgeDistance;
					CreateCircle(document2D, 15, -xCenter, yCenter);
				}
			}

			sketchDefinition.EndEdit();

			CreateEvolution(sketch, track);
		}

		/// <summary>
		/// Метод постройки опор 
		/// </summary>
		private void CreateSupport()
		{
			var offset = -_parameters.WidthRack / 2;
			var plane = ksObj3dTypeEnum.o3d_planeYOZ;
			ksEntity planeOffset = CreateOffsetPlane(offset, plane);
			ksEntity sketch = CreateSketch(planeOffset, out var sketchDefinition);
			
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var yCenter = _parameters.LengthSupport - 
				((_parameters.LengthSupport - _parameters.WidthSupport) / 2) ;
			double xCenter = -75;
			CreateCircle(document2D, 30, xCenter,yCenter);
			yCenter -= _parameters.WidthSupport;
			CreateCircle(document2D,30,xCenter,yCenter);
			sketchDefinition.EndEdit();
			CreateExtrusion(_parameters.WidthRack, sketch);
		}

		/// <summary>
		/// Метод постройки подставки для обуви 
		/// </summary>
		private void CreateStand()
		{
			var offset = -(_parameters.LengthSupport - 
				((_parameters.LengthSupport - _parameters.WidthSupport) / 2));
			var plane = ksObj3dTypeEnum.o3d_planeXOZ;
			var yCenter = -75;
			var xCenter = _parameters.LengthStand/2;
			var amtStadndСrossbar = (int)(_parameters.LengthStand / 25);
			var widthStandCrossbar = _parameters.LengthStand / amtStadndСrossbar;
			ksEntity planeOffset = CreateOffsetPlane(offset, plane);
			ksEntity sketch = CreateSketch(planeOffset, out var sketchDefinition);

			ksDocument2D document2D = sketchDefinition.BeginEdit();

			for (var standCrossbarIndex = 0; standCrossbarIndex <= amtStadndСrossbar; standCrossbarIndex++)
			{
				CreateCircle(document2D, 10, xCenter, yCenter);
				xCenter = xCenter - widthStandCrossbar;
			}
			
			sketchDefinition.EndEdit();
			CreateExtrusion(_parameters.WidthSupport, sketch);
		}

		/// <summary>
		/// Метод создания эскиза
		/// </summary>
		/// <param name="plane">Плоскость</param>
		/// <param name="sketchDefinition">Параметры эскиза</param>
		/// <returns>Указатель на эскиз</returns>
		private ksEntity CreateSketch(ksEntity plane, out ksSketchDefinition sketchDefinition)
		{
			ksEntity sketch = _part.NewEntity((short)ksObj3dTypeEnum.o3d_sketch);
			sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();
			return sketch;
		}

		/// <summary>
		/// Метод создания смещённой плоскости
		/// </summary>
		/// <param name="offset">расстояние смещения</param>
		/// <param name="plane">базовая плоскость</param>
		/// <returns>Указатель на смещённую плоскость</returns>
		private ksEntity CreateOffsetPlane(double offset, ksObj3dTypeEnum plane)
		{
			ksEntity defaultPlane =
				_part.GetDefaultEntity((short)plane);
			ksEntity planeOffset =
				_part.NewEntity((short)ksObj3dTypeEnum.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();

			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = offset;

			planeOffsetDefinition.SetPlane(defaultPlane);

			planeOffset.Create();
			return planeOffset;
		}

		/// <summary>
		/// Метод постройки квадрата
		/// </summary>
		/// <param name="document2D">Интерфейс графического документа</param>
		/// <param name="width">Ширина квадрата</param>
		/// <param name="height">Высота квадрата</param>
		/// <param name="x">X начальной точки</param>
		/// <param name="y">Y начальной точки</param>
		/// <returns>Указатель на созданный прямоугольник</returns>
		private int CreateRectangle(ksDocument2D document2D, double width, 
			double height, double x, double y)
		{
			KompasObject kompas = _kompas.KompasEntity;
			ksRectangleParam param =
				kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
			param.x = x;
			param.y = y;
			param.height = height;
			param.width = width;
			param.style = (short)ksCurveStyleEnum.ksCSNormal;
			return document2D.ksRectangle(param, 0);
		}

		/// <summary>
		/// Метод постройки окружности
		/// </summary>
		/// <param name="document2D">Интерфейс графического документа</param>
		/// <param name="diameter">Диаметр окружности</param>
		private void CreateCircle(ksDocument2D document2D, double diameter, 
			double xCenter, double yCenter)
		{
			document2D.ksCircle(xCenter, yCenter, diameter / 2,
				(short)ksCurveStyleEnum.ksCSNormal);
		}

		/// <summary>
		/// Усечь кривую, оставив часть между точками
		/// </summary>
		/// <param name="document2D">Интерфес графического документа</param>
		/// <param name="curve">Усекаемая кривая</param>
		/// <param name="xBegin">Координата X начала</param>
		/// <param name="yBegin">Координата Y начала</param>
		/// <param name="xEnd">Координата X конца</param>
		/// <param name="yEnd">Координата Y конца</param>
		/// <param name="xOn">Координата X точки лежащей на кривой</param>
		/// <param name="yOn">Координата Y точки лежащей на кривой</param>
		private void TrimCurve(ksDocument2D document2D, int curve, 
			double xBegin, double yBegin, double xEnd, double yEnd, double xOn, double yOn)
		{
			document2D.ksTrimmCurve(curve, xBegin, yBegin,
				xEnd, yEnd, xOn, yOn,
				(short)ViewMode.vm_HiddenRemoved);
		}

		/// <summary>
		/// Создать элемент по траектории
		/// </summary>
		/// <param name="section">сечение</param>
		/// <param name="track">траектория</param>
		private void CreateEvolution(ksEntity section, ksEntity track)
		{
			ksEntity evolution = _part.NewEntity((short) ksObj3dTypeEnum.o3d_bossEvolution);
			ksBossEvolutionDefinition evolutionDefinition = evolution.GetDefinition();
			evolutionDefinition.SetSketch(section);
			ksEntityCollection trackArray = evolutionDefinition.PathPartArray();
			trackArray.Add(track);
			evolution.Update();
		}

		/// <summary>
		/// Метод выдавливания
		/// </summary>
		/// <param name="length">Длина выдавливания</param>
		/// <param name="sketch">Эскиз выдавливания</param>
		private void CreateExtrusion(double length, ksEntity sketch)
		{
			ksEntity extrusion =
				_part.NewEntity((short)ksObj3dTypeEnum.o3d_baseExtrusion);
			ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

			extrusionDefinition.SetSideParam(true,
				(short)ksEndTypeEnum.etBlind, length);
			extrusionDefinition.SetSketch(sketch);
			extrusion.Create();
		}
	}
}
