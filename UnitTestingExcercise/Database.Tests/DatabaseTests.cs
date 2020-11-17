using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DatabaseArrayCapacityIs16()
        {
            int[] array = new int[16];
            Database.Database database = new Database.Database(array);

            Assert.That(database.Count == 16);
        }

        // [Test]
        //  public void DatabaseArrayCapacityThrowsExceptionWhenArrayCapacityIsNot16()
        //  {
        //     int[] array = new int[15];
        // DataBase database = new DataBase(array);
        //      Assert.Throws<InvalidOperationException>(() => new DataBase(array));
        // }

        [Test]
        public void DatabaseArrayShouldAddElement()
        {
            int[] array = new int[10];
            Database.Database database = new Database.Database(array);
            database.Add(2);
            Assert.That(database.Count == 11);
        }

        [Test]
        public void DatabaseArrayThrowsExceptionWhenTryAddElementAndCapacityIsFull()
        {
            int[] array = new int[16];
            Database.Database database = new Database.Database(array);
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void DatabaseShouldRemoveLastElementFromArray()
        {
            int[] array = new int[16];
            Database.Database database = new Database.Database(array);
            database.Remove();
            Assert.That(database.Count == 15);
        }

        [Test]
        public void DatabaseShouldThrowsExceptionWhenTryToRemoveElementFromEmptyArray()
        {
            int[] array = new int[0];
            Database.Database database = new Database.Database(array);      
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseShouldReturnSameArray()
        {
            int[] array = new int[5] { 1, 2, 3 ,4 , 5};
            Database.Database database = new Database.Database(array);
            int[] returnedArray = database.Fetch();
            int[] expectedArray = new int[5] { 1, 2, 3, 4, 5, };
            Assert.That(returnedArray, Is.EquivalentTo(expectedArray));
        }
    }
}