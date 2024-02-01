using System.Collections.Generic;
using Characters;
using Cards;
using System;
using UnityEngine;

namespace Campaign {
    public enum DeckModActionType {
        Addition,
        Removal,
        Duplication,
        Replacement
    }

    public class DeckModificationAction : iCampaignAction {
        public DeckModActionType Type;
        public CardData Card;
        public int? DeckIndex;

        public DeckModificationAction(DeckModActionType type, CardData card)
        {
            this.Type = type;
            this.Card = card;
        }

        public DeckModificationAction(DeckModActionType type, int? index = null)
        {
            this.Type = type;
            this.DeckIndex = index;
        }

        public DeckModificationAction(CampaignActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            DeckModActionType parsedType;
            Enum.TryParse<DeckModActionType>(values[0], true, out parsedType);

            CardData foundCard = CardFactory.GetCardData(values[1]);
            if(foundCard == null) {
                Debug.Log($"Error in DeckModificationAction trying to find card named: {values[1]}");
                return;
            }

            this.Card = foundCard;

            if(!String.IsNullOrEmpty(values[2])) {
                DeckIndex = Int32.Parse(values[2]);
            }
        }

        public void execute(Character character, List<CardData> deck) {
            int indexToUse = 0;
            if(DeckIndex == null) {
                indexToUse = new System.Random().Next(0, deck.Count - 1);
            }

            switch(Type)
            {
                case DeckModActionType.Addition:
                    deck.Add(Card);
                    break;
                case DeckModActionType.Removal:
                    deck.RemoveAt(indexToUse);
                    break;
                case DeckModActionType.Duplication:
                    CardData cardAtIndex = deck[indexToUse];
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
                case DeckModActionType.Replacement:
                    deck[indexToUse] = this.Card;
                    break;
                default:
                    break;
            }

            RunManager.Save(character, deck);
        }
    }
}