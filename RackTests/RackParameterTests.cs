using RackParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RackTests
{
	public class RackParameterUnitTests
	{

		[TestFixture]
		public class RackParametrsTest
		{
			private RackParameter _testRackParameters;

			[TestCase(2, ParameterNames.AmtHooks,
				TestName = "Позитивный - корректное значение количества крючков")]
			[TestCase(1000, ParameterNames.HeightRack,
				TestName = "Позитивный - корректное значение высоты вешалки")]
			[TestCase(200, ParameterNames.WidthRack,
				TestName = "Позитивный - корректное значение ширины вешалки")]
			[TestCase(400, ParameterNames.LengthSupport,
				TestName = "Позитивный - корректное значение длины опор")]
			[TestCase(200, ParameterNames.WidthSupport,
				TestName = "Позитивный - корректное значение ширины опоры")]
			[TestCase(50, ParameterNames.WidthHooks,
				TestName = "Позитивный - корректное значение ширины между крючками")]

			public void TestCorrectParametersValveSet(double value, ParameterNames name)
			{
				_testRackParameters = new RackParameter();
				var propertyInfo = typeof(RackParameter).GetProperty(name.ToString());

				if (name == ParameterNames.AmtHooks)
				{
					propertyInfo.SetValue(_testRackParameters, (int)value);
				}
				else
				{
					propertyInfo.SetValue(_testRackParameters, value);
				}
				var actual = propertyInfo.GetValue(_testRackParameters);

				Assert.AreEqual(actual, value);

			}

			[TestCase(10, ParameterNames.AmtHooks,
				TestName = "Позитивный - количество крючков больше допустимого")]
			[TestCase(1800, ParameterNames.HeightRack,
				TestName = "Позитивный - высота вешалки больше допустимого")]
			[TestCase(1000, ParameterNames.WidthRack,
				TestName = "Позитивный - ширина вешалки больше допустимого")]
			[TestCase(1000, ParameterNames.LengthSupport,
				TestName = "Позитивный - длина опоры больше допустимого")]
			[TestCase(1000, ParameterNames.WidthSupport,
				TestName = "Позитивный - ширина опоры больше допустимого")]
			[TestCase(500, ParameterNames.WidthHooks,
				TestName = "Позитивный - ширина между крючками больше допустимого")]

			[TestCase(1, ParameterNames.AmtHooks,
				TestName = "Позитивный - количество крючков меньше допустимого")]
			[TestCase(180, ParameterNames.HeightRack,
				TestName = "Позитивный - высота вешалки меньше допустимого")]
			[TestCase(100, ParameterNames.WidthRack,
				TestName = "Позитивный - ширина вешалки меньше допустимого")]
			[TestCase(100, ParameterNames.LengthSupport,
				TestName = "Позитивный - длина опоры меньше допустимого")]
			[TestCase(100, ParameterNames.WidthSupport,
				TestName = "Позитивный - ширина опоры меньше допустимого")]
			[TestCase(5, ParameterNames.WidthHooks,
				TestName = "Позитивный - ширина между крючками меньше допустимого")]
			public void TestIncorrectParametersValveSet(double value, ParameterNames name)
			{
				_testRackParameters = new RackParameter();
				var propertyInfo = typeof(RackParameter).GetProperty(name.ToString());

				if (name == ParameterNames.AmtHooks)
				{
					propertyInfo.SetValue(_testRackParameters, (int)value);
				}
				else
				{
					propertyInfo.SetValue(_testRackParameters, value);
				}

				var actual = propertyInfo.GetValue(_testRackParameters);

				Assert.AreNotEqual(actual, value);
			}
		}
	}
}
