//using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Xp.TDD.Rps.BusinessLogic
{
    public class Rule
    {
        public System.Collections.Generic.Dictionary<(string, string), string> Rules 
            = new Dictionary<(string, string), string>();

        public System.Collections.Generic.Dictionary<(string, string, string), List<string>> RoundRules 
            = new Dictionary<(string, string,string), List<string>>();
        

        public Rule()
        {
            Rules.Add(("Paper", "Paper"), "Tie");
            Rules.Add(("Rock", "Scissors"), "Player1");
            Rules.Add(("Rock", "Paper"), "Player2");
            Rules.Add(("Scissors", "Paper"), "Player1");
            Rules.Add(("Scissors", "Rock"), "Player2");
            Rules.Add(("Paper", "Rock"), "Player1");
            Rules.Add(("Paper", "Scissors"), "Player2");

            RoundRules.Add(("TIE", "TIE", "TIE"),new List<string>() {"TIE","TIE"});
            RoundRules.Add(("PLAYER1", "PLAYER1", "PLAYER1"), new List<string>() { "P1", "ALL GAMES WON BY P1" });
            RoundRules.Add(("PLAYER2", "PLAYER2", "PLAYER2"), new List<string>() { "P2", "ALL GAMES WON BY P2" });
            RoundRules.Add(("PLAYER1", "PLAYER1", "PLAYER2"), new List<string>() { "P1", "P1 WINS TWO GAMES" });
            RoundRules.Add(("PLAYER1", "TIE", "TIE"), new List<string>() { "P1", "P1 WINS ONE GAMES, OTHER GAMES ARE TIE" });
            RoundRules.Add(("PLAYER2", "PLAYER2", "PLAYER1"), new List<string>() { "P2", "P2 WINS TWO GAMES" });
            RoundRules.Add(("PLAYER2", "TIE", "TIE"), new List<string>() { "P2", "P2 WINS ONE GAMES, OTHER GAMES ARE TIE" });
        }
        
        public string GetRuleResult(string PlayerItemA,string PlayerItemB)
        {
            string result= string.Empty;

            try
            {
                return (Rules.TryGetValue((PlayerItemA, PlayerItemB), out result)) ? result : string.Empty;                
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
            
        }

        public List<string> GetRoundRuleResult(string Round1Winner, string Round2Winner,string Round3Winner)
        {   
            List<string> results = new List<string>();

            try
            {              
                    if (RoundRules.ContainsKey((Round1Winner, Round2Winner, Round3Winner)))
                        RoundRules.TryGetValue((Round1Winner, Round2Winner, Round3Winner), out results);

                return results;
               
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

    }
}
