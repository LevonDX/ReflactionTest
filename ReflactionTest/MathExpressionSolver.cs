using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflactionTest
{
    public class MathExpressionSolver
    {
        private readonly string expression;
        public string Expression
        {
            get
            {
                return expression;
            }
        }

        public MathExpressionSolver(string expression)
        {
            this.expression = expression;
        }

        public string GetMethodName()
        {
            int bIndex = this.expression.IndexOf('(');

            if (bIndex == -1)
            {
                throw new ArgumentException("Invalid format");
            }

            string methodName = this.expression.Substring(0, bIndex);

            return methodName;
        }

        public object[] GetArguments()
        {
            int bIndex1 = this.expression.IndexOf('(');
            int bIndex2 = this.expression.IndexOf(')');

            if(bIndex1 == -1 || bIndex2 == -1)
            {
                throw new ArgumentException("Invalid format");
            }

            string arguments = this.expression.Substring(bIndex1 + 1, bIndex2 - bIndex1 - 1);

            string[] argumentsArray;

            if (arguments.Contains(","))
            {
                argumentsArray = arguments.Split(',');
            }
            else
            {
                argumentsArray = new string[] { arguments };
            }

            object[] argumentsObjectArray = argumentsArray;

            return argumentsObjectArray;
        }
    }
}
