using System;
using System.Collections.Generic;
using Resources;
using Characters;
using Utils;

namespace Cards.Actions {
    public class ChangeTarget : iAction {
        TargetType Target;
        public ChangeTarget(TargetType target) {
            Target = target;
        }

        public void execute(List<Character> targets, Character source) {
            ThePot res = (ThePot)source.GetResource();
            res.SetTarget(Target);
        }
    }
}