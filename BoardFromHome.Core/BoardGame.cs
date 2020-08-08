using System;
using System.Collections.Generic;
using System.Text;

namespace BoardFromHome.Core
{
    public enum gameType
    {
        board,
        card,
        dice
    }
    public class BoardGame
    {
        public int id { get; set; }
        public string name { get; set; }
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public gameType gameType { get; set; }
        public string usersInGame { get; set; }
        public Dictionary<string,int> uniqueItemAmounts { get; set; }
        public string serializedUniqueItemAmounts { get; set; }//Format will be string:int,
        public List<Component> ruleSet { get; set; }
        public string serializedRuleSet { get; set; }//Format will be rule + ,
        public void serializeRuleSet()
        {
            this.serializedRuleSet = "";
            foreach(Component rule in ruleSet)
            {
                serializedRuleSet += rule.eventTrigger + "|" + rule.outcome + ",";
            }
        }
        public void serializeUniqueItemAmounts()
        {
            this.serializedUniqueItemAmounts = "";
            foreach(var valuePair in uniqueItemAmounts.Keys)
            {
                this.serializedUniqueItemAmounts += valuePair + ":" + uniqueItemAmounts[valuePair] + ",";
            }
        }
        public void deSerializeRules()
        {
            this.ruleSet = new List<Component>();
            foreach(string component in this.serializedRuleSet.Split(','))
            {
                this.ruleSet.Add(new Component(component.Split('|')[0], component.Split('|')[1]));
            }
        }
        public void deSerializeUniqueItems()
        {
            this.uniqueItemAmounts = new Dictionary<string, int>();
            foreach(string keyValPair in this.serializedUniqueItemAmounts.Split(','))
            {
                this.uniqueItemAmounts.Add(keyValPair.Split(':')[0], int.Parse(keyValPair.Split(':')[1]));
            }
        }
    }
    
}
