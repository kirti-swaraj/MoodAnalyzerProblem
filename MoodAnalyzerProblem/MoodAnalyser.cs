
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// Default constructor of the MoodAnalyser class
        /// </summary>
        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }

        public string message;

        /// <summary>
        /// Parameterized constructor of the MoodAnalyser class
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("Parameterized Constructor");
        }

        /// <summary>
        /// Analyses the mood on the basis of message in the string 
        /// </summary>
        /// <returns> Happy Mood or Sad Mood or exception message</returns>
        /// <exception cref="MoodAnalyzerProblem.MoodAnalyserCustomException">
        /// Mood should not be empty
        /// or
        /// Mood should not be null
        /// </exception>
        public string AnalyseMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (message.ToUpper().Contains("SAD"))
                {
                    Console.WriteLine("Your current mood is: Sad Mood");
                    return "Sad Mood";
                }
                else
                {
                    Console.WriteLine("Your current mood is: Happy Mood");
                    return "Happy Mood";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Console.WriteLine(exception.Message);
                return exception.Message;
            }
        }
    }
}