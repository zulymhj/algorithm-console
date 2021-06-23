using System;

namespace algorithm_console
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine($"Hello, create a matrix M x N, have it do rotate to 90 grade. After it have order the elements, Each stone falls down until it lands on an obstacle, another stone, or the bottom of the box.");
            Console.WriteLine($"Please, input number rows");
            var boxLenM = Console.ReadLine();
            int m,n = 0;

            if (boxLenM != null)
            {
                m = Int32.Parse(boxLenM);
                Console.WriteLine($"Please, input number columns");
                var boxLenN = Console.ReadLine();

                if (boxLenN != null)
                {
                    n = Int32.Parse(boxLenN);
                    char[,] boxMatrix = new char[m, n];

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.WriteLine($"Input character at position [{i}][{j}] ( # . *)");
                            var valColumn = Console.ReadLine();
                            boxMatrix[i, j] = Convert.ToChar(valColumn);
                        }
                    }
                    Console.WriteLine("\t");
                    Console.WriteLine("****  PRINT MATRIX GENERATED  ****");
                    printBox(boxMatrix);
                    Console.WriteLine("\t");
                    char[,] boxMatrix_change = changeValue(boxMatrix);
                    char[,] boxMatrix_rotate = rotateBox(boxMatrix);
                    Console.WriteLine("++++  PRINT MATRIX CHANGED  ++++");
                    printBox(boxMatrix_rotate);
                }
            }
            else
            {
                Console.WriteLine("Insert value correct");
            }
        }

        public static char[,] changeValue(char[,] box)
        {
            int m = box.GetLength(0), n = box.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                int lastIndex = -1;
                for (int j = n - 1; j >= 0; j--)
                    if (lastIndex == -1 && box[i, j] == '.')
                        lastIndex = j;
                    else if (box[i, j] == '#' && lastIndex != -1)
                    {
                        box[i, j] = '.';
                        box[i, lastIndex--] = '#';
                    }
                    else if (box[i, j] == '*')
                        lastIndex = -1;
            }

            return box;
        }
        public static char[,] rotateBox(char[,] box)
        {
            int m = box.GetLength(0);
            int n = box.GetLength(1);
            char[,] newArray = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newArray[i, j] = box[m - j - 1, i];
                }
            }
            return newArray;
        }
        private static void printBox(char[,] box)
        {
            int rows_ = box.GetLength(0);
            int cols_ = box.GetLength(1);
            Console.WriteLine("==============================================");
            for (int i = 0; i < rows_; i++)
            {
                for (int j = 0; j < cols_; j++)
                {
                    Console.Write(box[i, j] + "\t");
                }
                Console.WriteLine("\t");
            }
            Console.WriteLine("\t");
            Console.WriteLine("\t");
        }


    }
}
