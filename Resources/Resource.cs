using System.Collections;
using System.Collections.Generic;
using Saves;
using UnityEngine;
using Utils;

namespace Resources {
	public abstract class Resource {
		public string Name;
		public ResourceType Type;
		
		public int Amount;
		public int MaxAmount;

		public int PendingChange;

		public bool IsDisabled;

		public Color Color;
		
		public Resource(int amount, int maxAmount, string name, ResourceType type, Color color) {
			Name = name;
			Type = type;
			Color = color;
			SetAmount(amount);
			SetMaxAmount(maxAmount);
			IsDisabled = false;
		}

		public virtual Resource[] GetSubResources() {
			return null;
		}

		public virtual int GetAmount() {
			return Amount;
		}

		public virtual int GetPendingChange() {
			// +10 on 10/10 should show as +0
			// +10 on 3/10 should show as +7
			// +10 on 0/10 should show as +10
			return (Amount + PendingChange > MaxAmount) ? MaxAmount - Amount : PendingChange;
		}

		public virtual int GetMaxAmount() {
			return MaxAmount;
		}

		public virtual float GetCurrentPercent(int adjustment = 0) {
			return (float)(Amount + adjustment) / (float)MaxAmount;
		}

		public virtual float GetPendingPercent() {
			float newPercent = (float)(Amount + PendingChange) / (float)MaxAmount;
			if(newPercent > 1) {
				newPercent = 1;
			}
			return newPercent;
		}

		public virtual void SetMaxAmount(int maxAmount) {
			MaxAmount = maxAmount;
		}

		public virtual void SetAmount(int amount) {
			Amount = amount;
		}

		public virtual void SupplyResource(int addition, bool allowOverflow = false) {
			SetAmount(Amount + addition);

			if(!allowOverflow && Amount > MaxAmount) {
				Amount = MaxAmount;
			}
		}
		
		public virtual void DepleteResource(int depletion) {
			SetAmount(Amount - depletion);
		}

		public virtual void PayCost(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0) {
			DepleteResource(cost);
		}

		public virtual bool CanCostBePaid(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0) {
			return MeetsThreshold(cost, false, checkType, adjustment);
		}

		// 'above' is false if checking Resource is below threshold, otherwise true
        // Adjustment is used for "Check before cast amount" threshold checks
        // Otherwise, the threshold check will always be comparing a resource "post-cast" of this card
		public virtual bool MeetsThreshold(int threshold, bool isPercent, AmountCheckType checkType, int adjustment = 0) {
			var checkAmount = (isPercent) ? (GetCurrentPercent(adjustment) * 100f) : Amount + adjustment;
			bool output = false;
			switch(checkType) {
				case AmountCheckType.Not:
					output = checkAmount != threshold;
					break;
				case AmountCheckType.BelowNotEqual:
					output = checkAmount < threshold;
					break;
				case AmountCheckType.BelowOrEqual:
					output = checkAmount <= threshold;
					break;
				case AmountCheckType.AboveNotEqual:
					output = checkAmount > threshold;
					break;
				case AmountCheckType.AboveOrEqual:
					output = checkAmount >= threshold;
					break;
				case AmountCheckType.Exact:
				default:
					output = checkAmount == threshold;
					break;
			}

			return output;
		}

		public virtual ResourceSaveData GetResourceSaveData() {
			ResourceSaveData newResourceSaveData = new ResourceSaveData();
			newResourceSaveData.Type = this.Type;
			newResourceSaveData.MinOrCurrent = this.Amount;
			newResourceSaveData.Max = this.MaxAmount;

			return newResourceSaveData;
		}
	}
}