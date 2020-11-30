namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {

        [Test]
        public void CreateRobotCorrectly()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Assert.That(robot.Name == robotName);
            Assert.That(robot.MaximumBattery == maximumBattery);
            Assert.That(robot.Battery == maximumBattery);
        }

        [Test]
        public void RobotsCountShouldBe0()
        {
            RobotManager manager = new RobotManager(5);
            Assert.That(manager.Count == 0);
        }

        [Test]
        public void RobotsCapacityShouldBe5()
        {
            RobotManager manager = new RobotManager(5);
            Assert.That(manager.Capacity == 5);
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void RobotsCapacityShouldThrowsExceptionWhenIsBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(capacity);
            });
        }

        [Test]
        public void ClassShouldThrowExceptionWhenThereAreRobotWithGivenName()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Robot robot2 = new Robot("Tisho", 100);

            RobotManager manager = new RobotManager(5);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot2);
            });
        }

        [Test]
        public void ClassShouldThrowExceptionWhenCountIsEqualToCapacity()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Robot robot2 = new Robot("Gosho", 100);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot2);
            });
        }

        [Test]
        public void ClassShouldWorksCorrectly()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Robot robot2 = new Robot("Gosho", 100);

            RobotManager manager = new RobotManager(2);
            manager.Add(robot);
            manager.Add(robot2);

            Assert.That(manager.Count == 2);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenTryToRemoveNullRobot()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Robot robot2 = new Robot("Gosho", 100);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove(robot2.Name);
            });
        }

        [Test]
        public void RemoveShouldRemoveRobotCorrectly()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);
            Robot robot2 = new Robot("Gosho", 100);

            RobotManager manager = new RobotManager(3);
            manager.Add(robot);
            manager.Add(robot2);

            Assert.That(manager.Count == 2);

            manager.Remove(robot2.Name);

            Assert.That(manager.Count == 1);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenTryToRemoveNullRobot()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Misho", "someJob", 20);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWhenBatteryUsageIsMoreThanBattery()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robot.Name, "someJob", 200);
            });
        }

        [Test]
        public void WorkShouldWorkCorrectly()
        {
            string robotName = "Tisho";
            int maximumBattery = 100;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);
            manager.Work(robot.Name, "someJob", 10);

            Assert.That(robot.Battery == 90);

        }

        [Test]
        public void WorkShouldWorkCorrectlyWhenUsageIsEqualToBattery()
        {
            string robotName = "Tisho";
            int maximumBattery = 100;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);
            manager.Work(robot.Name, "someJob", 100);

            Assert.That(robot.Battery == 0);
        }

        [Test]
        public void ChargeShouldThrowExceptionWhenRobotIsNull()
        {
            string robotName = "Tisho";
            int maximumBattery = 50;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Gosho");
            });
        }
        [Test]
        public void ChargeShouldWorksCorrectly()
        {
            string robotName = "Tisho";
            int maximumBattery = 200;

            Robot robot = new Robot(robotName, maximumBattery);

            RobotManager manager = new RobotManager(1);
            manager.Add(robot);
            
            manager.Work(robot.Name, "someJob", 50);
            Assert.That(robot.Battery == 150);

            manager.Charge(robot.Name);
            Assert.That(robot.Battery == robot.MaximumBattery);

        }
    }
}
