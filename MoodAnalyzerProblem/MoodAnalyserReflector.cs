

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserReflector
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
        public static object CreateMoodAnalyserObject(string className, string constructorName, string message = null)
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
                        res = Activator.CreateInstance(moodAnalyserType, null);
                    else
                        res = Activator.CreateInstance(moodAnalyserType, message);
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

        /// <summary>
        /// UC 6 : Invokes the AnalyseMood method and returns message indicating mood type.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">Exception: method not found</exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Exception: method not found");
            }
        }

        /// <summary>
        /// UC 7 : Used to change the message field dynamically using reflection
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Exception: Message should not be null
        /// or
        /// Exception: Field is not found
        /// </exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Exception: Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Exception: Field is not found");
            }
        }
    }
}