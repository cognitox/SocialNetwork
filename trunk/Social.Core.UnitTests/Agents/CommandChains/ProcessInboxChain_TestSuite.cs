using Moq;
using NUnit.Framework;
using Social.Core.Agents.CommandChains;
using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.UnitTests.Agents.CommandChains
{

    [TestFixture]
    public class ProcessInboxChain_TestSuite
    {
        #region Success Tests

        [Test]
        public void EmailCommandSuccess_Test()
        {
            //arrange
            Int32 execCounter = 0;
            Int32 rollbackCounter = 0;

            //mock up the counters
            var mockEmailCommandPass = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandPass.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                execCounter++;
            });
            mockEmailCommandPass.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                rollbackCounter++;
            });

            var mockEmailCommandFail = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandFail.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback<EmailCommandArgs>((a) =>
            {
                a.IsSuccessful = false;
                execCounter++;
            });
            mockEmailCommandFail.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {

                rollbackCounter++;
            });

            var chain = new ProcessInboxChain();
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            var args = new EmailCommandArgs(null, null, null, 0, false);

            //act
            chain.ExecuteChain(args);

            //assert
            Assert.IsTrue(args.IsSuccessful);
            Assert.IsTrue(execCounter == 4);
            Assert.IsTrue(rollbackCounter == 0);
        }

        #endregion

        #region Failed Tests

        [Test]
        public void EmailCommandRollback_LastCommandFailed_Test()
        {
            //arrange
            Int32 execCounter = 0;
            Int32 rollbackCounter = 0;

            //mock up the counters
            var mockEmailCommandPass = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandPass.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                execCounter++;
            });
            mockEmailCommandPass.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                rollbackCounter++;
            });

            var mockEmailCommandFail = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandFail.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback<EmailCommandArgs>((a) =>
            {
                a.IsSuccessful = false;
                execCounter++;
            });
            mockEmailCommandFail.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {

                rollbackCounter++;
            });


            var chain = new ProcessInboxChain();
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandFail.Object);
            var args = new EmailCommandArgs(null, null, null, 0, false);

            //act
            chain.ExecuteChain(args);

            //assert
            mockEmailCommandFail.VerifyAll();
            mockEmailCommandPass.VerifyAll();
            Assert.IsFalse(args.IsSuccessful);
            Assert.IsTrue(execCounter == 4);
            Assert.IsTrue(rollbackCounter == 4);
        }

        [Test]
        public void EmailCommandRollback_SecondToLastCommandFailed_Test()
        {
            //arrange
            Int32 execCounter = 0;
            Int32 rollbackCounter = 0;

            //mock up the counters
            var mockEmailCommandPass = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandPass.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                execCounter++;
            });
            mockEmailCommandPass.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                rollbackCounter++;
            });

            var mockEmailCommandFail = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandFail.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback<EmailCommandArgs>((a) =>
            {
                a.IsSuccessful = false;
                execCounter++;
            });
            mockEmailCommandFail.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {

                rollbackCounter++;
            });

            var chain = new ProcessInboxChain();
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandFail.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            var args = new EmailCommandArgs(null, null, null, 0, false);

            //act
            chain.ExecuteChain(args);

            //assert
            mockEmailCommandFail.VerifyAll();
            mockEmailCommandPass.VerifyAll();
            Assert.IsFalse(args.IsSuccessful);
            Assert.IsTrue(execCounter == 3);
            Assert.IsTrue(rollbackCounter == 3);
        }

        [Test]
        public void EmailCommandRollback_FirstCommandFailed_Test()
        {
            //arrange
            Int32 execCounter = 0;
            Int32 rollbackCounter = 0;

            //mock up the counters
            var mockEmailCommandPass = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandPass.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                execCounter++;
            });
            mockEmailCommandPass.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                rollbackCounter++;
            });

            var mockEmailCommandFail = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandFail.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback<EmailCommandArgs>((a) =>
            {
                a.IsSuccessful = false;
                execCounter++;
            });
            mockEmailCommandFail.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {

                rollbackCounter++;
            });

            var chain = new ProcessInboxChain();
            chain.AddCommand(mockEmailCommandFail.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            var args = new EmailCommandArgs(null, null, null, 0, false);

            //act
            chain.ExecuteChain(args);

            //assert
            mockEmailCommandFail.VerifyAll();
            Assert.IsFalse(args.IsSuccessful);
            Assert.IsTrue(execCounter == 1);
            Assert.IsTrue(rollbackCounter == 1);

        }

        [Test]
        public void EmailCommandRollback_ExceptionThrow()
        {
            //arrange
            Int32 execCounter = 0;
            Int32 rollbackCounter = 0;

            //mock up the counters
            var mockEmailCommandPass = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandPass.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                execCounter++;
            });
            mockEmailCommandPass.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {
                rollbackCounter++;
            });

            var mockEmailCommandFail = new Mock<ICommand<EmailCommandArgs>>();
            mockEmailCommandFail.Setup(a => a.Execute(It.IsAny<EmailCommandArgs>())).Callback<EmailCommandArgs>((a) =>
            {
                execCounter++;
                //do not set the IsSuccessful flag, to false, that 
                //should be taken care of within the exception handler
                throw new Exception();
            });
            mockEmailCommandFail.Setup(a => a.RollBack(It.IsAny<EmailCommandArgs>())).Callback(() =>
            {

                rollbackCounter++;
            });

            var chain = new ProcessInboxChain();
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandPass.Object);
            chain.AddCommand(mockEmailCommandFail.Object);
            var args = new EmailCommandArgs(null, null, null, 0, false);

            //act
            chain.ExecuteChain(args);

            //assert
            mockEmailCommandFail.VerifyAll();
            mockEmailCommandPass.VerifyAll();
            Assert.IsFalse(args.IsSuccessful);
            Assert.IsTrue(execCounter == 4);
            Assert.IsTrue(rollbackCounter == 4);
            Assert.NotNull(args.Exception);
        }

        #endregion
    }
}
