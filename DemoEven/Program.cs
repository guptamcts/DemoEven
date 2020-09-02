using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace DemoEven
{
   public class Program
    {
        int[,] tst = new int[,] { };
        static void Main(string[] args)
        {
            //get input
            string textFile = ConfigurationManager.AppSettings["FileWithPath"];
            
            string str = "";
            if (File.Exists(textFile))
            {
                str = File.ReadAllText(textFile, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("File does not not Exist");
                Console.ReadKey();
            }


            if (!String.IsNullOrEmpty(str.Trim()))
            {
                Program obj = new Program();
                var result= obj.InputCalculation(str);
                Console.WriteLine($"The Maximum Total Sum Of Non-Even Numbers From Top To Bottom Is:  {result[0, 0]}");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Data does not exist in current file");
                Console.ReadKey();
            }

        }

        public int[,] InputCalculation(string str)
        {

            var inputValue = GetInput(str);

            string[] arrayOfRowsByNewlines = inputValue.Split('\n');

            var tableHolder = FlattenTheTriangleIntoTable(arrayOfRowsByNewlines);
            tst= WalkThroughTheNode(arrayOfRowsByNewlines, tableHolder);
            
            return tst;
        }

        private static string GetInput(string input)
        {
            return input;
        }

        private static int[,] WalkThroughTheNode(string[] arrayOfRowsByNewlines, int[,] tableHolder)
        {
            // walking through the non-Even node
            for (int i = arrayOfRowsByNewlines.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < arrayOfRowsByNewlines.Length; j++)
                {
                    //only sum through the non-Even node
                    if ((!IsEven(tableHolder[i, j])))
                    {
                        tableHolder[i, j] = Math.Max(tableHolder[i, j] + tableHolder[i + 1, j],
                            tableHolder[i, j] + tableHolder[i + 1, j + 1]);
                    }
                }
            }
            return tableHolder;
        }

        private static int[,] FlattenTheTriangleIntoTable(string[] arrayOfRowsByNewlines)
        {
            int[,] tableHolder = new int[arrayOfRowsByNewlines.Length, arrayOfRowsByNewlines.Length + 1];

            for (int row = 0; row < arrayOfRowsByNewlines.Length; row++)
            {
                var eachCharactersInRow = arrayOfRowsByNewlines[row].Trim().Split(' ');

                for (int column = 0; column < eachCharactersInRow.Length; column++)
                {
                    int number;
                    int.TryParse(eachCharactersInRow[column], out number);
                    tableHolder[row, column] = number;
                }
            }
            return tableHolder;
        }

        public static bool IsEven(int number)
        {
            // Test whether the parameter is a Even number.
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    return true;
                }
                return false;
            }

            for (int i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }

    }
}