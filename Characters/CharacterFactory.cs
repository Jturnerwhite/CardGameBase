using System.Collections.Generic;
using System.Linq;
using Characters.Classes;
using Characters.Enemies;
using Saves;
using Utils;

namespace Characters {
    public static class CharacterFactory {
        public static Character Get(CharacterClass type) {
            Character newCharacter;
            switch(type) {
                case CharacterClass.Zealot:
                    newCharacter = new Zealot();
                    break;
                case CharacterClass.Vanguard:
                    newCharacter = new Vanguard();
                    break;
                case CharacterClass.Gambler:
                    newCharacter = new Gambler();
                    break;
                case CharacterClass.Potentate:
                    newCharacter = new Potentate();
                    break;
                case CharacterClass.Warrior:
                default:
                    newCharacter = new Warrior();
                    break;
            }

            return newCharacter;
        }

        public static Character Get(CharacterSaveData data) {
            Character newCharacter = Get(data.CharacterClass);
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
    
        public static List<Character> GetTargets(List<Character> potentialTargets, Character source, TargetType type) {
            List<Character> actualTargets = new List<Character>();
            System.Random rng = new System.Random();

            switch(type) {
                case TargetType.Random:
                    actualTargets.Add(potentialTargets.ElementAt(rng.Next(0, potentialTargets.Count)));
                    break;
                case TargetType.RandomAlly:
                    actualTargets.Add(potentialTargets.Where(x => x.CharacterClass != CharacterClass.None).ElementAt(rng.Next(0, potentialTargets.Count)));
                    break;
                case TargetType.RandomEnemy:
                    actualTargets.Add(potentialTargets.Where(x => x.CharacterClass == CharacterClass.None).ElementAt(rng.Next(0, potentialTargets.Count)));
                    break;
                case TargetType.All:
                    actualTargets.AddRange(potentialTargets);
                    break;
                case TargetType.AllAlly:
                    actualTargets.AddRange(potentialTargets.Where(x => x.CharacterClass != CharacterClass.None));
                    break;
                case TargetType.AllEnemy:
                    actualTargets.AddRange(potentialTargets.Where(x => x.CharacterClass == CharacterClass.None));
                    break;
                case TargetType.Self:
                    actualTargets.Add(source);
                    break;
                case TargetType.Single:
                default:
                    actualTargets.Add(potentialTargets[0]);
                    break;
            }

            return actualTargets;
        }
    }
}