using System;
using NUnit.Framework;
using RackParameters;

namespace EngineValve.Tests
{
	[TestFixture]
	public class ParameterUnitTests
	{
		/// <summary>
		/// ������ ���������� ������ ��� ������
		/// </summary>
		private Parameter<double> _testParameter
			= new Parameter<double>(ParameterNames.HeightRack, 1300, 1000, 1200);

		[TestCase(999, Description = "�������� ��������� ������ ��������")]
		[Test(Description = "���������� ���� �� ������ ���������")]
		public void TestParameterSet_MaxIncorrect(double wrongMax)
		{
			Assert.Throws<Exception>(() => _testParameter.Max = wrongMax,
				"���������, ���� ������������ �������� ������ ������������");
		}

		[TestCase(900, Description = "�������� ������ �����������")]
		[TestCase(1400, Description = "�������� ������ �����������")]
		[Test(Description = "���������� ���� �� ������ ���������")]
		public void TestParameterSet_ValueIncorrect(double wrongValue)
		{
			Assert.Throws<Exception>(() => _testParameter.Value = wrongValue,
				"���������, ���� ������ ������� �� 1000 �� 1300");
		}
	}
}