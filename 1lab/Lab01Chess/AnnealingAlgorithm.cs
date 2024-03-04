using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Chess
{
    public class AnnealingAlgorithm
    {
        private int boardSize;
        private int maxIterations;
        private double initialTemperature;
        private double coolingRate;

        public AnnealingAlgorithm(int boardSize, int maxIterations, double initialTemperature, double coolingRate)
        {
            this.boardSize = boardSize;
            this.maxIterations = maxIterations;
            this.initialTemperature = initialTemperature;
            this.coolingRate = coolingRate;
        }

        public int[] RandomSolution()
        {
            Random random = new Random();
            int[] solution = new int[boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                solution[i] = random.Next(boardSize);
            }
            return solution;
        }

        public int Evaluate(int[] solution)
        {
            int conflicts = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = i + 1; j < boardSize; j++)
                {
                    if (solution[i] == solution[j] || Math.Abs(solution[i] - solution[j]) == j - i)
                    {
                        conflicts++;
                    }
                }
            }
            return conflicts;
        }

        public int[] SimulatedAnnealing()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] currentSolution = RandomSolution();
            int currentEnergy = Evaluate(currentSolution);  
            int[] bestSolution = (int[])currentSolution.Clone();
            int bestEnergy = currentEnergy;

            double temperature = initialTemperature;

            Random random = new Random();
            for (int iter = 0; iter < maxIterations; iter++)
            {
                if (bestEnergy == 0)
                {
                    break;
                }

                int[] newSolution = (int[])currentSolution.Clone();
                int index = random.Next(boardSize);
                newSolution[index] = random.Next(boardSize);

                int newEnergy = Evaluate(newSolution);
                int deltaEnergy = newEnergy - currentEnergy;

                if (deltaEnergy < 0 || random.NextDouble() < Math.Exp(-deltaEnergy / temperature))
                {
                    currentSolution = newSolution;
                    currentEnergy = newEnergy;
                }

                if (currentEnergy < bestEnergy)
                {
                    bestSolution = (int[])currentSolution.Clone();
                    bestEnergy = currentEnergy;
                }

                temperature *= coolingRate;
            }
            sw.Stop();
            Console.WriteLine("\nTime taken: {0}ms", sw.Elapsed.TotalMilliseconds);
            
            return bestSolution;
        }
    }
}
