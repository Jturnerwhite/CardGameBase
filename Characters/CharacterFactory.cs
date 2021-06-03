using Characters.Classes;

namespace Characters {
    public static class CharacterFactory {
        public static Character Get(CharacterClass type) {
            switch(type) {
                case CharacterClass.Zealot:
                    return new Zealot();
                case CharacterClass.Warrior:
                default:
                    return new Warrior();
            }
        }
    }
}