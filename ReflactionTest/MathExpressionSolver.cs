using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            object[] argumentsObjectArray = new object[argumentsArray.Length];

            for (int i = 0; i < argumentsArray.Length; i++)
            {
                argumentsObjectArray[i] = Convert.ToDouble(argumentsArray[i]);
            }

            return argumentsObjectArray;
        }

        public double Calculate()
        {
            string methodName = this.GetMethodName();
            object[] arguments = this.GetArguments();

            Type t = typeof(Math);

            MethodInfo mi = null;
            
            foreach (MethodInfo item in t.GetMethods())
            {
                if (item.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)
                    && item.GetParameters().Length == arguments.Length)
                {
                    mi = item;
                    break;
                }
            }

            if(mi ==null)
            {
                throw new ArgumentException("Method not found");
            }

            double result = (double)mi.Invoke(null, arguments);

            return result;
        }
    }
}