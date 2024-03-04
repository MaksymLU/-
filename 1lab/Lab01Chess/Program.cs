using System;
using System.Collections.Generic;


namespace Lab01Chess
{

    class Program
    {
        static void Main(string[] args)
        {
            // Параметри алгоритму
            int boardSize = 8;
            int maxIterations = 10000;
            double initialTemperature = 1000;
            double coolingRate = 0.95;

            // Виведення початкового стану дошки з рандомно розставленими ферзями
            Console.WriteLine("Початковий стан дошки з рандомно розставленими ферзями:");
            Board initialBoard = new Board(boardSize);
            int[] initialSolution = new AnnealingAlgorithm(boardSize, maxIterations, initialTemperature, coolingRate).RandomSolution();
            for (int i = 0; i < boardSize; i++)
            {
                Queen queen = new Queen(i, initialSolution[i]);
                initialBoard.AddQueen(queen);
            }
            initialBoard.PrintBoard();

            // Виконання алгоритму
            AnnealingAlgorithm simulatedAnnealingMethod = new AnnealingAlgorithm(boardSize, maxIterations, initialTemperature, coolingRate);
            int[] solution = simulatedAnnealingMethod.SimulatedAnnealing();

            // Виведення результату
            Console.WriteLine("Шахова дошка з розмiщеними ферзями:");
            Board board = new Board(boardSize);
            for (int i = 0; i < boardSize; i++)
            {
                Queen queen = new Queen(i, solution[i]);
                board.AddQueen(queen);
            }
            board.PrintBoard();
        }
    }
}