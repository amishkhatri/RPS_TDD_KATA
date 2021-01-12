using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace Xp.TDD.Rps.BusinessLogic
{

    public class Game
    {
        public readonly Rule _rule;

        public System.Collections.Generic.Dictionary<(string, string),string> Rules = new Dictionary<(string, string), string>();

        public Dictionary<(string, string), string> GetRules
        {
            get { return Rules; }
            set { Rules = value; }
        }
         
        public Game()
        {
            _rule = new Rule();
        }

        private string player1;
        public string Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        private string player2;
        public string Player2
        {
            get { return player2; }
            set { player2 = value; }
        }


        private string round1Winner;
        public string Round1Winner
        {
            get { return round1Winner; }
            set { round1Winner = value; }
        }

        private string round2Winner;
        public string Round2Winner
        {
            get { return round2Winner; }
            set { round2Winner = value; }
        }

        private string round3Winner;
        public string Round3Winner
        {
            get { return round3Winner; }
            set { round3Winner = value; }
        }

        private string _message;
        public string Message   
        {
            get { return _message; }
            set { _message = value; }
        }


        private string _roundMessage;
        public string RoundMessage
        {
            get { return _roundMessage; }
            set { _roundMessage = value; }
        }


        public string ExecuteRules()
        {
            var result = (ValidateFields()) ? (_rule.GetRuleResult(this.Player1, this.Player2)) : this.Message;

            return result;
        }

        public string FindRoundWinner()
        {
            string result = string.Empty;
            List<string> results = new List<string>();

            results = _rule.GetRoundRuleResult(this.Round1Winner, this.Round2Winner, this.Round3Winner);

            result= results.ElementAt(0);

            this.RoundMessage = results.ElementAt(1);

            return result;
        }
        
        
        private bool ValidateFields() 
        {

            if (string.IsNullOrEmpty(this.Player1) && string.IsNullOrEmpty(this.Player2))
            {
                this.Message = "All inputs are empty.";
                return false;
            }
            else if (string.IsNullOrEmpty(this.Player1))
            {
                this.Message = "Player1 input is empty.";
                return false;
            }
            else if (string.IsNullOrEmpty(this.Player2))
            {
                this.Message = "Player2 input is empty.";
                return false;
            }
            else
            {
                this.Message = string.Empty;
                return true;
            }
        }



    }
}
