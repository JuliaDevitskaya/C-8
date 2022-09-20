// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

using static System.Console;
using System.Linq;
Clear();

WriteLine("Введите параметры массива через пробел: ");
int[] parametrs = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
WriteLine();
int[,] array = GetMatrix(parametrs[0], parametrs[1], parametrs[2], parametrs[3]);
PrintMatrix(array);
WriteLine();
int[] rowArray = GetSumRowArray(array);
WriteLine(String.Join(" ", rowArray));
WriteLine();
int result = FindStringMinSumElement(rowArray);
WriteLine($"Номер строки с наименьшей суммой элементов: {result}");
// SortArray(array);
// PrintMatrix(array);


int[,] GetMatrix(int rows, int colums, int minValue, int maxValue)
{
    int[,] result = new int[rows, colums];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < colums; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintMatrix(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]} ");
        }
        WriteLine();
    }
}


int[] GetSumRowArray(int[,] inArray)
{
    int[] result = new int[inArray.GetLength(0)];
    for (int j = 0; j < inArray.GetLength(1); j++)
    {
        int k = 0;
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            result[k] += inArray[i, j];
            k++;
        }
    }
    return result;
}

int FindStringMinSumElement(int[] inArray)
{
    int min = inArray[0];
    int index = 0;
    for (int i = 1; i < inArray.Length; i++)
    {
        if (min > inArray[i])
        {
            min = inArray[i];
            index = i;
        }
    }
    return index;
}


