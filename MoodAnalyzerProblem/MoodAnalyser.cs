﻿using System;
using System.Collections.Generic;
using System.Text;
namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }
        private string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("Parameterized Constructor");
        }
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