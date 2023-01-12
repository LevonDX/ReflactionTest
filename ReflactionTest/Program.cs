using System.Reflection;

namespace ReflactionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RTTI - RunTime Type Identitfication

            Type t = typeof(string);

            string methodName = "ToLower";

            MethodInfo methodInfo = 
                t.GetMethods()
                .GetMethodInfoByName(methodName);

            string s = "HELLO";

            string ls = methodInfo.Invoke(s, null).ToString();

            Console.WriteLine(ls);
        }
    }
}