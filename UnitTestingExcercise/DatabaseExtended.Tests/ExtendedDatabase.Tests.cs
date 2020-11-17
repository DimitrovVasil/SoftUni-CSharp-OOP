using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DatabaseConstructorShouldWorkCorrectly()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(database.Count == people.Length);
          
        }

        [Test]
        public void DatabaseConstructorShouldThrowExceptionWhenArrayIs17()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void ShouldThrowExceptionWhenTryAddUserWithSameId()
        {
            Person person1 = new Person(300, "Tosho");
            Person person2 = new Person(300, "Gosho");

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(person1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }

        [Test]
        public void ShouldThrowExceptionWhenTryAddUserWithSameUsername()
        {
            Person person1 = new Person(200, "Gosho");
            Person person2 = new Person(300, "Gosho");

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(person1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }

        [Test]
        public void ShouldAddUserCorrectly()
        {
            Person person1 = new Person(200, "Tosho");
            Person person2 = new Person(300, "Gosho");

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(person1);
            database.Add(person2);
            Assert.That(database.Count == 2);
        }


        [Test]
        public void DatabaseShouldRemoveElementFromArrayCorrectly()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);
            database.Remove();

            int expectedCount = people.Length - 1;
            int actualCount = database.Count;
            Assert.That(expectedCount == actualCount);
        }

        [Test]
        public void DatabaseShouldThrowsExceptionWhenTryToRemoveElementFromEmptyArray()
        {
            Person[] array = new Person[0];
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenThereIsNoUserWithThisUsername()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Gosho11");
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenParameterIsNull()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionBecauseOfCaseSensitive()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("gosho1");
            });
        }

        [Test]
        public void DatabaseShouldFindUserCorrectly()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);
            var expectedPerson = new Person(1, "Gosho1");
            var actualPerson = database.FindByUsername("Gosho1");
            Assert.That(expectedPerson.UserName == actualPerson.UserName);
            Assert.That(expectedPerson.Id == actualPerson.Id);
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenThereIsNoUserWithThisId()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(12);
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenIdIsNegative()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
        }

        [Test]
        public void DatabaseShouldFindUserByIdCorrectly()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(0 + i, "Gosho" + i);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);
            var expectedPerson = new Person(1, "Gosho1");
            var actualPerson = database.FindById(1);
            Assert.That(expectedPerson.UserName == actualPerson.UserName);
            Assert.That(expectedPerson.Id == actualPerson.Id);
        }
    }
}