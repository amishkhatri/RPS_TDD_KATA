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
        public void ShouldReturn_Fail_When_PlayerA_Empty_PlayerB_Empty()
        {
            game.Player1 = "";
            game.Player2 = "";

            var result = game.ExecuteRules();

            Assert.AreEqual("All inputs are empty.", result);

        }


        [Test]
        public void ShouldReturn_Fail_When_PlayerA_Empty_PlayerB_Non_Empty()
        {
            game.Player1 = "";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player1 input is empty.", result);

        }

        [Test]
        public void ShouldReturn_Fail_When_PlayerA_NonEmpty_PlayerB_Empty()
        {
            game.Player1 = "Paper";
            game.Player2 = "";

            var result = game.ExecuteRules();

            Assert.AreEqual("Player2 input is empty.", result);

        }


        [Test]
        public void ShouldReturn_Pass_When_PlayerA_Paper_PlayerB_Paper_Return_Tie()
        {
            game.Player1 = "Paper";
            game.Player2 = "Paper";

            var result = game.ExecuteRules();

            Assert.AreEqual("Tie", result);

        }
    }
}