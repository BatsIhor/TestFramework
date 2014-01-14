using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SmallTestFramework
{
    public class TestFrameworkCore
    {
        public void RunTestFromAssembly(string[] args)
        {
            IEnumerable<Type> types = GetTypesWithTests(args);

            PrintInfo(types);

            foreach (Type item in types)
            {
            }

        }

        IEnumerable<Type> GetTypesWithTests(string[] args)
        {
            foreach (string file in args)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (Attribute.IsDefined(type, typeof(TestClassAttribute)))
                    {
                        var obj = Activator.CreateInstance(type);
                        yield return type; 
                    }
                }

            }

            //return (from t in Assembly.GetExecutingAssembly().GetTypes()
            //        where t.BaseType == (typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
            //        select (T)Activator.CreateInstance(t)).ToList();
        }

        void PrintInfo(IEnumerable<Type> items)
        {
            foreach (var itemType in items)
            {
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
                }
            }
        }

        void RunThemAll<T>()
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
