using System.Collections.Generic;
using Characters;
using Cards;

namespace Campaign {
    public interface iCampaignEvent {
        void execute(Character Character, List<CardData> Deck);
    }
}