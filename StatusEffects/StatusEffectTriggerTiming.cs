using System;


namespace StatusEffects {
    [Serializable]
    public enum StatusEffectTriggerTiming {
        OnTurnStart,
        OnSourceCast,
        OnEnemyCast,
        OnTurnEnd,
    }
}