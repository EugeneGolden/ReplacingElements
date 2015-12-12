using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayOfSum
{
    class Program
    {
        //Поменять местами в двумерном массиве противоположные элементы(например 5.7 и -5.7), с учетов перестановки элемента только один раз

        static void Main(string[] args)
        {
            Console.Write("Введите количество строк массива: ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов массива: ");
            int rows = int.Parse(Console.ReadLine());
            float[,] array = new float[lines, rows];
            HashSet<float> processedElements = new HashSet<float>();

            //Введите элементы массива
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write("Enter array[" + i + "],[" + j + "] : ");
                    float element = float.Parse(Console.ReadLine());
                    array[i, j] = element;
                    Console.WriteLine("array[" + i + "],[" + j + "] is " + array[i, j]);
                }
            }

            //При решении задачи предусмотреть вывод массива в виде таблицы (каждую строку таблицы отделять при выводе на экран переводом на новую строку

            Console.WriteLine("Введенный двумерный массив: ");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (j < (rows - 1))
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(array[i, j]);
                        Console.WriteLine();
                    }
                }
            }

            //Возьмем элемент двумерного массива
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (!processedElements.Contains(array[i, j]))
                    {
                        //Сравним данный элемент со всеми элементами этого же массива.
                        //Отсчет строк начнем с той строки, на которой находится взятый нами элемент
                        for (int k = i; k < lines; k++)
                        {
                            for (int l = 0; l < rows; l++)
                            {
                                if (array[i, j] == -array[k, l])
                                {
                                    float mediator = array[i, j];
                                    array[i, j] = array[k, l];
                                    array[k, l] = mediator;
                                    processedElements.Add(array[i, j]);
                                    processedElements.Add(array[k, l]);
                                }
                            }
                        }
                    }
                }
            }

            //Результирующий массив выглядит следующим образом
            Console.WriteLine("Полученный двумерный массив: ");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (j < (rows - 1))
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(array[i, j]);
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
