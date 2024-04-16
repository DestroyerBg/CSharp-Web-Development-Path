using NUnit.Framework.Internal;

namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Linq;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private static Person[] persons = new Person[10];

        [SetUp]
        public void SetUp()
        { 
            Person person1 = new Person(123432, "Gabriel");
         Person person2 = new Person(34324234, "Nikolai");
         Person person3 = new Person(23423423, "Simeon");
         Person person4 = new Person(456546, "Boris");
         Person person5 = new Person(4354343, "Viktor");
         Person person6 = new Person(76876876, "Gancho");
         Person person7 = new Person(657658, "Dimitur");
         Person person8 = new Person(45645634, "Dido");
         Person person9 = new Person(5476456, "Atanas");
         Person person10 = new Person(164578, "Ilkay");
         persons[0] = person1;
         persons[1] = person2;
         persons[2] = person3;
         persons[3] = person4;
         persons[4] = person5;
         persons[5] = person6;
         persons[6] = person7;
         persons[7] = person8;
         persons[8] = person9;
         persons[9] = person10;
         
        }
        [Test]
        [TestCase("DestroyerBg", 984375298437)]
        [TestCase("Pesho", 230492394)]
        public void Test_Person_Constructor_Should_Work_Correctly(string username, long id)
        {
            Person person = new Person(id, username);
            Assert.AreEqual(person.UserName, username);
            Assert.AreEqual(id, person.Id);
        }
        [Test]
        public void Test_Database_Constructor_Should_Work_Correctly()
        {
            Database database = new Database(persons);
            Assert.AreEqual(persons.Length,database.Count);
        }
        [Test]
        public void Test_Database_Constructor_Should_TrowException_When_People_Are_More_Than_16()
        {
            Person[] personsExtended =
            {
                new Person(1,"Lukanka"),
                new Person(2,"Maslina"),
                new Person(3,"Margarita"),
                new Person(4,"RumenLukanov"),
                new Person(5,"TrevorPhilips"),
                new Person(6,"Michael"),
                new Person(7,"BoikoBorisov"),
                new Person(8,"Test"),
                new Person(9,"Tosheto"),
                new Person(10,"RTX306012GB"),
                new Person(11,"SlaviTrifonov"),
                new Person(12,"ToniStoraro"),
                new Person(13,"SprichstDuDeutch?"),
                new Person(14,"Fighter"),
                new Person(15,"Banica"),
                new Person(16,"Fiki"),
                new Person(17,"BMWE46")
            };
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new Database(personsExtended));
            Assert.AreEqual($"Provided data length should be in range [0..16]!",exception.Message);

        }

        [Test]
        public void Testing_Count_Database_Should_Work_Correctly()
        {
            Database database = new Database(persons);
            int expectedResult = persons.Length;
            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        [TestCase("Nqkoi",23742374)]
        [TestCase("Adz",8675950)]
        public void Test_Database_Add_Method_Should_Work_Correctly(string username, long id)
        {
            Database database = new Database();
            Person person = new Person(id, username);
            database.Add(person);
            Person databasePerson = database.FindById(id);
            Assert.AreEqual(person, databasePerson);
        }

        [Test]
        public void Test_Database_Add_Method_Should_Increase_Count()
        {
            Database database = new Database(persons);
            int expectedResult = 11;
            database.Add(new Person(123,"ChichkoParichko"));
            Assert.AreEqual(expectedResult,database.Count);
        }
        [Test]
        [TestCase(23423, "Gabriel")]
        [TestCase(4354365, "Dido")]
        [TestCase(657657, "Viktor")]
        public void Test_Database_Add_Method_Should_Throw_Exception_When_Person_User_Name_Is_Here
            (long id, string username)
        {
            Database db = new Database(persons);
            Person person = new Person(id, username);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => db.Add(person));
            Assert.AreEqual($"There is already user with this username!",exception.Message);
        }

        [Test]
        public void Test_Database_Add_Method_Should_Throw_Exception_When_PersonCount_Gets_More_Than16()
        {
            Person[] personsExtended =
            {
                new Person(1,"Lukanka"),
                new Person(2,"Maslina"),
                new Person(3,"Margarita"),
                new Person(4,"RumenLukanov"),
                new Person(5,"TrevorPhilips"),
                new Person(6,"Michael"),
                new Person(7,"BoikoBorisov"),
                new Person(8,"Test"),
                new Person(9,"Tosheto"),
                new Person(10,"RTX306012GB"),
                new Person(11,"SlaviTrifonov"),
                new Person(12,"ToniStoraro"),
                new Person(13,"SprichstDuDeutch?"),
                new Person(14,"Fighter"),
                new Person(15,"Banica"),
                new Person(16,"Fiki"),
            };
            Database db = new Database(personsExtended);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                db.Add(new Person(23543, "Erkan")));
            Assert.AreEqual($"Array's capacity must be exactly 16 integers!",ex.Message);
        }
        [Test]
        [TestCase(657658, "Petkan")]
        [TestCase(34324234, "Shishe")]
        [TestCase(456546, "Lukanka")]
        public void Test_Database_Add_Method_Should_Work_Throw_Exception_When_Person_ID_Is_Here
        (long id, string username)
        {
            Database db = new Database(persons);
            Person person = new Person(id, username);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => db.Add(person));
            Assert.AreEqual($"There is already user with this Id!", exception.Message);
        }

        [Test]
        public void Remove_Method_Should_Remove_Last_Person_From_Collection()
        {
            Database db = new Database(persons);
            db.Remove();
            Assert.AreNotEqual(persons.Length,db.Count);
            
        }

        [Test]
        public void Remove_Method_Should_Throw_Exception_When_Try_To_Remove_From_Empty_Database()
        {
            Database database = new Database();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.Remove());
        }

        [Test]
        [TestCase(76876876, "Gancho")]
        [TestCase(5476456, "Atanas")]
        [TestCase(123432, "Gabriel")]
        public void Find_User_Method_ByUsername_Should_Work_Correctly(long id, string username)
        {
            Person person = new Person(id, username);
            Database db = new Database(persons);
            Person found = db.FindByUsername(username);
            Assert.IsNotNull(found);
            Assert.AreEqual(id, found.Id);
            Assert.AreEqual(person.UserName,found.UserName);
        }

        [Test]
        [TestCase("Lukanka")]
        [TestCase("Palachinka")]
        [TestCase("JoroIgnatov")]
        public void Find_User_Method_ByUsername_Should_Throw_Exception_When_Person_Username_Is_Not_Here(string username)
        {
            Database db = new Database(persons);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                db.FindByUsername(username));
            Assert.AreEqual($"No user is present by this username!",exception.Message);
        }

        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void Find_User_Method_ByUsername_Should_Throw_Exception_When_Person_Username_Is_NullOrEmpty
            (string username)
        {
            Database db = new Database(persons);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                db.FindByUsername(username));
            Assert.AreEqual($"Username parameter is null!", exception.ParamName);
        }
        [Test]
        [TestCase("gAbrIeL")]
        [TestCase("dIDo")]
        [TestCase("GaNchO")]
        public void Test_If_Find_User_Method_Is_Case_Sensitive(string username)
        {
            Database database = new Database(persons);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.FindByUsername(username));
            Assert.AreEqual($"No user is present by this username!", exception.Message);
        }
        [Test]
        [TestCase(76876876, "Gancho")]
        [TestCase(5476456, "Atanas")]
        [TestCase(123432, "Gabriel")]
        public void Find_User_By_ID_Method_Should_Work_Correctly(long id, string username)
        {
            Person person = new Person(id, username);
            Database db = new Database(persons);
            Person found = db.FindById(id);
            Assert.IsNotNull(found);
            Assert.AreEqual(id, found.Id);
            Assert.AreEqual(person.UserName, found.UserName);
        }

        [Test]
        [TestCase(123)]
        [TestCase(098)]
        [TestCase(22222)]
        public void Find_User_By_Id_Method_Should_Throw_Exception_When_ID_Is_Not_In_Database(long id)
        {
            Database db = new Database(persons);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                db.FindById(id));
            Assert.AreEqual($"No user is present by this ID!", exception.Message);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-1111)]
        [TestCase(-398)]
        public void Find_User_By_Id_Method_Should_Throw_Exception_When_ID_Is_Negative(long id)
        {
            Database db = new Database(persons);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                db.FindById(id));
            Assert.AreEqual($"Id should be a positive number!", exception.ParamName);
        }

    }
}









