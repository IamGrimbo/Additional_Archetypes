using HarmonyLib;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using TabletopTweaks.Core.Utilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using UnityEngine;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.UnitLogic.Mechanics.Components;
using Additional_Archetypes.Components;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;

namespace Additional_Archetypes.Classes.Cavalier
{
    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    internal class Cavalier
    {
        static internal BlueprintCharacterClass CavalierClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("3adc3439f98cb534ba98df59838f02c7");
        static internal BlueprintFeatureSelection CavalierOrderSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d710e30ea20240247ad87ad86bcd50f2");

        static internal BlueprintProgression CavalierOrderOfTheAxeProgression;
        public const string CavalierOrderOfTheAxeProgressionName = "CavalierOrderOfTheAxeProgression";
        public const string CavalierOrderOfTheAxeProgressionGuid = "37efb470cf464825929082fa808ee431";
        public const string CavalierOrderOfTheAxeProgressionDisplayName = "CavalierOrderOfTheAxeProgression.Name";
        public const string CavalierOrderOfTheAxeProgressionDescription = "CavalierOrderOfTheAxeProgression.Description";

        static internal BlueprintFeature CavalierOrderOfTheAxeChallengeFeature;
        public const string CavalierOrderOfTheAxeChallengeFeatureName = "CavalierOrderOfTheAxeChallengeFeature";
        public const string CavalierOrderOfTheAxeChallengeFeatureGuid = "37efb470cf464825929082fa808ee437";
        public const string CavalierOrderOfTheAxeChallengeFeatureDisplayName = "CavalierOrderOfTheAxeChallengeFeature.Name";
        public const string CavalierOrderOfTheAxeChallengeFeatureDescription = "CavalierOrderOfTheAxeChallengeFeature.Description";

        internal static void Configure()
        {
            CreateCavalierOrderOfTheAxeChallengeFeature();
            CreateCavalierOrderOfTheAxeProgression();
            PatchCavalierOrderSelection();
        }

        internal static void PatchCavalierOrderSelection()
        {
            CavalierOrderSelection = FeatureSelectionConfigurator.For(CavalierOrderSelection)
                .AddToAllFeatures(CavalierOrderOfTheAxeProgression)
                .Configure();
        }

        internal static void CreateCavalierOrderOfTheAxeProgression()
        {
            BlueprintFeature DazzlingDisplayIgnoreWeaponNeed = BlueprintTools.GetBlueprint<BlueprintFeature>("4d2b28040c8d4552aa401cc627881b09");
            BlueprintFeature CavalierBraggart = BlueprintTools.GetBlueprint<BlueprintFeature>("4546246e4f2031e4da57a127b5ad593c");
            BlueprintFeature CavalierMountedMastery = BlueprintTools.GetBlueprint<BlueprintFeature>("fde5b47705ea18444947633c5f025703");
            BlueprintFeatureSelection CavalierMountedMasteryFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("20d873a12e4e6cb4ea6da9761e974dd4");
            BlueprintFeature CavalierRetribution = BlueprintTools.GetBlueprint<BlueprintFeature>("bb1487fcae090c446aff904b0980347c");
            Sprite CavalierOrderOfTheAxeProgressionIcon = BlueprintTools.GetBlueprint<BlueprintProgression>("80004ec12a45b4d40936207341797361").Icon;

            CavalierOrderOfTheAxeProgression = ProgressionConfigurator.New(CavalierOrderOfTheAxeProgressionName, CavalierOrderOfTheAxeProgressionGuid)
                .SetDisplayName(CavalierOrderOfTheAxeProgressionDisplayName)
                .SetDescription(CavalierOrderOfTheAxeProgressionDescription)
                .SetIcon("assets/icons/orderoftheaxeicon.png")
                .SetClasses(CavalierClass)

                .AddToLevelEntries(1, CavalierOrderOfTheAxeChallengeFeature)
                .AddToLevelEntries(2, DazzlingDisplayIgnoreWeaponNeed, CavalierBraggart)
                .AddToLevelEntries(8, CavalierMountedMastery, CavalierMountedMasteryFeatSelection)
                .AddToLevelEntries(15, CavalierRetribution)

                .Configure();
        }

        internal static void CreateCavalierOrderOfTheAxeChallengeFeature()
        {
            BlueprintBuff Challenge = BlueprintTools.GetBlueprint<BlueprintBuff>("4f0218323ad379248b69de8a9501159f");

            CavalierOrderOfTheAxeChallengeFeature = FeatureConfigurator.New(CavalierOrderOfTheAxeChallengeFeatureName, CavalierOrderOfTheAxeChallengeFeatureGuid)
                .SetDisplayName(CavalierOrderOfTheAxeChallengeFeatureDisplayName)
                .SetDescription(CavalierOrderOfTheAxeChallengeFeatureDescription)
                .AddComponent<DamageBonusOrderOfCockatrice>(c =>
                {
                    c.m_CheckedFact = Challenge.ToReference<BlueprintUnitFactReference>();
                })
                .AddContextRankConfig(Helpers.CreateContextRankConfig(
                    baseValueType: ContextRankBaseValueType.ClassLevel,
                    progression: ContextRankProgression.OnePlusDivStep,
                    stepLevel: 4,
                    startLevel: 0,
                    max: 20,
                    classes: getCavalierClassArray()
                ))
                .Configure();
        }

        public static BlueprintCharacterClass[] getCavalierClassArray()
        {
            return new BlueprintCharacterClass[1]
            {
                CavalierClass
            };
        }
    }
}
