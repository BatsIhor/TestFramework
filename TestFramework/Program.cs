using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass tests = new TestClass();

            var itemType = typeof(TestClass);

            var hasDataContract = Attribute.IsDefined(itemType, typeof(TestClassAttribute));
            if (hasDataContract)
            {
                Console.WriteLine("Found test class: " + itemType.Name);

                // Check if we have some methods to run

                MethodInfo[] methods = itemType.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("Found next attributes on method:" + method.Name);
                    foreach (var methodAttribute in method.GetCustomAttributes(true))
                    {
                        Console.WriteLine("\t" + methodAttribute);
                    }
                }

                // TODO let's run our tests.

                RunThemAll<TestClass>();

            }
        }

        static void RunThemAll<T>()
        {
            var obj = Activator.CreateInstance<T>();

            //run all the methods that have TestMethod attribute.

            MethodInfo[] methods = typeof(T).GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine("Running test method:" + method.Name);
                foreach (var methodAttribute in method.GetCustomAttributes(true))
                {
                    if (methodAttribute is TestMethodAttribute)
                    {
                        method.Invoke(obj, new object[] { });
                    }
                }
            }


        }
    }
}
