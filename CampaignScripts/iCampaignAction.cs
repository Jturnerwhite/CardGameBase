using System.Collections.Generic;
using Characters;
using Cards;

namespace Campaign {
    public interface iCampaignAction {
        void execute(Character Character, List<CardData> Deck);
    }
}