using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulatorApp.Inputs
{
    public static class InputHandler
    {
        private static void Greeting()
        {
            
        }

        public static string[,] GetSimulatorField()
        {
            Console.WriteLine("Welcome to Auto Driving car Simulator");
            while (true)
                try
                {
                    Console.WriteLine("Please enter the width and height of thr simulagtion field in x y format:");
                    string input = Console.ReadLine();
                    var xy = input.Split(" ");
                    int[] numbers = Array.ConvertAll(xy, int.Parse);
                    int width = numbers[0];
                    int height = numbers[1];
                    return new string[width, height];
                }
                catch (Exception)
                {

                }
        }
            

        public static void GetCar(out string name, out int X, out int Y, out string direction)
        {
            Console.WriteLine("Please enter the name of the car:");
            name = Console.ReadLine();

            while(true)
            try
            {
                Console.WriteLine($"Please enter the initial position of car {name} in x y direction format:");
                string[] directions = Console.ReadLine().Split(" ");
                X = Int32.Parse(directions[0]);
                Y = Int32.Parse(directions[1]);
                direction = directions[2]; //Add validation here if needed
                break;
            }
            catch(Exception)
            {

            }
            
        }

        public static string GetNextStep()
        {
            while(true)
            {
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("[1] Start Over");
                Console.WriteLine("[2] Exit");
                string step = Console.ReadLine();
                switch (step)
                {
                    case "1":
                    case "2":
                        return step;
                    default:
                        break;
                }
            }           
        }
    }
}