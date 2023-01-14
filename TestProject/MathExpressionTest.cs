using ReflactionTest;

namespace TestProject
{
    [TestClass]
    public class MathExpressionTest
    {
        [TestMethod]
        public void TestGetMethodName()
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

        [TestMethod]
        public void TestGetArguments()
        {
            // assign
            string oneArg = "sqrt(100)";
            string incorrect = "Ararat73";
            string twoArgs = "pow(2, 3)";

            MathExpressionSolver oneArgSolver = new MathExpressionSolver(oneArg);
            MathExpressionSolver twoArgSolver = new MathExpressionSolver(twoArgs);

            // act
            object[] argsOne = oneArgSolver.GetArguments();
            object[] argsTwo = twoArgSolver.GetArguments();

            // assert
            Assert.IsTrue(argsOne[0] is double);
            Assert.AreEqual(argsOne[0], 100d);

            Assert.AreEqual(argsTwo[0], 2d);
            Assert.AreEqual(argsTwo[1], 3d);
            Assert.IsTrue(argsTwo.Length == 2);
        }
    }
}