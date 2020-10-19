// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MSTestMoodAnalyzer.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;

namespace MSTestMoodAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// UC 1.1 : Given the sad mood should return sad
        /// </summary>
        [TestMethod]
        public void GivenSad_ShouldReturnSad()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad mood");
            string expected = "Sad Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC 1.2 : Given the happy mood should return happy
        /// </summary>

        [TestMethod]
        public void GivenHappy_ShouldReturnHappy()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in any mood");
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC 3.1 : Given null should throw moodAnalysis custom exception
        /// </summary>

        [TestMethod]
        public void GivenNull_ThrowCustomException()
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

        /// <summary>
        /// UC 3.2 : Given empty should throw moodAnalysis custom exception indicating empty mood
        /// </summary>
        [TestMethod]
        public void GivenEmpty_ThrowCustomException()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("");
            string expected = "Mood should not be empty";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC 4.1 : Given moodAnalyser class name should create moodAnalyser object with default constructor
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            var expected = new MoodAnalyser();
            //Act
            object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            //Assert
            expected.Equals(result);
        }

        /// <summary>
        /// UC 4.2 : Given an improper class name should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblemDifferent.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: class not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 4.3 : Given an improper constructor name should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserDifferent");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: constructor not found in the class", exception.Message);
            }
        }
    }
}