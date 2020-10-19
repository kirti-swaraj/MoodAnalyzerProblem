using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC4 & UC5 : Creates the mood analyser object with either default constructor or parameterized constructor according to message
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message if it is null default constructor is called else parameterized one</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Exception: class not found
        /// or  
        /// Exception: constructor not found
        /// </exception>
        public static object CreateMoodAnalyserObject(string className, string constructorName, string message)
        {
            string pattern = @"." + constructorName + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    object res;
                    if (message == null)
                    {
                        res = Activator.CreateInstance(moodAnalyserType, null);
                    }
                    else
                    {
                        res = Activator.CreateInstance(moodAnalyserType, message);
                    }
                    return res;
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Exception: class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Exception: constructor not found");
            }
        }
    }
}