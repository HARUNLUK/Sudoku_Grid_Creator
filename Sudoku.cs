using System;

namespace Sudoku
{
    class Program
    {
        static byte[,]sdk = new byte[9,9];
        static void prnt()
        {
            Console.WriteLine("      1  2  3  |  4  5  6  |  7  8  9  |");
            Console.WriteLine("----------------------------------------");
            for (byte i = 0; i < 9; i++)
            {
                Console.Write(" "+(i)+" | ");
                for (byte j = 0; j < 9; j++)
                {
                    Console.Write(" " + sdk[i, j] + " ");
                    if (j%3==2)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.Write(" " + (i ) + " | ");
                Console.WriteLine();
                if (i%3==2)
                {
                    Console.WriteLine("----------------------------------------");
                }
                
                
            }
            Console.WriteLine("      1  2  3  |  4  5  6  |  7  8  9  |");
        }
        static bool isFoundInBox(byte number, byte indexY, byte indexX)
        {
            int x=0, y=0;
            switch (indexY)
            {
                case 0:
                case 1:
                case 2:
                    y = 0;
                    break;
                case 3:
                case 4:
                case 5:
                    y = 3;
                    break;
                case 6:
                case 7:
                case 8:
                    y = 6;
                    break;
            }
            switch (indexX)
            {
                case 0:
                case 1:
                case 2:
                    x = 0;
                    break;
                case 3:
                case 4:
                case 5:
                    x = 3;
                    break;
                case 6:
                case 7:
                case 8:
                    x = 6;
                    break;
            }
            int edgeX = x + 3;
            int edgeY = y + 3;
            for (int i = y; i < edgeY; i++)
            {
                for (int j = x; j < edgeX; j++)
                {
                    if (i == indexY && j == indexX)
                    {
                        continue;
                    }
                    else if (number == sdk[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool fill(byte number, byte indexY, byte indexX)
        {
            if (!isFoundInBox(number,indexY,indexX))
            {
                if (!IsFoundInColumn(number,indexX) && !IsFoundInLine(number,indexY))
                {
                    sdk[indexY, indexX] = number;
                    return true;
                }

            }
            return false;
        }
        static bool IsFoundInLine(byte number, byte lineIndex)
        {
            for (byte i=0;i<9;i++)
            {
                 if (sdk[lineIndex , i] == number) 
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsFoundInColumn(byte number ,byte columnIndex)
        {
            for (byte i = 0; i < 9; i++)
            {
                
               if (sdk[i, columnIndex] == number)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            byte x ,y;
            Random rnd = new Random();
            for (byte i = 0; i < 9; i++)
            {
                for (byte j = 0; j < 9; j++)
                {
                    if(fill(Convert.ToByte((rnd.Next(9)+1)), i, j))
                    {
                        j++;
                    }
                }
            }
            prnt();
            while(true)
            {
                fill(Convert.ToByte(Console.ReadLine()), Convert.ToByte(Console.ReadLine()), Convert.ToByte(Console.ReadLine()));
                
            }
            prnt();
        }   
    }
}
