// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyzer portal!");
            Console.WriteLine("Type how you feeling right now: ");
            string mood = Console.ReadLine();
            MoodAnalyser moodAnalyser = new MoodAnalyser(mood);
            moodAnalyser.AnalyseMood();
            try
            {
                Console.WriteLine("UC 4-7:");
                MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
                MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "happy");
                MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMood");
                Console.WriteLine(MoodAnalyserReflector.SetField("HAPPY", "message"));
            }
            catch (MoodAnalyserCustomException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}