using System;
using System.Collections.Generic;
using System.Text;

namespace BoardFromHome.Core
{
    public class Component
    {
        public string eventTrigger { get; set; }
        public string outcome { get; set; }
        public string serialize()
        {
            string serializedComponent = this.eventTrigger + "|" + this.outcome;
            return serializedComponent;
        }
        public void deSerialize(string serializedComponent)
        {
            this.eventTrigger = serializedComponent.Split('|')[0];
            this.outcome = serializedComponent.Split('|')[1];
        }
        public Component(string eventTrigger, string outcome)
        {
            this.eventTrigger = eventTrigger;
            this.outcome = outcome;
        }
    }
}
