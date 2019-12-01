using System;
using System.Collections.Generic;

namespace Day1
{
	class Program
	{
		static void Main(string[] args)
		{
			bool readLines = true;
			List<int> inputs = new List<int>();
			int totalFuel = 0;

			Console.WriteLine("Enter day 1 input:");

			while (readLines)
			{
				string input = Console.ReadLine();

				if (input.Equals(""))
					readLines = false;
				else
					inputs.Add(Convert.ToInt32(input));
			}

			foreach (int moduleWeight in inputs)
			{
				int baseModuleFuel = CalculateFuel(moduleWeight);
				int fuelForFuelWeight = 0;
				int remainingFuelToCalculate = baseModuleFuel;

				while (remainingFuelToCalculate > 0)
				{
					fuelForFuelWeight += CalculateFuel(remainingFuelToCalculate);
					remainingFuelToCalculate = CalculateFuel(remainingFuelToCalculate);
				}

				totalFuel += baseModuleFuel + fuelForFuelWeight;
			}

			Console.WriteLine("The total fuel required for all modules including fuel weight is: " + totalFuel);
		}

		private static int CalculateFuel(int weight)
		{
			int fuel = weight;
			fuel /= 3;
			fuel -= 2;

			if (fuel < 0)
				fuel = 0;

			return fuel;
		}
	}
}
