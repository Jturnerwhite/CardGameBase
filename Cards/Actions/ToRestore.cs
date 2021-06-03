using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToRestore : iAction {
        private int RestoreAmount { get; set; }
        private int CurrentAmount { get; set; }
        private int MaxAmount {get; set; }
        public ToRestore(int amount) {
            this.RestoreAmount = amount;
        }

        public void execute(List<Character> targets, Character source) {
            Resource resource = source.GetResource();
            this.MaxAmount = resource.GetMaxAmount();
            this.CurrentAmount = resource.GetAmount();

            if (CurrentAmount + RestoreAmount <= MaxAmount) {
                resource.SupplyResource(RestoreAmount);
            } else {
                resource.SetAmount(MaxAmount);
            }
        }
    }
}