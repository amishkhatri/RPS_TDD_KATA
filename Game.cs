using System;
using System.Collections.Generic;
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

        private string _message;
        public string Message   
        {
            get { return _message; }
            set { _message = value; }
        }


        public string ExecuteRules()
        {
            string Result = "";

            Result = (ValidateFields()) ? (_rule.GetRuleResult(this.Player1, this.Player2)) : this.Message;

            return Result;
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
