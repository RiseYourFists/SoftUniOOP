namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;

    [TestFixture]
    public class CarManagerTests
    {
        private Car TestCar;

        [SetUp]
        public void InitializeNewCar()
            => TestCar = new Car("Fiat", "Punto", 1.5, 300);

        [TestCase(null, "Punto", 1.5, 300)]
        [TestCase("", "Punto", 1.5, 300)]
        public void Test_Make_NullOrEmpty_Validation
            (string make, string model, double fuelConsumption, double capacity )
            => Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, capacity));

        [TestCase("Fiat", "", 1.5, 300)]
        [TestCase("Fiat", null, 1.5, 300)]
        public void Test_Model_NullOrEmpty_Validation
            (string make, string model, double fuelConsumption, double capacity)
            => Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, capacity));
        
        [TestCase("Fiat", "Punto", -1, 300)]
        [TestCase("Fiat", "Punto", 0, 300)]
        public void Test_FuelConsumption_NegativeOrZero_Validation
            (string make, string model, double fuelConsumption, double capacity)
            => Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, capacity));

        [TestCase("Fiat", "Punto", 1.5, 0)]
        [TestCase("Fiat", "Punto", 1.5, -300)]
        public void Test_FuelCapacity_ZeroOrNegative_Validation
            (string make, string model, double fuelConsumption, double capacity)
            => Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, capacity));

        [TestCase(0)]
        [TestCase(-1)]
        public void Test_Refuel_ZeroOrNegativeValidation(double amount)
            => Assert.Throws<ArgumentException>(() => TestCar.Refuel(amount));
        
        [TestCase(100, 100)]
        [TestCase(1000, 300)]
        public void Test_Refuel_Functionality_Expectation(double amount, double expectedOutput)
        {
            TestCar.Refuel(amount);
            Assert.AreEqual(expectedOutput, TestCar.FuelAmount);
        }

        [TestCase(double.MaxValue)]
        public void Test_Drive_DrivableDistance_Validation(double distance)
            => Assert.Throws<InvalidOperationException>(() => TestCar.Drive(distance));
        
        [TestCase(100, 98.5)]
        public void Test_Drive_Functionality_Expectation(double distance, double expectedOutput)
        {
            TestCar.Refuel(100);
            TestCar.Drive(distance);
            Assert.AreEqual(expectedOutput, TestCar.FuelAmount);
        }
            
    }
}