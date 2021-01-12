using System.Collections.Generic;

namespace Xp.TDD.Rps.BusinessLogic
{
    public class Rule
    {
        public System.Collections.Generic.Dictionary<(string, string), string> Rules = new Dictionary<(string, string), string>();

        public Rule()
        {
            Rules.Add(("Paper", "Paper"), "Tie");
            Rules.Add(("Rock", "Scissors"), "Player1");
            Rules.Add(("Rock", "Paper"), "Player2");
            Rules.Add(("Scissors", "Paper"), "Player1");
            Rules.Add(("Scissors", "Rock"), "Player2");
            Rules.Add(("Paper", "Rock"), "Player1");
            Rules.Add(("Paper", "Scissors"), "Player2");

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

    }
}
