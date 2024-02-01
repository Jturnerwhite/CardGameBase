using System;
using System.Collections.Generic;
using Characters;
using Cards;
using Characters.Classes;

namespace Campaign {
    public class ChangeNameAction : iCampaignAction {
        public string Name;

        public ChangeNameAction(string name)
        {
            this.Name = name;
        }

        public ChangeNameAction(CampaignActionData serializedMapAction) {
            this.Name = serializedMapAction.Value;
        }

        public void execute(Character character, List<CardData> deck) {
            character.Name = this.Name;
            RunManager.Save(character, deck);
        }
    }
}