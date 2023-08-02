using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Characters.Classes;
using Cards.Actions;
using Saves;


namespace StatusEffects {
    public static class StatusEffectFactory {
        public static List<StatusEffectData> BaseStatusEffects;
        public static StatusEffectData GetStatusEffectData(string name) {
            try {
                StatusEffectData match;

                if(BaseStatusEffects == null) {
                    BaseStatusEffects = new List<StatusEffectData>();
                } else {
                    match = BaseStatusEffects.Find(x => x.Name == name);
                    if(match != null) {
                        return match;
                    }
                }

                string[] matchingNames = AssetDatabase.FindAssets(name, new[] { "Assets/Resources/Scriptables/SerializedStatusEffects" });

                string path = AssetDatabase.GUIDToAssetPath(matchingNames[0]);
                match = AssetDatabase.LoadAssetAtPath<StatusEffectData>(path);
                if(match != null) {
                    BaseStatusEffects.Add(match);
                    return match;
                }
            } catch(Exception e) {
                Debug.LogError($"ERROR: StatusEffectFactory.GetEffect() effect not found: {name}");
                Debug.LogError(e.Message);
            }

            return null;
        }
    
        public static StatusEffect GetStatusEffect(string name, int count = 0) {
            StatusEffectData baseData = GetStatusEffectData(name);
            if(baseData == null) {
                return null;
            }

            return new StatusEffect(name, baseData, count);
        }
    }
}