using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.Lab4.RomanNumeralConverter;
using GameJukeBox.Lab4.BinaryIntegerConverter;
using GameJukeBox.Lab4.PascalTriangle;
using GameJukeBox.Lab4.QueenTakesKing;
using GameJukeBox.Lab4.WriteOutNumber;
using GameJukeBox.Lab5.FractionCalculator;
using GameJukeBox.Lab5.MortgageCalculator;
using GameJukeBox.Lab6;
using GameJukeBox.Lab7.MazePathfinder;
using GameJukeBox.RPGInventory;

namespace GameJukeBox
{
    public class JukeBoxWorkFlow
    {
        public void Execute()
        {
            Console.WriteLine("Project Jukebox.");
            Console.WriteLine("Enter the number of your choice:");
            Console.WriteLine("1. Challenge Labs Menu.");
            Console.WriteLine("2. Game Menu.");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    LabMenu();
                    break;
                case "2":
                    GameMenu();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void LabMenu()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Lab 4 project.");
            Console.WriteLine("2. Lab 5 Project.");
            Console.WriteLine("3. Lab 6 Project.");
            Console.WriteLine("4. Lab 7 Project.");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    Lab4Menu();
                    break;
                case "2":
                case "5":
                    Lab5Menu();
                    break;
                case "3":
                case "6":
                    Lab6Menu();
                    break;
                case "4":
                case "7":
                    Lab7Menu();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void Lab7Menu()
        {
            Console.WriteLine("Enter your choice.");
            Console.WriteLine("1. Maze Pathfinder.");
            Console.WriteLine("");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    MazePathfinderPicker c = new MazePathfinderPicker();
                    c.Execute();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void Lab6Menu()
        {
            Console.WriteLine("Enter your choice.");
            Console.WriteLine("1. Credit Card Validator.");
            Console.WriteLine("");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    CreditCardValidatorPicker c = new CreditCardValidatorPicker();
                    c.Execute();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void Lab5Menu()
        {
            Console.WriteLine("Enter your choice.");
            Console.WriteLine("1. Mortgage Calculator.");
            Console.WriteLine("2. Fractions Calculator.");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    MortgageCalculatorPicker m = new MortgageCalculatorPicker();
                    StartLab(m);
                    break;
                case "2":
                    FractionCalculatorPicker f = new FractionCalculatorPicker();
                    StartLab(f);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void Lab4Menu()
        {
            Console.WriteLine("Enter your choice.");
            Console.WriteLine("1. Binary Integer Converter.");
            Console.WriteLine("2. Roman Numeral Converter.");
            Console.WriteLine("3. Pascal Triangle.");
            Console.WriteLine("4. Queen Takes King.");
            Console.WriteLine("5. Write Out A Number.");

            string Choice = Console.ReadLine();

            switch (Choice)
            {             
                case "1":
                    BinaryIntegerConverterPicker b = new BinaryIntegerConverterPicker();
                    StartLab(b);
                    break;
                case "2":
                    RomanNumeralConverterPicker r = new RomanNumeralConverterPicker();
                    StartLab(r);
                    break;
                case "3":
                    PascalTrianglePicker p = new PascalTrianglePicker();
                    StartLab(p);
                    break;
                case "4":
                    QueenTakesKingPicker q = new QueenTakesKingPicker();
                    StartLab(q);
                    break;
                case "5":
                    WriteOutNumberPicker w = new WriteOutNumberPicker();
                    StartLab(w);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    

        static private void GameMenu()
        { 
            Console.WriteLine("1. Rock Paper Scissor.");
            Console.WriteLine("2. Tic Tac Toe.");
            Console.WriteLine("3. RPG Inventory.");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    RockPapaerScissorPicker r = new RockPapaerScissorPicker();
                    StartGame(r);
                    break;
                case "2":
                    TicTacToePicker t = new TicTacToePicker();
                    StartGame(t);
                    break;
                case "3":
                    RPGInventoryPicker rpg = new RPGInventoryPicker();
                    StartGame(rpg);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        static private void StartGame(IGameSelector gameSelector)
        {
            gameSelector.Execute();
        }

        static private void StartLab(ILabSelector labSelector)
        {
            labSelector.Execute();
        }

    }

    

}
