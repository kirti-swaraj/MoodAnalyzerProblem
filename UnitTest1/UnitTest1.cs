// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MSTestMoodAnalyzer.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MSTestMoodAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        //UC1
        [TestMethod]
        public void SadMoodTest()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad mood");
            string expected = "Sad Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HappyMoodTest()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in any mood");
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenNullUsingCustomException()
        {
            try
            {
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                //Act
                string actual = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be null", exception.Message);
            }
        }
    
        //UC2
        [TestMethod]
        public void GivenEmptyUsingCustomException()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("");
            string expected = "Mood should not be empty";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}