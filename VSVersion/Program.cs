using System;
namespace CDos
{
    class Program
    {
        public static bool run = true;
        public static string cmd = null;
        public static string[] files = new string[9]; // Why the heck are arrays in VC# so difficult?!
        public static int file = 0;
        public static int n1;
        public static int n2;
        public static string opr;
        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 40);
            Console.Title = "CDos";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bad Bird Inc. CDos Version 0.2");
            while (run)
            {
                Console.Write("C:/");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "ver":
                        Console.WriteLine("Bad Bird Inc. CDos Version 0.3");
                        break;

                    case "write":
                        Console.WriteLine("File Number (0-9):");
                        file = ToInt(Console.ReadLine());
                        if (file < 10 && file > -1)
                        {
                            Console.WriteLine("Content of file:");
                            files[file] = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid File");
                        }
                        break;

                    case "see":
                        Console.WriteLine("File Number (0-9):");
                        file = ToInt(Console.ReadLine());
                        if (file < 10 && file > -1)
                        {
                            Console.WriteLine(files[file]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid File");
                        }
                        break;

                    case "cls":
                        Console.Clear();
                        break;

                    case "exit":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Are you sure? ALL FILES WILL BE LOST! (Y/N)");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            run = false;
                        }
                        else if (Console.ReadLine().ToUpper() == "N")
                        {
                            //There is nothing to do here.
                        }
                        break;

                    case "calc":
                        Console.WriteLine("First Number:");
                        n1 = ToInt(Console.ReadLine());
                        Console.WriteLine("Second Number:");
                        n2 = ToInt(Console.ReadLine());
                        Console.WriteLine("Operation (+-*/):");
                        opr = Console.ReadLine();
                        if (opr == "+")
                        {
                            Console.WriteLine(n1 + n2);
                        }
                        else if (opr == "-")
                        {
                            Console.WriteLine(n1 - n2);
                        }
                        else if (opr == "*")
                        {
                            Console.WriteLine(n1 * n2);
                        }
                        else if (opr == "/")
                        {
                            if (n2 == 0)
                            {
                                Console.WriteLine("Cannot divide by 0");
                            }
                            else
                            {
                                Console.WriteLine(n1 / n2);
                            }
                        }
                        break;

                    case "help":
                        Console.WriteLine("ver - Prints current version of CDos. Takes no inputs");
                        Console.WriteLine("dir - Prints the file numbers currently in use. Takes no inputs");
                        Console.WriteLine("write - Writes text data to text array. Takes 2 inputs.");
                        Console.WriteLine("see - Prints data from text array. Takes 1 input.");
                        Console.WriteLine("calc - Preforms a calculation. Takes 3 inputs.");
                        Console.WriteLine("note - Plays a square wave through the speakers. Takes 2 inputs.");
                        break;

                    case "note":
                        Console.WriteLine("Frequency (37-32767):");
                        n1 = ToInt(Console.ReadLine());
                        if (n1 <= 32767 && n1 >= 37)
                        {
                            Console.WriteLine("Duration in Milliseconds");
                            n2 = ToInt(Console.ReadLine());
                            Console.Beep(n1, n2);
                        } else
                        {
                            Console.WriteLine("Invalid Frequency");
                        }
                        break;
                    case "dir":
                        for (int i = 0; i < 9; i++)
                        {
                            if (files[i] != null)
                            {
                                Console.WriteLine("File " + i);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
        }
        static int ToInt(string input) // We seriously need this method in the System namespace.
        {
            try
            {
                int n;
                if (int.TryParse(input, out n))
                {
                    return n;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}