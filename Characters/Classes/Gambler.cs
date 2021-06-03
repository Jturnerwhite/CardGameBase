using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	// placeholder
	public class Gambler : Character {

		public List<Die> Dice;

		public Gambler() : base("Gambler") {
			Dice = new List<Die>();
			Dice.Add(new Die(0, 6));
		}

		public override Resource GetResource() {
			return Dice[0];
		}

		public override List<Resource> GetAllResources() {
			List<Resource> output = new List<Resource>();
			output.AddRange(Dice);
			return output;
		}

		public override bool CanCastCard(Card card) {
			return GetDieToConsume(card) != null;
		}

		public override void CastCard(Card card, List<Character> targets) {
			Die dieToConsume = GetDieToConsume(card);
			if(dieToConsume != null) {
				dieToConsume.PayCost(card.Cost);
			}
		}

		private Die GetDieToConsume(Card card) {
			foreach(var die in Dice) {
				if (die.CanCostBePaid(card.Cost)) {
					return die;
				}
			}

			return null;
		}
	}
}
