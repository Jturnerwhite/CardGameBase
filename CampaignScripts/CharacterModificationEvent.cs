using System;
using System.Collections.Generic;
using Characters;
using Cards;
using Characters.Classes;

namespace Campaign {
    public enum CharacterModEventType {
        ChangeName,
        ChangedClass,
        ChangeMaxHP,
    }

    public class CharacterModificationEvent : iCampaignEvent {
        public CharacterModEventType Type;
        public string Value;

        public CharacterModificationEvent(CharacterModEventType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public void execute(Character character, List<CardData> deck) {
            switch(Type)
            {
                case CharacterModEventType.ChangeName:
                    character.Name = Value;
                    break;
                case CharacterModEventType.ChangedClass:
                    CharacterClass? parsedClass = Enum.Parse<CharacterClass>(Value, true);
                    character.CharacterClass = parsedClass ?? character.CharacterClass;
                    break;
                case CharacterModEventType.ChangeMaxHP:
                    int adjustment = Int32.Parse(Value);
                    character.HP.SetMaxAmount(character.HP.GetMaxAmount() + adjustment);
                    break;
                default:
                    break;
            }

            RunManager.Save(character, deck);
        }
    }
}