using System;
using System.Collections.Generic;

namespace RackParameters
{
	/// <summary>
	/// Параметры стойки
	/// </summary>
	public class RackParameter
	{
		/// <summary>
		/// Высота стойки
		/// </summary>
		private Parameter<double> _heightRack;

		/// <summary>
		/// Ширина опоры 
		/// </summary>
		private Parameter<double> _widthSupport;

		/// <summary>
		/// Количество крючков
		/// </summary>
		private Parameter<int> _amtHooks;

		/// <summary>
		/// Ширина между крючками
		/// </summary>
		private Parameter<double> _widthHooks;

		/// <summary>
		/// Ширина стойки
		/// </summary>
		private Parameter<double> _widthRack;

		/// <summary>
		/// Длина опоры стойки
		/// </summary>
		private Parameter<double> _lengthSupport;


		/// <summary>
		/// Словарь Название параметра - поле параметра
		/// </summary>
		private Dictionary<ParameterNames, Parameter<double>> _parametersDictionary;

		/// <summary>
		/// Свойство, обрабатывающее словарь ошибок
		/// </summary>
		public Dictionary<ParameterNames, string> ErrorsDictionary { get; } =
			new Dictionary<ParameterNames, string>();

		/// <summary>
		/// Свойство, обрабатывающее поле высоты стойки
		/// </summary>
		public double HeightRack
		{
			get => _heightRack.Value;
			set
			{
				const double MIN_HEIGTH_RACK = 1000;
				const double MAX_HEIGTH_RACK = 1300;
				_heightRack = SetValue(ParameterNames.HeightRack,
					MAX_HEIGTH_RACK, MIN_HEIGTH_RACK, value);
			}
		}

		/// <summary>
		/// Свойство, обрабатывающее поле ширины опоры
		/// </summary>
		public double WidthSupport
		{
			get => _widthSupport.Value;
			set
			{
				const double MIN_WIDTH_SUPPORT = 200;
				const double MAX_WIDTH_SUPPORT = 300;
				_widthSupport = SetValue(ParameterNames.WidthSupport,
					MAX_WIDTH_SUPPORT, MIN_WIDTH_SUPPORT, value);
			}
		}

		/// <summary>
		/// Свойство, обрабатывающее поле количества крючков
		/// </summary>
		public int AmtHooks
		{
			get =>_amtHooks.Value;
			set
			{
				const int MIN_AMT_HOOKS = 2;
				const int MAX_AMT_HOOKS = 7;
				try
				{
					_amtHooks = new Parameter<int>(ParameterNames.AmtHooks,
						MAX_AMT_HOOKS, MIN_AMT_HOOKS, value);
				}
				catch (Exception ex)
				{
					ErrorsDictionary.Add(ParameterNames.AmtHooks, ex.Message);
				}
				
			}
		}

		/// <summary>
		/// Свойство, обрабатывающее поле ширины крючков
		/// </summary>
		public double WidthHooks
		{
			get => _widthHooks.Value;
			set
			{
				const double MIN_WIDTH_HOOKS = 50;
				const double MAX_WIDTH_HOOKS = 100;
				_widthHooks = SetValue(ParameterNames.WidthHooks,
					MAX_WIDTH_HOOKS, MIN_WIDTH_HOOKS, value);
			}
		}

		/// <summary>
		/// Свойство, обрабатывающее поле ширины стойки
		/// </summary>
		public double WidthRack
		{
			get => _widthRack.Value;
			set
			{
				double minWidthRack = DependenciesHelper.GetWidthRackMinValue(AmtHooks, WidthHooks);
				double maxWidthRack = DependenciesHelper.GetWidthRackMaxValue(AmtHooks, WidthHooks);
				_widthRack = SetValue(ParameterNames.WidthRack,
					maxWidthRack, minWidthRack, value);
			}
		}

		/// <summary>
		/// Свойство, обрабатывающее поле длины опоры стойки
		/// </summary>
		public double LengthSupport
		{
			get => _lengthSupport.Value;
			set
			{
				const double MIN_LENGTH_SUPPORT = 400;
				double maxLengthSupport = DependenciesHelper.GetLengthSupportMaxValue(WidthSupport);
				_lengthSupport = SetValue(ParameterNames.LengthSupport,
					maxLengthSupport, MIN_LENGTH_SUPPORT, value);
			}
		}

		/// <summary>
		/// Конструктор со стандартными параметрами
		/// </summary>
		public RackParameter()
		{
			_parametersDictionary =
				new Dictionary<ParameterNames, Parameter<double>>()
				{
					{ParameterNames.HeightRack, _heightRack},
					{ParameterNames.WidthSupport, _widthSupport},
					{ParameterNames.WidthHooks, _widthHooks},
					{ParameterNames.WidthRack, _widthRack},
					{ParameterNames.LengthSupport, _lengthSupport}
				};
			HeightRack = 1000;
			WidthSupport = 200;
			AmtHooks = 2;
			WidthHooks = 50;
			WidthRack = 200;
			LengthSupport = 400;
		}
		
		/// <summary>
		/// Приватный метод инициализирующий
		/// поля параметров
		/// </summary>
		/// <param name="name">Название параметра</param>
		/// <param name="max">Максимальное значение</param>
		/// <param name="min">Минимальное значение</param>
		/// <param name="value">Устанавливаемое значение</param>
		/// <returns>Экземпляр параметров</returns>
		private Parameter<double> SetValue(ParameterNames name, double max, double min, double value)
		{
			try
			{
				return _parametersDictionary[name] =
					new Parameter<double>(name, max, min, value);
			}
			catch (Exception ex)
			{
				ErrorsDictionary.Add(name, ex.Message);
			}

			return _parametersDictionary[name];
		}

	}
}
