using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing names of various pieces of armor along with adjectives and modifiers. Fits any fantasy game.
    public class ArmorNames : BaseNames
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
                                                    "Chestplate_", "Bevor_", "Chainmail_", "Gambeson_",
                                                    "Gousset_", "Greaves_", "Chausses_", "Hauberk_",
                                                    "Lamellar_Armor_", "Laminar_Armor_", "Plackart_",
                                                    "Breastplate_", "Platemail_", "Plate_Armor_", 
                                                    "Ring_Armor_", "Sabaton_", "Scale_Armor", 
                                                    "Pauldrons_", "Vambrace_", "Leather_Armor_",
                                                    "Chestguard_", "Chestpiece_", "Cuirass_", 
                                                    "Helmet_", "Headguard_", "Faceguard_", "Mask_",
                                                    "Leggings_", "Legguards_", "Platelegs_", 
                                                    "Mantle_", "Shoulderguards_", "Warboots_",
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
