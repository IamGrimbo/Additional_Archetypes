using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using TabletopTweaks.Core.Utilities;
using Additional_Archetypes.Classes.Fighter.Archetypes;
using System.Collections.Generic;
using System.Linq;

namespace Additional_Archetypes.Classes.Fighter
{
    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    internal class Fighter
    {
        static internal BlueprintCharacterClass FighterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
        static internal BlueprintProgression FighterProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("b50e94b57be32f74892f381ae2a8905a");
        static internal BlueprintStatProgression FighterBaseAttackBonusStatProgression = BlueprintTools.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        static internal BlueprintStatProgression FortitudeStatProgression = BlueprintTools.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");
        static internal BlueprintStatProgression ReflexStatProgression = BlueprintTools.GetBlueprint<BlueprintStatProgression>("dc0c7c1aba755c54f96c089cdf7d14a3");
        static internal BlueprintStatProgression WillStatProgression = BlueprintTools.GetBlueprint<BlueprintStatProgression>("dc0c7c1aba755c54f96c089cdf7d14a3");
        static internal BlueprintFeatureSelection FighterFeatureSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("41c8486641f7d6d4283ca9dae4147a9f");
        static internal BlueprintFeature FighterProficiencies = BlueprintTools.GetBlueprint<BlueprintFeature>("a23591cc77086494ba20880f87e73970");
        static internal BlueprintFeature BraveryFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("f6388946f9f472f4585591b80e9f2452");
        static internal BlueprintFeature ArmorTrainingFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
        static internal BlueprintFeature ArmorMasteryFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("ae177f17cfb45264291d4d7c2cb64671");
        static internal BlueprintFeatureSelection WeaponTrainingFeatureSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b8cecf4e5e464ad41b79d5b42b76b399");
        static internal BlueprintFeatureSelection WeaponTrainingRankUpFeatureSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5f3cc7b9a46b880448275763fe70c0b0");
        static internal BlueprintFeature WeaponMasteryFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("73c471386ce917c4c8c9f70d46b48eeb");

        internal static void Configure()
        {
            MutationTitanFighter.Configure();
            UpdateFighterClass();
        }

        internal static void UpdateFighterClass()
        {
            var existingGroups = FighterProgression.UIGroups?.ToList() ?? new List<UIGroup>();

            existingGroups.Add(Helpers.CreateUIGroup(
                MutationTitanFighter.MutagenFeature,
                MutationTitanFighter.DiscoveryFeatureSelection,
                MutationTitanFighter.GrandDiscoveryFeatureSelection));

            existingGroups.Add(Helpers.CreateUIGroup(
                MutationTitanFighter.GiantWeaponWielderFeature,
                MutationTitanFighter.GiantsMightFeature,
                MutationTitanFighter.UnstoppableStrikeFeature));

            existingGroups.Add(Helpers.CreateUIGroup(
                MutationTitanFighter.IncredibleHeftFeature,
                WeaponMasteryFeature));

            FighterProgression.UIGroups = existingGroups.ToArray();
        }

        public static BlueprintCharacterClass[] getFighterClassArray()
        {
            return new BlueprintCharacterClass[1]
            {
                FighterClass
            };
        }
    }
}