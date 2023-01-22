using Resources;
using Utils;

namespace Cards {
    public class Cost : CostData {
        public Cost(int Amount, AmountCheckType ct = AmountCheckType.AboveOrEqual, AmountCheckType dct = AmountCheckType.Exact, ResourceType? type = null) {
            this.Amount = Amount;
            this.AmountCheckType = ct;

            // Used as base functionality has standard resource pools for paying costs
            // You need at least X to cast card, and you only pay exactly X;
            this.DisplayCheckType = dct;

            // Some cards may take specific types of resources
            this.ResourceType = type;
        }

        public Cost(CostData data) {
            this.Amount = data.Amount;
            this.AmountCheckType = data.AmountCheckType;
            this.DisplayCheckType = data.DisplayCheckType;
            this.ResourceType = data.ResourceType;
        }

        public override string ToString() {
            switch(DisplayCheckType) {
                case AmountCheckType.AboveNotEqual:
                    return ">" + Amount;
                case AmountCheckType.AboveOrEqual:
                    return ">=" + Amount;
                case AmountCheckType.BelowNotEqual:
                    return "<" + Amount;
                case AmountCheckType.BelowOrEqual:
                    return "<=" + Amount;
                case AmountCheckType.Not:
                    return "≠" + Amount;
                case AmountCheckType.Exact:
                default:
                    return Amount.ToString();

            }
        }
    }
}