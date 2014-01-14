using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SmallTestFramework;

namespace TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFrameworkCore core = new TestFrameworkCore();

            core.RunTestFromAssembly(new string[] {"C:\\Users\\ibats\\Documents\\GitHub\\TestFramework\\DllWithTests\\bin\\Debug\\DllWithTests.dll" });



            //    TestClass tests = new TestClass();

            //    var itemType = typeof(TestClass);

            //    printInfo(itemType);





            //RunThemAll<typeof(item)>();

            // todo should be loaded automattically



        }

        //private static IEnumerable<Type> GetAssemblyInfo(string[] args)
        //{
        //    foreach (string file in args) {
        //        var assembly = Assembly.LoadFile(file);
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            if (Attribute.IsDefined(type, typeof()))
        //            yield return type;
        //        }

        //    }

        //    //return (from t in Assembly.GetExecutingAssembly().GetTypes()
        //    //        where t.BaseType == (typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
        //    //        select (T)Activator.CreateInstance(t)).ToList();
        //}


        //static void printInfo(Type itemType)
        //{
        //    var hasDataContract = Attribute.IsDefined(itemType, typeof(TestClassAttribute));
        //    if (hasDataContract)
        //    {
        //        Console.WriteLine("Found test class: " + itemType.Name);

        //        // Check if we have some methods to run

        //        MethodInfo[] methods = itemType.GetMethods();
        //        foreach (var method in methods)
        //        {
        //            Console.WriteLine("Found next attributes on method:" + method.Name);
        //            foreach (var methodAttribute in method.GetCustomAttributes(true))
        //            {
        //                Console.WriteLine("\t" + methodAttribute);
        //            }
        //        }
        //    }
        //}


        //static void RunThemAll<T>()
        //{
        //    var obj = Activator.CreateInstance<T>();

        //    //run all the methods that have TestMethod attribute.

        //    MethodInfo[] methods = typeof(T).GetMethods();
        //    foreach (var method in methods)
        //    {
        //        Console.WriteLine("Running test method:" + method.Name);
        //        foreach (var methodAttribute in method.GetCustomAttributes(true))
        //        {
        //            if (methodAttribute is TestMethodAttribute)
        //            {
        //                method.Invoke(obj, new object[] { });
        //            }
        //        }
        //    }


        //}
    }
}
