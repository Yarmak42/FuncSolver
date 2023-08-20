using FuncSolver.MVVM;
using NUnit.Framework;

namespace WpfTestApp.UnitTests
{
    [TestFixture]
    public class VariablesUnitTests
    {
        [Test(Description = "Testing a method for calculating a value for a linear function.")]
        public void SetF_LeanerFunctionValueSetting_ValueIsSet()
        {
            //Arrange
            var varSet = new Variables();
            varSet.X = 1;
            varSet.Y = 2;
            double a = 3;
            double b = 4;
            int c = 5;
            string funcType = "Линейная";
            double expected = 12;

            //Act
            varSet.SetF(a, b, c, funcType);
            var actual = varSet.F;

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }

        [Test(Description = "Testing a method for quadratic a value for a linear function.")]
        public void SetF_QuadraticFunctionValueSetting_ValueIsSet()
        {
            //Arrange
            var varSet = new Variables();
            varSet.X = 2;
            varSet.Y = 3;
            double a = 4;
            double b = 5;
            int c = 10;
            string funcType = "Квадратичная";
            double expected = 41;

            //Act
            varSet.SetF(a, b, c, funcType);
            var actual = varSet.F;

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }

        [Test(Description = "Testing a method for calculating a value for a cubic function.")]
        public void SetF_CubicFunctionValueSetting_ValueIsSet()
        {
            //Arrange
            var varSet = new Variables();
            varSet.X = 2;
            varSet.Y = 3;
            double a = 4;
            double b = 5;
            int c = 200;
            string funcType = "Кубическая";
            double expected = 277;

            //Act
            varSet.SetF(a, b, c, funcType);
            var actual = varSet.F;

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }

        [Test(Description = "Testing a method for calculating a value for a fourth degree function.")]
        public void SetF_FourthDegreeFunctionValueSetting_ValueIsSet()
        {
            //Arrange
            var varSet = new Variables();
            varSet.X = 2;
            varSet.Y = 3;
            double a = 4;
            double b = 5;
            int c = 5000;
            string funcType = "4-ой степени";
            double expected = 5199;

            //Act
            varSet.SetF(a, b, c, funcType);
            var actual = varSet.F;

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }

        [Test(Description = "Testing a method for calculating a value for a fifth degree function.")]
        public void SetF_FifthDegreeFunctionValueSetting_ValueIsSet()
        {
            //Arrange
            var varSet = new Variables();
            varSet.X = 2;
            varSet.Y = 3;
            double a = 4;
            double b = 5;
            int c = 30000;
            string funcType = "5-ой степени";
            double expected = 30533;

            //Act
            varSet.SetF(a, b, c, funcType);
            var actual = varSet.F;

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }
    }
}