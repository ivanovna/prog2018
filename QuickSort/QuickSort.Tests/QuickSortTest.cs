using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSort.Tests
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestSimpleMassive()
        {
            //Сортировка массива из трёх элементов. После сортировки второй элемент больше первого, третий больше второго
            int[] simpleNumbers = new int[3];
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
                simpleNumbers[i] = rnd.Next();
            Program.QuickSort(simpleNumbers);
            var boolElement = false;
            if (simpleNumbers[2] >= simpleNumbers[1] && simpleNumbers[1] >= simpleNumbers[0])
                boolElement = true;
            Assert.AreEqual(true, boolElement);

        }

        [TestMethod]
        public void TestSame100Elements()
        {
            //Тестирование сортировки массива из 100 одинаковых элементов
            int[] sameNumbers = new int[100];
            var boolElement = true;
            for (int i = 0; i < sameNumbers.Length; i++)
                sameNumbers[i] = 1;
            Program.QuickSort(sameNumbers);
            for (int i = 0; i < sameNumbers.Length - 1; i++)
            {
                if (sameNumbers[i] > sameNumbers[i + 1])
                {
                    boolElement = false;
                    break;
                }
            }
            Assert.AreEqual(true, boolElement);
        }

        [TestMethod]
        public void est1000RandomElements()
        {
            //Тестирование сортировки в массиве из 1000 случайных элементов
            var rnd = new Random();
            int size = 1000;
            int[] thousandNumbers = new int[size];
            var boolElement = true;

            for (int i = 0; i < size; i++)
                thousandNumbers[i] = rnd.Next();
            Program.QuickSort(thousandNumbers);

            for (int i = 0; i < 10; i++)
            {
                int position = rnd.Next(0, 998);
                if (thousandNumbers[position] > thousandNumbers[position + 1])
                {
                    boolElement = false;
                    break;
                }
            }
            Assert.AreEqual(true, boolElement);
        }
        [TestMethod]
        public void TestEmptyArray()
        {
            //Тестирование сортировки в пустом массиве (содержащем 0 элементов)
            int[] emptyArray = new int[0];
            var boolElement = false;
            Program.QuickSort(emptyArray);
            if (emptyArray.Length == 0)
                boolElement = true;
            Assert.AreEqual(true, boolElement);
        }
        [TestMethod]
        public void TestHugeMassive()
        {
            //Тестирование сортировки в массиве из 100 000 000 случайных элементов
            var rnd = new Random();
            int size = 1500000000;
            int[] thousandNumbers = new int[size];
            var boolElement = true;

            for (int i = 0; i < size; i++)
                thousandNumbers[i] = rnd.Next();
            Program.QuickSort(thousandNumbers);

            for (int i = 0; i < 10; i++)
            {
                int position = rnd.Next(0, 1500000000-2);
                if (thousandNumbers[position] > thousandNumbers[position + 1])
                {
                    boolElement = false;
                    break;
                }
            }
            Assert.AreEqual(true, boolElement);
        }
    }
}
