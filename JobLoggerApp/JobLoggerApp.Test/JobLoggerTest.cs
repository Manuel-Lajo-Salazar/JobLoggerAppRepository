using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLoggerApp.Test
{
    [TestClass]
    public class JobLoggerTest
    {
        private JobLogger logger;
        
        [TestMethod]
        public void JobLoggerMustLogMessageToFile()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to File and logg only Messages
            logger = new JobLogger(true, false, false, true, false, false);
            Message msg = new Message { Text = "Message to File - Test", Type = Constant.MessageType.Message };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogWarningToFile()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to File and logg only Warnings
            logger = new JobLogger(true, false, false, false, true, false);
            Message msg = new Message { Text = "Warning to File - Test", Type = Constant.MessageType.Warning };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogErrorToFile()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to File and logg only Errors
            logger = new JobLogger(true, false, false, false, false, true);
            Message msg = new Message { Text = "Error to File - Test", Type = Constant.MessageType.Error };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogMessageToConsole()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to Console and logg only Messages
            logger = new JobLogger(false, true, false, true, false, false);
            Message msg = new Message { Text = "Message to Console - Test", Type = Constant.MessageType.Message };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogWarningToConsole()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to Console and logg only Warnings
            logger = new JobLogger(false, true, false, false, true, false);
            Message msg = new Message { Text = "Warning to Console - Test", Type = Constant.MessageType.Warning };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogErrorToConsole()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to Console and logg only Errors
            logger = new JobLogger(false, true, false, false, false, true);
            Message msg = new Message { Text = "Error to Console - Test", Type = Constant.MessageType.Error };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogMessageToDataBase()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to DataBase and logg only Messages
            logger = new JobLogger(false, false, true, true, false, false);
            Message msg = new Message { Text = "Message to DataBase - Test", Type = Constant.MessageType.Message };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogWarningToDataBase()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to DataBase and logg only Warnings
            logger = new JobLogger(false, false, true, false, true, false);
            Message msg = new Message { Text = "Warning to DataBase - Test", Type = Constant.MessageType.Warning };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogErrorToDataBase()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to DataBase and logg only Errors
            logger = new JobLogger(false, false, true, false, false, true);
            Message msg = new Message { Text = "Error to DataBase - Test", Type = Constant.MessageType.Error };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && successLog);
        }

        [TestMethod]
        public void JobLoggerMustLogMessageToFileAndFail()
        {
            // Arrange
            bool success = false;
            bool successLog = false;
            //configuration: logg only to File and logg only Warnings
            logger = new JobLogger(true, false, false, false, true, false);
            Message msg = new Message { Text = "Message to File - Test", Type = Constant.MessageType.Message };
            // Act
            try
            {
                successLog = logger.Log(msg);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            // Assert
            Assert.IsTrue(success && !successLog);
        }
        
        [TestMethod]
        public void JobLoggerMustLogMessageToFileAndThrowExceptionWithEmptyMessageMessage()
        {
            // Arrange
            bool success = false;
            string exceptionMessage = string.Empty;
            //configuration: logg only to File and logg only Messages
            logger = new JobLogger(true, false, false, true, false, false);
            Message msg = new Message { Text = "", Type = Constant.MessageType.Message };
            // Act
            try
            {
                logger.Log(msg);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                exceptionMessage = e.Message;
            }
            // Assert
            Assert.IsTrue(!success && exceptionMessage.Equals("Message must contain some text"));
        }

        [TestMethod]
        public void JobLoggerMustLogMessageToFileAndThrowExceptionWithInvalidConfigurationMessage()
        {
            // Arrange
            bool success = false;
            string exceptionMessage = string.Empty;
            //configuration: logg only to File but don't logg any type of Message
            logger = new JobLogger(true, false, false, false, false, false);
            Message msg = new Message { Text = "Message to File", Type = Constant.MessageType.Message };
            // Act
            try
            {
                logger.Log(msg);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                exceptionMessage = e.Message;
            }
            // Assert
            Assert.IsTrue(!success && exceptionMessage.Equals("Invalid configuration"));
        }
            
        [TestMethod]
        public void JobLoggerMustLogMessageToFileAndThrowExceptionWithUnespecifiedTypeMessage()
        {
            // Arrange
            bool success = false;
            string exceptionMessage = string.Empty;
            //configuration: logg only to File and logg only Messages
            logger = new JobLogger(true, false, false, true, false, false);
            Message msg = new Message { Text = "Message to File", Type = null };
            // Act
            try
            {
                logger.Log(msg);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                exceptionMessage = e.Message;
            }
            // Assert
            Assert.IsTrue(!success && exceptionMessage.Equals("Type of message must be specified"));
        }

    }
}