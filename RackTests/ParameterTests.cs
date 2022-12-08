using System;
using NUnit.Framework;
using RackParameters;

namespace EngineValve.Tests
{
	[TestFixture]
	public class ParameterUnitTests
	{
		/// <summary>
		/// Объект шаблонного класса для тестов
		/// </summary>
		private Parameter<double> _testParameter
			= new Parameter<double>(ParameterNames.HeightRack, 1300, 1000, 1200);

		[TestCase(999, Description = "Значение максимума меньше минимума")]
		[Test(Description = "Негативный тест на сеттер максимума")]
		public void TestParameterSet_MaxIncorrect(double wrongMax)
		{
			Assert.Throws<Exception>(() => _testParameter.Max = wrongMax,
				"Возникает, если максимальное значение больше минимального");
		}

		[TestCase(900, Description = "Значение меньше допустимого")]
		[TestCase(1400, Description = "Значение больше допустимого")]
		[Test(Description = "Негативный тест на сеттер параметра")]
		public void TestParameterSet_ValueIncorrect(double wrongValue)
		{
			Assert.Throws<Exception>(() => _testParameter.Value = wrongValue,
				"Возникает, если высота вешалки от 1000 до 1300");
		}
	}
}