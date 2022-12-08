using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackParameters
{
	public static class DependenciesHelper
	{	
		public static double GetWidthRackMaxValue(int amtHooks, double widthHooks)
		{
			return amtHooks * widthHooks + 150;
		}
		public static double GetWidthRackMinValue(int amtHooks, double widthHooks)
		{
			return amtHooks * widthHooks + 100;
		}

		public static double GetLengthSupportMaxValue(double widthSupport)
		{
			return widthSupport + 250;
		}
	}
}
