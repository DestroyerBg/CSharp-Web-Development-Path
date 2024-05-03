using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud departmentCloud;
        [SetUp]
        public void Setup()
        {
            departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void TestDepartmentCloudClassIsNotNull()
        {
            Assert.IsNotNull(departmentCloud);
        }

        [Test]

        public void TestDepartmentCloudClassTasksAndResourcesCollectionNotNull()
        {
            Assert.IsNotNull(departmentCloud.Tasks);
            Assert.IsNotNull(departmentCloud.Resources);
        }

        [Test]

        public void TestDepartmentCloudClassTasksAndResourcesCollectionAreEmptyAfterInitilization()
        {
            Assert.AreEqual(0,departmentCloud.Resources.Count);
            Assert.AreEqual(0, departmentCloud.Tasks.Count);
        }
        [Test]

        public void TestLogTaskMethodThrowsExceptionWhenArgsAreBelowOrMoreOfThree()
        {
            string[] args = { "task1", "task2" };
            string[] args2 = { "task1", "task2", "task3", "task4", "task5", };
            Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(args);
            });

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(args2);
            });
            Assert.AreEqual(exception.Message, "All arguments are required.");
            Assert.AreEqual("ArgumentException", exception.GetType().Name);

        }

        [Test]
        public void TestLogTaskMethodThrowsExceptionWhenAnyArgIsNull()
        {
            string[] args2 = { null, "task2", null};
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(args2);
            });
            Assert.AreEqual("ArgumentException", exception.GetType().Name);
            Assert.AreEqual(exception.Message, "Arguments values cannot be null.");
        }

        [Test]
        public void TestLogTaskMethodCannotAddAnyTaskMoreThanOneTimeWithSameName()
        {
            string[] args2 = {"1", "BMW", "E46"};
            departmentCloud.LogTask(args2);
            Assert.AreEqual(departmentCloud.LogTask(args2), $"E46 is already logged.");

        }

        [Test]
        public void TestLogTaskMethodAddsTaskSuccesfullyAndResourceConnectionRemainsSame()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            Assert.AreEqual(1, departmentCloud.Tasks.Count);
            Assert.AreEqual(0, departmentCloud.Resources.Count);
        }

        [Test]
        public void TestLogTaskMethodReturnsCorrectMessage()
        {
            string[] args2 = { "1", "BMW", "E46" };
            string message = departmentCloud.LogTask(args2);
            Assert.AreEqual("Task logged successfully.",message);
        }

        [Test]
        public void TestLogTaskMethodCreatesTaskComplete()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            var resource = departmentCloud.Tasks.ToArray()[0];
            Assert.IsNotNull(resource);
            Assert.AreEqual("E46", resource.ResourceName);
        }

        [Test]
        public void CreateResourceMethodReturnsFalseWhenThereAreNoTasks()
        {
            Assert.AreEqual(departmentCloud.CreateResource(),false);
        }

        [Test]
        public void CreateResourceMethodReturnsTrueWhenTaskIsHere()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            Assert.AreEqual(departmentCloud.CreateResource(),true);
        }

        [Test]
        public void CreateResourceMethodCreateResourceCompletely()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            departmentCloud.CreateResource();
            var resource = departmentCloud.Resources.ToArray()[0];
            Assert.IsNotNull(resource);
            Assert.AreEqual("E46", resource.Name);
            Assert.IsFalse(resource.IsTested);
            Assert.AreEqual("BMW", resource.ResourceType);
        }

        [Test]
        public void CreateResourceMethodTakesResourceFromTasksCollectionAndPutsItToResources()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            Assert.AreEqual(1, departmentCloud.Tasks.Count);
            Assert.AreEqual(0, departmentCloud.Resources.Count);
            departmentCloud.CreateResource();
            Assert.AreEqual(0, departmentCloud.Tasks.Count);
            Assert.AreEqual(1, departmentCloud.Resources.Count);

        }

        [Test]
        public void TestResouceMethodReturnsCorrectResource()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            departmentCloud.CreateResource();

            var resource = departmentCloud.TestResource("E46");
            Assert.IsNotNull(resource);
            Assert.AreEqual("E46", resource.Name);
            Assert.IsTrue(resource.IsTested);
            Assert.AreEqual("BMW", resource.ResourceType);
        }

        [Test]
        public void TestResourceMethodReturnsNullWhenResourceIsNotHere()
        {
            string[] args2 = { "1", "BMW", "E46" };
            departmentCloud.LogTask(args2);
            departmentCloud.CreateResource();
            var resource = departmentCloud.TestResource("W211");
            Assert.IsNull(resource);
        }
    }
}