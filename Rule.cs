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
        }
        
        public string GetRuleResult(string ItemA,string ItemB)
        {
            string result="";
            try
            {
                return (Rules.TryGetValue((ItemA, ItemB), out result)) ? result : string.Empty;
                
            }
            catch(System.Exception ex)
            {
                throw ex;

            }
            
        }

    }
}
