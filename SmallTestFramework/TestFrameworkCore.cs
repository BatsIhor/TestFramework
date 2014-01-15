using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

            var enumerable = types as Type[] ?? types.ToArray();

            PrintInfo(enumerable);

            foreach (Type item in enumerable)
            {
                string assemblyQualifiedName = item.FullName;
                Console.WriteLine(assemblyQualifiedName);


            }
            RunThemAll(enumerable);

        }

        private IEnumerable<Type> GetTypesWithTests(string[] args)
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
                        Console.WriteLine(obj.GetType());
                        yield return type;
                    }
                }
            }
        }

        private void PrintInfo(IEnumerable<Type> types)
        {
            foreach (var itemType in types)
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

        private void RunThemAll(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                object obj = Activator.CreateInstance(type);

                MethodInfo[] methods = type.GetMethods();

                MethodInfo startMethod = methods.FirstOrDefault(method => Attribute.IsDefined(method, typeof(TestStartAttribute)));
                MethodInfo stopMethod = methods.FirstOrDefault(method => Attribute.IsDefined(method, typeof(TestStopAttribute)));

                foreach (var method in methods)
                {
                    if (Attribute.IsDefined(method, typeof(TestMethodAttribute)))
                    {
                        Console.WriteLine("Running test method:" + method.Name);

                        if (startMethod != null)
                        {
                            startMethod.Invoke(obj, new object[] { });
                        }

                        if (Attribute.IsDefined(method, typeof (ExpectedExceptionAttribute)))
                        {
                            try
                            {
                                method.Invoke(obj, new object[] { });
                            }
                            catch (Exception)
                            {
                                //If we receive Expected Exception than its ok and we just continue to work, in other case we are rising this ecxeption.


                                throw;
                            }
                        }
                        else
                        {
                            method.Invoke(obj, new object[] { });                            
                        }

                        if (stopMethod != null)
                        {
                            stopMethod.Invoke(obj, new object[] { });
                        }
                    }
                }
            }
        }
    }
}
