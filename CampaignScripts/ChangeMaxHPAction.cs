using System;
using System.Collections.Generic;
using Characters;
using Cards;
using Characters.Classes;

namespace Campaign {
    public class ChangeMaxHPAction : iCampaignAction {
        public int Adjustment;

        public ChangeMaxHPAction(int value)
        {
            this.Adjustment = value;
        }

        public ChangeMaxHPAction(CampaignActionData serializedMapAction) {
            this.Adjustment = Int32.Parse(serializedMapAction.Value);
        }

        public void execute(Character character, List<CardData> deck) {
            character.HP.SetMaxAmount(character.HP.GetMaxAmount() + this.Adjustment);
            RunManager.Save(character, deck);
        }
    }
}