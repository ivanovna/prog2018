using System;
namespace ConsoleApplication
{
    class Program

    {
        public static int BinarySearch(int[] array, int element)

        {
            if (array.Length == 0) return -1;
            var left = 0;
            var right = array.Length - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (element <= array[middle])
                    right = middle;
                else left = middle + 1;
            }
            if (array[right] == element)
                return right;
            return -1;

        }
        static void Main(string[] args)

        {
            TestOneNumbers();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestRepeatNumbers();
            TestEmptyNumbers();
            TestVastNumbers();
            Console.ReadKey();

        }

        //Тестирование поиска одного элемента из 5 элементов
        private static void TestOneNumbers()
        {
            int[] oneNumber = { 1, 2, 3, 4, 5 };
            if (BinarySearch(oneNumber, 3) != 2)
                Console.WriteLine("! Поиск не нашел число 3 среди элементов массива {1, 2, 3, 4, 5}");
            else
                Console.WriteLine("Поиск одного элемента работает корректно");
        }

        //Тестирование поиска в отрицательных числах
        private static void TestNegativeNumbers()

        {
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };

            if (BinarySearch(negativeNumbers, -3) != 2)

                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");

            else

                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");

        }


        //Тестирование поиска отсутствующего элемента
        private static void TestNonExistentElement()

        {
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };

            if (BinarySearch(negativeNumbers, -1) >= 0)

                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");

            else

                Console.WriteLine("Поиск отсутствующего элемента вернул корректный результат, работает корректно");

        }

        //Тестирование поиска элемента, повторяющегося несколько раз
        private static void TestRepeatNumbers()
        {
            int[] repeatNumbers = { 1, 2, 3, 3, 4, 5 };
            var ind = BinarySearch(repeatNumbers, 3);
            if (repeatNumbers[ind] != 3)
                Console.WriteLine("! Поиск работает некорректно");
            else
                Console.WriteLine("Поиск среди элементов, повторяющихся несколько раз работает корректно");
        }

        //Тестирование поиска элемента в пустом массиве
        private static void TestEmptyNumbers()
        {
            int[] emptyNumbers = { };
            if (BinarySearch(emptyNumbers, 1) != -1)
                Console.WriteLine("! Поиск нашёл число 1 среди чисел {}, работает некоректно");
            else
                Console.WriteLine("Поиск элементов в пустом массиве работает корректно");
        }


        //Тестирование поиска элемента в массиве из 100001 элемента 
        private static void TestVastNumbers()
        {
            var vastNumbers = new int[100001];
            for (var i = 0; i < 100001; i++)
                vastNumbers[i] = i - 1;
            if (BinarySearch(vastNumbers, 100) != -1)
                Console.WriteLine("Поиск элементов в массиве из 100001 элемента работает корректно");
            else Console.WriteLine("! Поиск не нашёл число 100 среди 100001 элементов");
        }
    }

}