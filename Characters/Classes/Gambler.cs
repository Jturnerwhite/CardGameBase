using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	// placeholder
	public class Gambler : Character {

		public DiceWrapper Dice;

		public Gambler(string name = "Gambler", int initialHP = 20) : base(name, initialHP, CharacterClass.Gambler) {
			Dice = new DiceWrapper(2, 5);
		}

		public override Resource GetResource() {
			return Dice;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> output = new List<Resource>();
			output.Add(Dice);
			return output;
		}

		public override bool CanCastCard(Card card) {
			return Dice.CanCostBePaid(card.Cost.Amount, card.Cost.AmountCheckType);
		}

		public override void CastCard(Card card, List<Character> targets) {
			Dice.PayCost(card.Cost.Amount, card.Cost.AmountCheckType);
			CardManager.CastCard(card);
		}

		public override void StartTurnTrigger() {
			Dice.RollAll();
			CardManager.DrawHand(3);
		}    
	}
}
