using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int lastColume = 3;  //can be changed later
            int rowCount = 3;

            Bomb[,] array = new Bomb[lastColume, rowCount];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                // if you put 0 it is possible for you to get no bombs which means you have automaticaly won
                int rand_num = rd.Next(1, 3);
                array[i,rand_num] = new Bomb(true);
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    int count = 0;
                    if (array[i, j] != null) { continue; }
                    if (j-1 >=0 &&array[i, j-1] != null  && array[i, j - 1].IsBomb) { count++; }
                    if (j+1 < rowCount&&array[i, j + 1] != null && array[i, j + 1].IsBomb) { count++; }


                    if (i-1 >= 0 &&j- 1 >=0&&array[i-1, j - 1] != null && array[i-1, j - 1].IsBomb) { count++; }
                    if(i - 1 >= 0 && array[i-1, j] != null && array[i-1, j].IsBomb) { count++; }
                    if (i-1 >= 0&&j+1< rowCount && array[i-1, j+1] != null && array[i - 1, j + 1].IsBomb) { count++; }

                   
                    if (i+1 < rowCount&& j-1 >=0&&array[i+1, j - 1] != null && array[i + 1, j - 1].IsBomb) { count++; }
                    if(i + 1 < rowCount && array[i+1, j] != null && array[i+1, j].IsBomb) { count++; }
                    if (i + 1 < rowCount && j + 1 < rowCount && array[i+1, j + 1] != null && array[i + 1, j + 1].IsBomb) { count++; }

                    array[i, j] = new Bomb(count);
                    
                }
                  
            }


            while (true)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if(i == 0)
                    {
                        Console.Write("  ");
                    }
                    Console.Write($" {i + 1}");
                }

                Console.WriteLine();
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(col + 1 + ". ");
                    for (int row = 0; row < array.GetLength(0); row++)
                    {
                       
                        if (array[col, row].IsSelected)
                        {
                            if (array[col, row].IsBomb)
                            {
                                Console.Write("* ");
                            }
                            else
                            {
                                Console.Write(array[col, row].Count + " ");
                            }
                        }
                        else
                        {
                            Console.Write("X ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("==============================================================");
                Console.WriteLine();

                Console.Write("What colume do you want to select: ");
                int columeInp = int.Parse(Console.ReadLine());
                Console.Write("What row do you want to select: ");
                int rowInp = int.Parse(Console.ReadLine());

                if(rowInp > rowCount || columeInp > lastColume)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("---------------------------------");
                    continue;
                }

                columeInp = columeInp - 1;
                rowInp = rowInp - 1;



                Bomb selection = array[columeInp, rowInp];
                if(selection.IsSelected == true)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("This spot is already selected");
                    Console.WriteLine("---------------------------------");

                }
                else
                {
                     selection.IsSelected = true;
                }
                if (selection.IsBomb)
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine("GAME OVER!!");
                    Console.WriteLine("**********************");

                    break;
                }
                bool isWinner = true;

                for (int col = 0; col < array.GetLength(1); col++)
                {
                    for (int row = 0; row < array.GetLength(0); row++)
                    {
                        if(!array[col,row].IsSelected && array[col, row].IsBomb)
                        {
                            break;
                        }
                        if(!array[col,row].IsSelected)
                        {
                            isWinner = false;
                            break;
                        }
                         if(array[col,row].IsSelected && array[col, row].IsBomb)
                        {
                            isWinner = false;
                            break;
                        }
                    }
                }
                if (isWinner == true)
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                    Console.WriteLine("$                            $");
                    Console.WriteLine("$ Congratulations you win!!! $");
                    Console.WriteLine("$                            $");

                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    break;

                }

            }


        }
    }
}
