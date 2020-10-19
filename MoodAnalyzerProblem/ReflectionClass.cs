using System;
using System.Reflection;

namespace MoodAnalyzerProblem
{
    public class ReflectionClass
    {
        public static void Test()
        {
            Type type = Type.GetType("MoodAnalyzerProblem.Customer");

            ///printing fullname
            Console.WriteLine("\nFullName is {0} ", type.FullName);

            ///printing class name
            Console.WriteLine("ClassName is {0} ", type.Name);

            ///printing methods of customer
            MethodInfo[] methods = type.GetMethods();
            Console.WriteLine("\nMethods present in Customer class:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }

            ///printing properties
            Console.WriteLine("\nProperties present in Customer class:");
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("Methods are: " + property.PropertyType.Name + " " + property.Name);
            }

            ///printing constructors
            Console.WriteLine("\nConstructors present in Customer class:");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
            Console.WriteLine();
        }
    }
}