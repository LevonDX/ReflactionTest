using ReflactionTest;

namespace TestProject
{
    [TestClass]
    public class MathExpressionTest
    {
        [TestMethod]
        public void TestGetArguments()
        {
            // assign
            string correct = "sqrt(100)";
            string incorrect = "Ararat73";
            
            MathExpressionSolver correctSolver = new MathExpressionSolver(correct);
            MathExpressionSolver incorrectSolver = new MathExpressionSolver(incorrect);

            // act
            string correctMethodName = correctSolver.GetMethodName();

            // assert
            Assert.AreEqual("sqrt", correctMethodName);
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver.GetMethodName());
        }
    }
}