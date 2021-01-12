using NUnit.Framework;
using Xp.TDD.Rps.BusinessLogic;

namespace NUnitTDDRPS
{
    public class Tests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();            
        }

        [Test]
        public void ShouldReturn_Fail_When_Player1_Empty_Player2_Empty()
        {
            game.Player1 = "";
            game.Player2 = "";

            var result = game.ExecuteRules();

            Assert.AreEqual("All inputs are empty.", result);

        }

        [Test]
        public void ShouldReturn_Fail_When_Player1_Empty_Player2_Non_Empty()
        {
            game.Player1 = "";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player1 input is empty.", result);

        }

        [Test]
        public void ShouldReturn_Fail_When_Player1_NonEmpty_Player2_Empty()
        {
            game.Player1 = "Paper";
            game.Player2 = "";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player2 input is empty.", result);

        }

        [Test]
        public void ShouldReturn_Pass_When_Player1_Paper_Player2_Paper_Return_Tie()
        {
            game.Player1 = "Paper";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Tie", result);

        }

        [Test]
        public void ShouldReturn_Pass_When_Player1_Rock_Player2_Scissors_Return_Player2()
        {
            game.Player1 = "Rock";
            game.Player2 = "Scissors";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player1", result);

        }


        [Test]
        public void ShouldReturn_Pass_When_Player1_Rock_Player2_Paper_Return_Player2()
        {
            game.Player1 = "Rock";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player2", result);

        }


        [Test]
        public void ShouldReturn_Pass_When_Player1_Scissors_Player2_Paper_Return_Player1()
        {
            game.Player1 = "Scissors";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player1", result);

        }

        [Test]
        public void ShouldReturn_Pass_When_Player1_Scissors_Player2_Rock_Return_Player2()
        {
            game.Player1 = "Scissors";
            game.Player2 = "Rock";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player2", result);

        }

        [Test]
        public void ShouldReturn_Pass_When_Player1_Paper_Player2_Rock_Return_Player1()
        {
            game.Player1 = "Paper";
            game.Player2 = "Rock";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player1", result);

        }

        [Test]
        public void ShouldReturn_Pass_When_Player1_Paper_Player2_Scissors_Return_Player2()
        {
            game.Player1 = "Paper";
            game.Player2 = "Scissors";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player2", result);

        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            game = null;
        }
    }
}