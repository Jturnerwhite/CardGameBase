using System;
using System.Collections.Generic;
using Characters;
using Characters.Classes;
using Cards;

namespace Campaign {
    public class ChangeClassAction : iCampaignAction {
        public CharacterClass? ClassType;

        public ChangeClassAction(CharacterClass type)
        {
            this.ClassType = type;
        }

        public ChangeClassAction(CampaignActionData serializedMapAction) {
            CharacterClass parsedClass;
            if(Enum.TryParse<CharacterClass>(serializedMapAction.Value, true, out parsedClass)) {
                this.ClassType = parsedClass;
            } else {
                this.ClassType = null;
            }
        }

        public void execute(Character character, List<CardData> deck) {
            character.CharacterClass = this.ClassType ?? character.CharacterClass;
            // maybe force change of specific cards?
            RunManager.Save(character, deck);
        }
    }
}