using FuncSolver.MVVM;
using NUnit.Framework;
using System.Printing;
using System.Transactions;
using System.Windows.Controls;

namespace WpfTestApp.UnitTests
{
    [TestFixture]
    public class FuncTemplateUnitTests
    {
        private FuncTemplate _exFunc;

        [TestCase("Линейная", 2, 3, 4, 5, 6, 19)]
        [TestCase("Линейная", -2, 3, 4, 5, 6, 3)]
        [TestCase("Линейная", 2, -3, 4, 5, 6, 19)]
        [TestCase("Квадратичная", 2, 3, 4, 5, 60, 91)]
        [TestCase("Квадратичная", -2, 3, 4, 5, 60, 91)]
        [TestCase("Квадратичная", 2, -3, 4, 5, 60, 61)]
        [TestCase("Кубическая", 2, 3, 4, 5, 600, 677)]
        [TestCase("Кубическая", -2, 3, 4, 5, 600, 613)]
        [TestCase("Кубическая", 2, -3, 4, 5, 600, 677)]
        [TestCase("4-ой степени", 2, 3, 4, 5, 6000, 6199)]
        [TestCase("4-ой степени", -2, 3, 4, 5, 6000, 6199)]
        [TestCase("4-ой степени", 2, -3, 4, 5, 6000, 5929)]
        [TestCase("5-ой степени", 2, 3, 4, 5, 60000, 60533)]
        [TestCase("5-ой степени", -2, 3, 4, 5, 60000, 60277)]
        [TestCase("5-ой степени", 2, -3, 4, 5, 60000, 60533)]
        public void UpdateF_FunctionValueSetting_ValueIsSet(string type, int x, int y, int a, int b, int c, double exp)
        {
            //Arrange
            _exFunc = new FuncTemplate(type);
            _exFunc.CurrentVariablesSet = new Variables();
            _exFunc.A = a;
            _exFunc.B = b;
            _exFunc.CurrentC = c;
            _exFunc.CurrentVariablesSet.X = x;
            _exFunc.CurrentVariablesSet.Y = y;
            var expected = exp;

            //Act
            var actual = _exFunc.UpdateF();

            //Assert
            Assert.AreEqual(expected, actual, "The method incorrectly calculates the value of the function.");
        }
    }
}