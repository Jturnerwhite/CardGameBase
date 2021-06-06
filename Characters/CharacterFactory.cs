using Characters.Classes;
using Characters.Enemies;

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

        public static Character Get(EnemyType type) {
            switch(type) {
                case EnemyType.Basic:
                default:
                    return new BasicEnemy();
            }
        }
    }
}