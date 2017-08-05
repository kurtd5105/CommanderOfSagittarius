using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing names of various melee and ranged weapons along with adjectives and modifiers. Fits any fantasy game.
    public class WeaponNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "adj",    new List<string>(){
                                                    "Flaming_", "Burning_", "Electric_",
                                                    "Freezing_", "Ice_", "Dark_",
                                                    "Healing_", "Light_", "Heavy_",
                                                    "Poisoned_", "Toxic_", "Druid's_",
                                                    "Priest's_", "Warrior's_", "Archer's_",
                                                    "Wizard's_", "Dragon_", "Occult_",
                                                    "Divine_", "Enchanted_", "Magic_",
                                                    "Barbarian_", "Gladiator_", "Unholy_",
                                                    "Holy_", "Cursed_", "Blessed_", "Silver_",
                                                    "Iron_", "Steel_", "Golden_", "Bronze_",
                                                    "Skeletal_", "Bone_", "Soul_", "Masterwork_",
                                                    "Frost_", "Storm_", "Thunder_", "Fierce_",
                                                    "Lucky_", 
                                                    }
                },
                {
                    "items", new List<string>(){
                                                    "Axe_", "Sword_", "Bow_", "Polearm_", "Spear_",
                                                    "Greataxe_", "Dagger_", "Shortsword_", "Broadsword_",
                                                    "Shield_", "Greatshield_", "Zweihander_", "Claymore_",
                                                    "Crossbow_", "Blade_", "Mace_", "Hammer_", "Lucerne_",
                                                    "Katana_", "Hatchet_", "Scythe_", "Bludgeon_",
                                                    "Morningstar_", "Flail_", "Spellblade_", "Knife_",
                                                    "Reaver_", "Swiftblade_", "Saber_", "Rapier_",
                                                    "Longsword_", "Maul_", "War_Axe_", "Warhammer_",
                                                    "Mallet_", "Cleaver_", "Shiv_", "Dirk_", "Stiletto_",
                                                    "Halberd_", "Spike_", "Trident_", "Lance_", "Javelin_",
                                                }
                },
                {
                    "mods", new List<string>(){
                                                    "+1", "+2", "+3", "+4", "+5", "of_Slaying", "of Burning",
                                                    "of_Freezing", "of_Poisoning", "of_Dragon", "of_Magic",
                                                    "of_Killing", "of_Flaying", "of_Crushing", "of_Destruction",
                                                    "of_Healing", "of_Repairing", "of_Indigestion",
                                                    "of_Flying", "of_Striking", "of_Punishment", 
                                                    "of_Lightning", "of_Thunder", "of_Venom", "of_Pain", "of_Acid",
                                                    "of_Poison", "of_Dreams", "of_Nightmares", "of_Stars", "of_the_Kings",
                                                    "of_Legend", "of_Death", "of_Life", "of_Luck", "of_the_Night",
                                                    "of_Darkness",
                                            }
                }
            };

        private static List<string> rules = new List<string>()
            {
                "%100items", "%75adj%100items%75mods", "%33adj%100items%100mods", "%100adj%100items%33mods"
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }   
    }
}
