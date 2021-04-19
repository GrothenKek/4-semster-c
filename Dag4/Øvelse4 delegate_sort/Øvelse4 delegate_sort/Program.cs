using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse4_delegate_sort
{
    class Program
    {

        static void Main(string[] args)
        {
            Comparator f1 = new Comparator(compare);
            int[] intArray = { 5, 67, 45, 23, 99, 44, 56, 12, 3, 44 };
            SortArray(intArray,f1);
            printArray(intArray);
            Console.ReadLine();

        }



        // sorter array ved hjælp af Comparator delegate
        public static void SortArray(int[] array, Comparator Compare)
        {
            if (array.Length == 1)
                return;

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }





        }

        public static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        // vi skal bruge Comparator til at vælge mellem stigende og faldende orden
        public delegate bool Comparator(int e1, int e2);
        public static bool compare(int e1, int e2)
        {
            return e1 > e2;
        }
           


    }
}


    

