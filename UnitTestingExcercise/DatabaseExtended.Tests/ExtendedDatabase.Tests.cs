using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DatabaseArrayAddPerson()
        {
            Person[] array = new Person[16];

           var person1 = new Person(123, "Tisho");
           var person2 = new Person(124, "Gosho");
           var person3 = new Person(125, "Mastara");
           var person4 = new Person(126, "Pavkata");
           var person5 = new Person(127, "Djukata");
           var person6 = new Person(128, "Feisa");
           var person7 = new Person(129, "Bitalsa");
           var person8 = new Person(120, "Ranarsa");
           var person9 = new Person(133, "CekoHardkora");
           var person10 = new Person(143, "Bango");
           var person11 = new Person(153, "Melbata");
           var person12 = new Person(163, "Vashkata");
           var person13 = new Person(173, "Pacata");
           var person14 = new Person(183, "Lurcha");
           var person15 = new Person(193, "Kitaeca");
           var person16 = new Person(103, "Svejiq");

            array[0] = person1;
            array[1] = person2;
            array[2] = person3;
            array[3] = person4;
            array[4] = person5;
            array[5] = person6;
            array[6] = person7;
            array[7] = person8;
            array[8] = person9;
            array[9] = person10;
            array[10] = person11;
            array[11] = person12;
            array[12] = person13;
            array[13] = person14;
            array[14] = person15;
            array[15] = person16;


            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);

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
        public void DatabaseArrayThrowsExceptionWhenAddUserWithSameID()
        {
            Person[] array = new Person[16];

            var person1 = new Person(123, "Tisho");
            var person2 = new Person(124, "Gosho");
            var person3 = new Person(125, "Mastara");
            var person4 = new Person(126, "Pavkata");
            var person5 = new Person(127, "Djukata");
            var person6 = new Person(128, "Feisa");
            var person7 = new Person(129, "Bitalsa");
            var person8 = new Person(120, "Ranarsa");
            var person9 = new Person(133, "CekoHardkora");
            var person10 = new Person(143, "Bango");
            var person11 = new Person(153, "Melbata");
            var person12 = new Person(163, "Vashkata");
            var person13 = new Person(173, "Pacata");
            var person14 = new Person(183, "Lurcha");
            var person15 = new Person(193, "Kitaeca");
            var person16 = new Person(193, "Svejiq");

            array[0] = person1;
            array[1] = person2;
            array[2] = person3;
            array[3] = person4;
            array[4] = person5;
            array[5] = person6;
            array[6] = person7;
            array[7] = person8;
            array[8] = person9;
            array[9] = person10;
            array[10] = person11;
            array[11] = person12;
            array[12] = person13;
            array[13] = person14;
            array[14] = person15;
            array[15] = person16;
           

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
            
            Assert.Throws<InvalidOperationException>(() => database.Add(person16));
        }

        [Test]
        public void DatabaseArrayThrowsExceptionWhenTryAddElementWithSameID()
        {
            Person[] array = new Person[16];
            var person = new Person(123, "Pesho");
            array[0] = person;
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1234, "Gosho")));
        }

        [Test]
        public void DatabaseShouldRemoveLastElementFromArray()
        {
            Person[] array = new Person[16];
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
            database.Remove();
            Assert.That(database.Count == 15);
        }

        [Test]
        public void DatabaseShouldThrowsExceptionWhenTryToRemoveElementFromEmptyArray()
        {
            Person[] array = new Person[0];
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseShouldReturnSameArray()
        {
            Person[] array = new Person[5];
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(array);
           // Person[] returnedArray = database.Fetch();
            Person[] expectedArray = new Person[5];
            //Assert.That(returnedArray, Is.EquivalentTo(expectedArray));
        }
    }
}