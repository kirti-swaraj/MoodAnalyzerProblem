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
            object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
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
                object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblemDifferent.MoodAnalyser", "MoodAnalyser");
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
                object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserDifferent");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: constructor not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 5.1 : Given mood analyser class name and message should create mood analyser parameterized object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassNameAndMessage_ReturnMoodAnalyserParameterizedObject()
        {
            //Arrange
            var expected = new MoodAnalyser("happy");
            //Act
            object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "happy");
            //Assert          
            expected.Equals(result);
        }

        /// <summary>
        /// UC 5.2 : Given an improper class name should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void UC5GivenImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblemDifferent.MoodAnalyser", "MoodAnalyser", "happy");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: class not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 5.3 : Given an improper constructor name should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void UC5GivenImproperConstructorName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserDifferent", "happy");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: constructor not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 6.1 : Given 'Happy' message when proper should return 'Happy Mood'.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_InvokeAnalyseMoodMethod_ShouldReturnHappyMoodMessage()
        {
            //Arrange
            string expected = "Happy Mood";
            //Act
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMood");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC 6.2 : Given Improper method name must return mood analyser custom exception
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenImproperMethod_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMoodDifferent");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: method not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 7.1 : Set HAPPY messsage with reflector should return HAPPY
        /// </summary>
        [TestMethod]
        public void GivenHAPPYMessage_WithReflector_ShouldReturnHAPPY()
        {
            //Arrange
            string expected = "HAPPY";
            //Act
            string actual = MoodAnalyserReflector.SetField("HAPPY", "message");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC 7.2 : Setting improper field should throw exception NO_SUCH_FIELD
        /// </summary>
        [TestMethod]
        public void SetFieldWhenImproper_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserReflector.SetField("HAPPY", "mes");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 7.3 : Setting null messsage with reflection should throw NULL_MESSAGE exception
        /// </summary>
        [TestMethod]
        public void SetNullMessage_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserReflector.SetField(null, "message");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: Message should not be null", exception.Message);
            }
        }
    }
}