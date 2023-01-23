using Characters.Classes;
using Characters.Enemies;
using Saves;

namespace Characters {
    public static class CharacterFactory {
        public static Character Get(CharacterClass type) {
            switch(type) {
                case CharacterClass.Zealot:
                    return new Zealot();
                case CharacterClass.Vanguard:
                    return new Vanguard();
                case CharacterClass.Gambler:
                    return new Gambler();
                case CharacterClass.Warrior:
                default:
                    return new Warrior();
            }
        }

        public static Character Get(CharacterSaveData data) {
            Character newCharacter;
            switch(data.CharacterClass) {
                case CharacterClass.Zealot:
                    newCharacter = new Zealot();
                    break;
                case CharacterClass.Vanguard:
                    newCharacter = new Vanguard();
                    break;
                case CharacterClass.Gambler:
                    newCharacter = new Gambler();
                    break;
                case CharacterClass.Warrior:
                default:
                    newCharacter = new Warrior();
                    break;
            }

            newCharacter.SetFromSave(data);
            return newCharacter;
		}

        public static Character Get(EnemyType type) {
            switch(type) {
                case EnemyType.Basic:
                default:
                    return new BasicEnemy();
            }
        }
    }
}