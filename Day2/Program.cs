using System;
using System.Collections.Generic;

namespace Day2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter day 2 input:");

			string[] input = Console.ReadLine().Split(",");
			List<int> memory = PopulateMemory(input);

			memory = RunProgram(memory);

			Console.WriteLine("Part one output is: " + memory[0]);

			memory = PopulateMemory(input);

			void BruteForce()
			{
				for (int i = 0; i < 100; i++)
				{
					for (int j = 0; j < 100; j++)
					{
						List<int> possibleMemory = new List<int>();
						possibleMemory.AddRange(memory);
						possibleMemory[1] = i;
						possibleMemory[2] = j;

						possibleMemory = RunProgram(possibleMemory);

						if (possibleMemory[0] == 19690720)
						{
							memory = possibleMemory;
							return;
						}
					}
				}
			}

			BruteForce();

			Console.WriteLine("Part two output is: " + (100 * memory[1] + memory[2]));
		}

		private static List<int> PopulateMemory(string[] input)
		{
			List<int> memory = new List<int>();

			foreach (string number in input)
			{
				memory.Add(Convert.ToInt32(number));
			}

			return memory;
		}

		private static List<int> RunProgram(List<int> memory)
		{
			for (int i = 0; i < memory.Count; i +=4)
			{
				if (memory[i] == 99)
				{
					break;
				}

				int noun = memory[memory[i + 1]];
				int verb = memory[memory[i + 2]];
				int outputIndex = memory[i + 3];

				if (memory[i] == 1)
				{
					if (outputIndex < memory.Count)
						memory[outputIndex] = noun + verb;
				}

				else if (memory[i] == 2)
				{
					if (outputIndex < memory.Count)
						memory[outputIndex] = noun * verb;
				}
			}

			return memory;
		}
	}
}
