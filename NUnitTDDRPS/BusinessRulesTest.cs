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
            game.Player1 = game.Player2 = string.Empty;
            
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
        public void ShouldReturn_Pass_When_Player1_Rock_Player2_Scissors_Return_Player1()
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

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Tie_Result_Tie()
        {
            game.Round1Winner = "TIE";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();

            Assert.AreEqual("TIE",result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Tie_Result_Tie_And_Message_Tie()
        {
            game.Round1Winner = "TIE";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();
            Assert.AreEqual("TIE", game.RoundMessage);
        }


        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Player1_Result_P1()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "PLAYER1";
            game.Round3Winner = "PLAYER1";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P1", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Player1_Result_P1_And_Message_All_Games_Won_By_P1()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "PLAYER1";
            game.Round3Winner = "PLAYER1";

            var result = game.FindRoundWinner();

            Assert.AreEqual("ALL GAMES WON BY P1", game.RoundMessage);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Player1_Result_P2()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "PLAYER2";
            game.Round3Winner = "PLAYER2";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P2", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_3_Player2_Result_P2_And_Message_All_Games_Won_By_P2()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "PLAYER2";
            game.Round3Winner = "PLAYER2";

            var result = game.FindRoundWinner();

            Assert.AreEqual("ALL GAMES WON BY P2", game.RoundMessage);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_Player1_Round_3_Player2_Result_P1()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "PLAYER1";
            game.Round3Winner = "PLAYER2";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P1", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_Player1_Round_3_Player2_Result_P1_Message_P1_Wins_Two_Games()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "PLAYER1";
            game.Round3Winner = "PLAYER2";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P1 WINS TWO GAMES", game.RoundMessage);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_Player1_Round_2_3_Tie_Result_P1()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P1", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_Player1_Round_2_3_Tie_Result_P1_Message_P1_WINS_ONE_GAMES()
        {
            game.Round1Winner = "PLAYER1";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P1 WINS ONE GAMES, OTHER GAMES ARE TIE", game.RoundMessage);
        }


        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_Player2_Round_3_Player1_Result_P2()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "PLAYER2";
            game.Round3Winner = "PLAYER1";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P2", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_2_Player2_Round_3_Player1_Result_P2_Message_P2_Wins_Two_Games()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "PLAYER2";
            game.Round3Winner = "PLAYER1";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P2 WINS TWO GAMES", game.RoundMessage);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_Player2_Round_2_3_Tie_Result_P2()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P2", result);
        }

        [Test]
        public void ShouldReturn_Pass_When_Round_1_Player2_Round_2_3_Tie_Result_P1_Message_P2_WINS_ONE_GAMES()
        {
            game.Round1Winner = "PLAYER2";
            game.Round2Winner = "TIE";
            game.Round3Winner = "TIE";

            var result = game.FindRoundWinner();

            Assert.AreEqual("P2 WINS ONE GAMES, OTHER GAMES ARE TIE", game.RoundMessage);
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            game = null;
        }
    }
}