using System;

namespace Utils {

	[Serializable]
	public enum AmountCheckType {
		Not,
		Exact,
		BelowNotEqual,
		BelowOrEqual,
		AboveNotEqual,
		AboveOrEqual
	}

	[Serializable]
	public enum TargetType {
		Random,
		RandomEnemy,
		RandomAlly,
		All,
		AllEnemy,
		AllAlly,
		Single,
		Self
	}
}