using System.Collections.Generic;
using Characters;
using Cards;

namespace Campaign {
    public enum DeckModEventType {
        Addition,
        Removal,
        Duplication,
        Replacement
    }

    public class DeckModificationEvent : iCampaignEvent {
        public DeckModEventType Type;
        public int DeckIndex;
        public CardData Card;

        public DeckModificationEvent(DeckModEventType type, CardData card)
        {
            this.Type = type;
            this.Card = card;
        }

        public DeckModificationEvent(DeckModEventType type, int index)
        {
            this.Type = type;
            this.DeckIndex = index;
        }

        public void execute(Character character, List<CardData> deck) {
            switch(Type)
            {
                case DeckModEventType.Addition:
                    deck.Add(Card);
                    break;
                case DeckModEventType.Removal:
                    deck.RemoveAt(DeckIndex);
                    break;
                case DeckModEventType.Duplication:
                    CardData cardAtIndex = deck[DeckIndex];
                    deck.Add(new CardData() {
                        Name = cardAtIndex.Name,
                        Cost = cardAtIndex.Cost,
                        CardType = cardAtIndex.CardType,
                        TargetsNeeded = cardAtIndex.TargetsNeeded,
                        Description = cardAtIndex.Description,
                        Actions = cardAtIndex.Actions,
                        AdditionalCosts = cardAtIndex.AdditionalCosts,
                    });
                    break;
                case DeckModEventType.Replacement:
                    deck[DeckIndex] = this.Card;
                    break;
                default:
                    break;
            }

            RunManager.Save(character, deck);
        }
    }
}