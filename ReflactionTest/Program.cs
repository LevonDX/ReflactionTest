using System.Reflection;

namespace ReflactionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RTTI - RunTime Type Identitfication

            Type t = typeof(Math);

            string methodName = "Sqrt";

            MethodInfo methodInfo =
                t.GetMethods()
                .GetMethodInfoByName(methodName);

            double d = (double)methodInfo.Invoke(null, new object[] { 100 }); // Sqrt(100)

            Console.WriteLine(d.ToString("0.00"));
        }
    }
}