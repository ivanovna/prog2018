using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Program
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if ((start == end) | (array.Length == 0)) return;
            int storeIndex = start;
            var pivot = array[end];
            for (int i = start; i < end; i++)
            {
                if (array[i] < pivot)
                {
                    Interchange(array, i, storeIndex);
                    storeIndex++;
                }
            }
            Interchange(array, storeIndex, end);
            if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
            if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void Interchange(int[] array, int i, int j)
        {
            int auxiliaryVariable;
            auxiliaryVariable = array[i];
            array[i] = array[j];
            array[j] = auxiliaryVariable;
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}