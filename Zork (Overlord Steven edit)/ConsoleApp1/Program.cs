using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Area a = new Area("Silent Hills", "It seems like a place you don't wanna be..");
            Area b = new Area("Misty fields", "Mist enshrouds the fields..");
            Area c = new Area("Town Center", "All empty but something eerie fills the place..");
            Area d = new Area("Town Church", "What should have been holy, is now damned..");

            a.AddArea(c, Directions.West);
            c.AddArea(a, Directions.East);
            c.AddArea(d, Directions.West);
            d.AddArea(c, Directions.East);
            a.AddArea(b, Directions.North);
            b.AddArea(a, Directions.South);

            Area currentArea = a;
            
            //Start of intro
            Console.Write("Welcome to the Silent Hills");

            int dots = 3;

            for (int i = 0; i < dots; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You don't want to enter, but you cannot go back from whence you came");

            for (int j = 0; j < dots; j++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(1000);  
           


            while (true)
            {
                //read input
                string command = Console.ReadLine();
                //splits the string and removes the empty space
                string[] inputs = command.Split(' ');

                //Takes the first word of the

                switch (inputs[0])
                {
                    case "go":
                    case "Go":
                    case "gO":
                    case "GO":
                        switch (inputs[1])
                        {
                            case "east":
                                GoToDirection(Directions.East, ref currentArea);
                                Console.WriteLine("You are now in " + currentArea.name);
                                System.Threading.Thread.Sleep(3000);
                                Console.WriteLine(currentArea.description);
                                Console.WriteLine();
                                if (currentArea.neighbors.ContainsKey(Directions.East))
                                    Console.WriteLine("Your path is blocked by something...");
                                break;
                            case "west":
                                GoToDirection(Directions.West, ref currentArea);
                                Console.WriteLine("You are now in " + currentArea.name);
                                System.Threading.Thread.Sleep(3000);
                                Console.WriteLine(currentArea.description);
                                Console.WriteLine();
                                if (currentArea.neighbors.ContainsKey(Directions.West))
                                    currentArea = a.neighbors[Directions.West];
                                else Console.WriteLine("There's nothing there");
                                break;
                            case "south":
                                GoToDirection(Directions.South, ref currentArea);
                                Console.WriteLine("You are now in " + currentArea.name);
                                System.Threading.Thread.Sleep(3000);
                                Console.WriteLine(currentArea.description);
                                Console.WriteLine();
                                if (currentArea.neighbors.ContainsKey(Directions.West))
                                    currentArea = a.neighbors[Directions.South];
                                else Console.WriteLine("You cannot go there..");
                                break;
                            case "north":
                                GoToDirection(Directions.North, ref currentArea);
                                Console.WriteLine("You are now in " + currentArea.name);
                                System.Threading.Thread.Sleep(3000);
                                Console.WriteLine(currentArea.description);
                                Console.WriteLine();
                                if (currentArea.neighbors.ContainsKey(Directions.North))
                                    currentArea = a.neighbors[Directions.North];
                                else Console.WriteLine("Nope, not today my friend");
                                break;
                            
                        }
                        break;


                    default:
                        Console.WriteLine("You are currently in " + currentArea.name);
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    case "examine":
                        //The examine "function"
                        Console.WriteLine(currentArea.description);
                        Console.WriteLine();

                        foreach (Directions dir in currentArea.neighbors.Keys)
                        {
                            Console.WriteLine("To the " + dir.ToString().ToLower() + "there is a " + currentArea.neighbors[dir].name);
                        }

                        break;
                }
            }
        }

        public static void GoToDirection(Directions dir, ref Area currentArea)
        {
            if (currentArea.neighbors.ContainsKey(dir))
                currentArea = currentArea.neighbors[dir];
            else Console.WriteLine("There's nothing there..");
        }
    }
}
