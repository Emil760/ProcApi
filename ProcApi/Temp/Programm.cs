//namespace ProcApi.Temp
//{
//    using System;
//    using System.Collections.Generic;

//    class Program
//    {
//        static void Main()
//        {
//            // Create a dictionary to map integer values to delegates representing the instance methods
//            var methodDictionary = new Dictionary<int, Func<    , string>>
//        {
//            { 1, MethodA },
//            { 2, MethodB },
//            { 3, MethodC },
//            // Add more integer-value and method pairs here
//        };

//            // Call the method based on the integer value
//            int integerValueToInvoke = 2; // Change this value to invoke different methods
//            if (methodDictionary.TryGetValue(integerValueToInvoke, out var method))
//            {
//                string result = method.Invoke();
//                Console.WriteLine(result);
//            }
//            else
//            {
//                Console.WriteLine("Invalid integer value. No method to invoke.");
//            }
//        }

//        // Sample methods to be invoked
//        public static string MethodA()
//        {
//            return "MethodA is invoked!";
//        }

//        public string MethodB()
//        {
//            return "MethodB is invoked!";
//        }

//        public string MethodC()
//        {
//            return "MethodC is invoked!";
//        }
//    }

//}
