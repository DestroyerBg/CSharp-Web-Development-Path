using System;
using System.Linq;
using System.Reflection;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        [Test]
        public void Test_That_Constructor_Works_Correctly(int[] array)
        {
            int expectedCount = array.Length;
            Database database = new Database(array);
            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(array, database.Fetch());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        [Test]
        public void Testing_That_Stored_Array_Must_Be_Exactly_16Integers(int[] array)
        {
           InvalidOperationException exception = Assert.Throws<InvalidOperationException>((() 
               => new Database(array)));
           Assert.AreEqual("Array's capacity must be exactly 16 integers!",exception.Message);
            
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [Test]
        public void Testing_Add_Function(int[] array)
        {
            Database database = new Database(array);
            if (database.Count != 16)
            {
                database.Add(12);
                int[] arr = database.Fetch();
                Assert.AreEqual(12, arr[arr.Length-1]);
            }
            else
            {
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(12));
                Assert.AreEqual("Array's capacity must be exactly 16 integers!",exception.Message);
            }
        }
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 12 })]
        [TestCase(new int[] { })]
        public void Testing_Remove_Function(int[] array)
        {
            Database database = new Database(array);
            if (array.Any())
            {
                database.Remove();
                Assert.AreNotEqual(array,database.Fetch());
            }
            else
            {
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                    => database.Remove());
                Assert.AreEqual($"The collection is empty!",exception.Message);
            }

        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 12 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_Fetch_Method(int[] array)
        {
            int[] expectedArr = array;
            Database database = new Database(expectedArr);
            Assert.AreEqual(expectedArr,database.Fetch());
        }


    }
}
