using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        
        public void ThreeElementsTest()
        {
            //Добавление и поиск трёх элементов
            var hashTest = new HashTable.HashTable(3);

            hashTest.PutPair("One", "Один");
            hashTest.PutPair("Two", "Два");
            hashTest.PutPair("Three", "Три");

            Assert.AreEqual(hashTest.GetValueByKey("One"), "Один");
            Assert.AreEqual(hashTest.GetValueByKey("Two"), "Два");
            Assert.AreEqual(hashTest.GetValueByKey("Three"), "Три");
        }

        [TestMethod]
        public void TwoEquialsElementsTest()
        {
            //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
            var hashTest = new HashTable.HashTable(2);

            hashTest.PutPair("1", "One");
            hashTest.PutPair("1", "Three");
            
            if (!(hashTest.GetValueByKey("1")).Equals("Three")) throw new Exception();
        }

        [TestMethod]
        public void BigElementsTest()
        {
            //Поиск одного элемента из тысячи
            var hashTest = new HashTable.HashTable(10000);
            var rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                hashTest.PutPair(i, i + 1);
            }
            var key = rnd.Next(0, 9999);
            Assert.AreEqual(hashTest.GetValueByKey(key), (key+1));
        }

        [TestMethod]
        public void BigElementsSearchTests()
        {
            //Поиск тысячи недобавленныех ключей
            var hashTest = new HashTable.HashTable(11000);

            for (int i = 0; i < 10000; i++)
            {
                hashTest.PutPair(i, i);
            }

            for (int i = 10000; i < 11000; i++)
            {
                Assert.AreEqual(hashTest.GetValueByKey(i), null);
            }
        }
    }
}