using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Linq;
using UnityEngine;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using System;
using Additional_Archetypes.Components;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Utility;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.EntitySystem.Stats;
using System.Collections.Generic;

namespace Additional_Archetypes.Classes.Fighter.Archetypes
{
    internal class MutationTitanFighter
    {
        static internal BlueprintArchetype MutationTitanFighterArchetype;
        public const string MutationTitanFighterArchetypeName = "MutationTitanFighter";
        public const string MutationTitanFighterArchetypeGuid = "37efb470cf464825929082fa808ee664";
        public const string MutationTitanFighterArchetypeDisplayName = "MutationTitanFighter.Name";
        public const string MutationTitanFighterArchetypeDescription = "MutationTitanFighter.Description";
        
        static internal BlueprintFeature MutatedMobilityFeature;
        public const string MutatedMobilityFeatureName = "MutatedMobilityFeature";
        public const string MutatedMobilityFeatureGuid = "eaa445cd48d44721b3180a8f4a298462";
        public const string MutatedMobilityFeatureDisplayName = "MutatedMobilityFeature.Name";
        public const string MutatedMobilityFeatureDescription = "MutatedMobilityFeature.Description";

        static internal BlueprintFeature IncredibleHeftFeature;
        public const string IncredibleHeftFeatureName = "IncredibleHeftFeature";
        public const string IncredibleHeftFeatureGuid = "d9db5bb0773343d497bbfc39cf8bed7c";
        public const string IncredibleHeftFeatureDisplayName = "IncredibleHeftFeature.Name";
        public const string IncredibleHeftFeatureDescription = "IncredibleHeftFeature.Description";

        static internal BlueprintFeature GiantWeaponWielderFeature;
        public const string GiantWeaponWielderFeatureName = "GiantWeaponWielderFeature";
        public const string GiantWeaponWielderFeatureGuid = "9c00822f37cb4385ac27cd551760f237";
        public const string GiantWeaponWielderFeatureDisplayName = "GiantWeaponWielderFeature.Name";
        public const string GiantWeaponWielderFeatureDescription = "GiantWeaponWielderFeature.Description";

        static internal BlueprintFeature GiantsMightFeature;
        public const string GiantsMightFeatureName = "GiantsMightFeature";
        public const string GiantsMightFeatureGuid = "9e610196a71048d7a7bb5b83d650d1b9";
        public const string GiantsMightFeatureDisplayName = "GiantsMightFeature.Name";
        public const string GiantsMightFeatureDescription = "GiantsMightFeature.Description";

        static internal BlueprintFeature UnstoppableStrikeFeature;
        public const string UnstoppableStrikeFeatureName = "UnstoppableStrikeFeature";
        public const string UnstoppableStrikeFeatureGuid = "ab3f00aab56f4b7085ad8f8c1b1b2095";
        public const string UnstoppableStrikeFeatureDisplayName = "UnstoppableStrikeFeature.Name";
        public const string UnstoppableStrikeFeatureDescription = "UnstoppableStrikeFeature.Description";

        static internal BlueprintFeature MutagenFeature;
        public const string MutagenFeatureName = "MutagenFeature";
        public const string MutagenFeatureGuid = "b5c6fca697254856936eb2515822fa1c";
        public const string MutagenFeatureDisplayName = "MutagenFeature.Name";
        public const string MutagenFeatureDescription = "MutagenFeature.Description";

        static internal BlueprintFeature FeralMutagenFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("fd5f7b37ab4301c48a88cc196ee5f0ce");
        static internal BlueprintFeature FeralWingsFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("78197196e096c6e4eaed5c62fa108b52");
        static internal BlueprintFeature PreserveOrgansFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("76b4bb8e54f3f5c418f421684c76ef4e");
        static internal BlueprintFeature SpontaneousHealingFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("2bc1ee626a69667469ab5c1698b99956");

        static internal BlueprintBuff MutagenDamageBonusBuff;
        public const string MutagenDamageBonusBuffName = "MutagenDamageBonusBuff";
        public const string MutagenDamageBonusBuffGuid = "a82d30663eee4aca9a8782a4698506f5";
        public const string MutagenDamageBonusBuffDisplayName = "MutagenDamageBonusBuff.Name";
        public const string MutagenDamageBonusBuffDescription = "MutagenDamageBonusBuff.Description";

        static internal BlueprintFeature MutagenDamageBonusFeature;
        public const string MutagenDamageBonusFeatureName = "MutagenDamageBonusFeature";
        public const string MutagenDamageBonusFeatureGuid = "c92f4aab626349d4bd760641cea79f4e";
        public const string MutagenDamageBonusFeatureDisplayName = "MutagenDamageBonusFeature.Name";
        public const string MutagenDamageBonusFeatureDescription = "MutagenDamageBonusFeature.Description";

        static internal BlueprintBuff MutatedArmBuff;
        public const string MutatedArmBuffName = "MutationTitanFighterMutatedArmBuff";
        public const string MutatedArmBuffGuid = "924f59ec60e04c1ca023666728bcfe01";
        public const string MutatedArmBuffDisplayName = "MutatedArmBuff.Name";
        public const string MutatedArmBuffDescription = "MutatedArmBuff.Description";

        static internal BlueprintFeature MutatedArmFeature;
        public const string MutatedArmFeatureName = "MutationTitanFighterMutatedArmFeature";
        public const string MutatedArmFeatureGuid = "c92f4aab626349d4bd760641cea79f40";
        public const string MutatedArmFeatureDisplayName = "MutatedArmFeature.Name";
        public const string MutatedArmFeatureDescription = "MutatedArmFeature.Description";

        static internal BlueprintFeatureSelection DiscoveryFeatureSelection;
        public static string DiscoveryFeatureSelectionName = "MutationDiscoveryFeatureSelection";
        public static string DiscoveryFeatureSelectionGuid = "bf06feba64c14effa12a02f575eacafc";
        public static string DiscoveryFeatureSelectionDisplayName = "MutationDiscoveryFeatureSelection.Name";
        public static string DiscoveryFeatureSelectionDescription = "MutationDiscoveryFeatureSelection.Description";

        static internal BlueprintFeatureSelection GrandDiscoveryFeatureSelection;
        public static string GrandDiscoveryFeatureSelectionName = "GrandMutationDiscoveryFeatureSelection";
        public static string GrandDiscoveryFeatureSelectionGuid = "ab71c3ffa6c2457c9dcf302e7b84c2d6";
        public static string GrandDiscoveryFeatureSelectionDisplayName = "GrandMutationDiscoveryFeatureSelection.Name";
        public static string GrandDiscoveryFeatureSelectionDescription = "GrandMutationDiscoveryFeatureSelection.Description";

        internal static void Configure()
        {
            CreateMutationTitanFighterArchetypeBase();

            CreateMobilityClassSkillFeature();
            CreateIncredibleHeft();
            CreateGiantWeaponWielder();
            CreateGiantsMight();
            CreateUnstoppableStrike();
            CreateMutagen();

            CreateMutagenDamage();
            CreateMutatedArm();

            PatchMutagenFeatures();

            PatchFeralMutagenFeature();
            PatchFeralWingsFeature();
            PatchFeralHealingSpontaneousHealingAbilityResourceArchetype();

            CreateDiscovery();
            CreateGrandDiscovery();

            PatchMutationTitanFighterArchetypeFeatures();
        }

        internal static void CreateMutationTitanFighterArchetypeBase()
        {
            MutationTitanFighterArchetype = ArchetypeConfigurator.New(
                    MutationTitanFighterArchetypeName,
                    MutationTitanFighterArchetypeGuid,
                    Fighter.FighterClass)
                .SetLocalizedName(MutationTitanFighterArchetypeDisplayName)
                .SetLocalizedDescription(MutationTitanFighterArchetypeDescription)
                .SetReplaceClassSkills(true)
                .AddToClassSkills(StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillLoreNature, StatType.SkillPersuasion)
                .SetAddSkillPoints(1)
                .Configure();
        }

        internal static void PatchMutationTitanFighterArchetypeFeatures()
        {
            ArchetypeConfigurator.For(MutationTitanFighterArchetype)
                .AddToRemoveFeatures(2, Fighter.BraveryFeature)
                .AddToRemoveFeatures(3, Fighter.ArmorTrainingFeature)
                .AddToRemoveFeatures(5, Fighter.WeaponTrainingFeatureSelection)
                .AddToRemoveFeatures(6, Fighter.BraveryFeature)
                .AddToRemoveFeatures(7, Fighter.ArmorTrainingFeature)
                .AddToRemoveFeatures(9, Fighter.WeaponTrainingFeatureSelection, Fighter.WeaponTrainingRankUpFeatureSelection)
                .AddToRemoveFeatures(10, Fighter.BraveryFeature)
                .AddToRemoveFeatures(11, Fighter.ArmorTrainingFeature)
                .AddToRemoveFeatures(13, Fighter.WeaponTrainingFeatureSelection, Fighter.WeaponTrainingRankUpFeatureSelection)
                .AddToRemoveFeatures(14, Fighter.BraveryFeature)
                .AddToRemoveFeatures(15, Fighter.ArmorTrainingFeature)
                .AddToRemoveFeatures(17, Fighter.WeaponTrainingFeatureSelection, Fighter.WeaponTrainingRankUpFeatureSelection)
                .AddToRemoveFeatures(18, Fighter.BraveryFeature)
                .AddToRemoveFeatures(19, Fighter.ArmorMasteryFeature)

                .AddToAddFeatures(1, IncredibleHeftFeature, GiantWeaponWielderFeature, MutatedMobilityFeature)
                .AddToAddFeatures(3, MutagenFeature)
                .AddToAddFeatures(5, IncredibleHeftFeature)
                .AddToAddFeatures(7, DiscoveryFeatureSelection)
                .AddToAddFeatures(9, IncredibleHeftFeature)
                .AddToAddFeatures(10, GiantsMightFeature) 
                .AddToAddFeatures(11, DiscoveryFeatureSelection)
                .AddToAddFeatures(13, IncredibleHeftFeature)
                .AddToAddFeatures(15, DiscoveryFeatureSelection)
                .AddToAddFeatures(17, IncredibleHeftFeature)
                .AddToAddFeatures(19, GrandDiscoveryFeatureSelection, UnstoppableStrikeFeature)
                .Configure();
        }

        internal static void CreateMobilityClassSkillFeature()
        {
            Sprite mobilityIcon = BlueprintTools
                .GetBlueprint<BlueprintFeature>("fc37b70e3d064a147a3a99db4a86ee12")
                .Icon;

            MutatedMobilityFeature = FeatureConfigurator
                .New(MutatedMobilityFeatureName, MutatedMobilityFeatureGuid)
                .SetDisplayName(MutatedMobilityFeatureDisplayName)
                .SetDescription(MutatedMobilityFeatureDescription)
                .SetIcon(mobilityIcon)
                .AddContextStatBonus(
                    stat: StatType.SkillMobility,
                    value: new ContextValue { ValueType = ContextValueType.Rank },
                    descriptor: ModifierDescriptor.UntypedStackable
                )
                .AddContextStatBonus(
                    stat: StatType.SkillAthletics,
                    value: new ContextValue { ValueType = ContextValueType.Rank },
                    descriptor: ModifierDescriptor.UntypedStackable
                )
                .AddContextRankConfig(Helpers.CreateContextRankConfig(
                    baseValueType: ContextRankBaseValueType.ClassLevel,
                    progression: ContextRankProgression.DivStep,
                    stepLevel: 4,
                    max: 5,
                    classes: Fighter.getFighterClassArray()
                ))
                .SetIsClassFeature(true)
                .Configure();
        }

        internal static void CreateIncredibleHeft()
        {
            BlueprintFeature OriginalIncredibleHeftFeature = BlueprintTools
                .GetBlueprint<BlueprintFeature>("f0235447f6f3430fa4a98d15642b849e");

            IncredibleHeftFeature = FeatureConfigurator
                .New(IncredibleHeftFeatureName, IncredibleHeftFeatureGuid)
                .SetDisplayName(IncredibleHeftFeatureDisplayName)
                .SetDescription(IncredibleHeftFeatureDescription)
                .SetIcon(OriginalIncredibleHeftFeature.m_Icon)
                .AddComponent(OriginalIncredibleHeftFeature.GetComponent<WeaponParametersAttackBonus>())
                .AddComponent(OriginalIncredibleHeftFeature.GetComponent<WeaponParametersDamageBonus>())
                .SetIsClassFeature(true)
                .SetRanks(5)
                .Configure();
        }

        internal static void CreateGiantWeaponWielder()
        {
            BlueprintFeature OriginalGiantWeaponWielderFeature = BlueprintTools.
                GetBlueprint<BlueprintFeature>("38323bb032d740ab9045f1086705b0c7");

            GiantWeaponWielderFeature = FeatureConfigurator
                .New(GiantWeaponWielderFeatureName, GiantWeaponWielderFeatureGuid)
                .SetDisplayName(GiantWeaponWielderFeatureDisplayName)
                .SetDescription(GiantWeaponWielderFeatureDescription)
                .SetIcon(OriginalGiantWeaponWielderFeature.m_Icon)
                .AddComponent(OriginalGiantWeaponWielderFeature.GetComponent<AddMechanicsFeature>())
                .AddComponent(OriginalGiantWeaponWielderFeature.GetComponent<WeaponParametersAttackBonus>())
                .SetIsClassFeature(true)
                .Configure();
        }

        internal static void CreateGiantsMight()
        {
            BlueprintFeature OriginalGiantsMightFeature = BlueprintTools.
                GetBlueprint<BlueprintFeature>("b5768ae940b44a39a3469b2f7c29cc6d");

            GiantsMightFeature = FeatureConfigurator
                .New(GiantsMightFeatureName, GiantsMightFeatureGuid)
                .SetDisplayName(GiantsMightFeatureDisplayName)
                .SetDescription(GiantsMightFeatureDescription)
                .SetIcon(OriginalGiantsMightFeature.m_Icon)
                .AddComponent(OriginalGiantsMightFeature.GetComponent<AdditionalStatBonusOnAttackDamage>())
                .SetIsClassFeature(true)
                .Configure();
        }

        internal static void CreateUnstoppableStrike()
        {
            BlueprintFeature OriginalUnstoppableStrikeFeature = BlueprintTools
                .GetBlueprint<BlueprintFeature>("7d60d8bb86a14e3188d208652d4a5581");

            UnstoppableStrikeFeature = FeatureConfigurator
                .New(UnstoppableStrikeFeatureName, UnstoppableStrikeFeatureGuid)
                .SetDisplayName(UnstoppableStrikeFeatureDisplayName)
                .SetDescription(UnstoppableStrikeFeatureDescription)
                .SetIcon(OriginalUnstoppableStrikeFeature.m_Icon)
                .AddComponent(OriginalUnstoppableStrikeFeature.GetComponent<AdditionalStatBonusOnAttackDamage>())
                .SetIsClassFeature(true)
                .Configure();
        }

        internal static void CreateMutagen()
        {
            BlueprintFeature OriginalMutagenFeature = BlueprintTools
                .GetBlueprint<BlueprintFeature>("cee8f65448ce71c4b8b8ca13751dd8ea");

            var configurator = FeatureConfigurator.New(MutagenFeatureName, MutagenFeatureGuid)
                .SetDisplayName(MutagenFeatureDisplayName)
                .SetDescription(MutagenFeatureDescription)
                .SetIcon(OriginalMutagenFeature.m_Icon)
                .AddComponent(OriginalMutagenFeature.GetComponent<AddFacts>())
                .EditComponent<AddFacts>(c => c.DoNotRestoreMissingFacts = true)
                .AddComponent(OriginalMutagenFeature.GetComponent<AddAbilityResources>())
                .SetIsClassFeature(true);

            foreach (var factComponent in OriginalMutagenFeature.GetComponents<AddFeatureIfHasFact>())
                configurator.AddComponent(factComponent);

            MutagenFeature = configurator.Configure();

        }

        internal static void PatchMutagenFeatures()
        {
            BlueprintFeature GreaterMutagenFeature = BlueprintTools.
                GetBlueprint<BlueprintFeature>("76c61966afdd82048911f3d63c6fe0bc");

            GreaterMutagenFeature = FeatureConfigurator
                .For(GreaterMutagenFeature)
                .AddPrerequisiteArchetypeLevel
                (
                    characterClass : Fighter.FighterClass.ToReference<BlueprintCharacterClassReference>(),
                    archetype: MutationTitanFighterArchetype.ToReference<BlueprintArchetypeReference>(),
                    group: Prerequisite.GroupType.Any,
                    level: 12
                )
                .EditComponent<PrerequisiteFeaturesFromList>(c =>
                {
                    List<BlueprintFeatureReference> featuresList = c.m_Features?.ToList() ?? new List<BlueprintFeatureReference>();
                    featuresList.Add(MutagenFeature.ToReference<BlueprintFeatureReference>());
                    c.m_Features = featuresList.ToArray();
                })
                .Configure();

            BlueprintFeature GrandMutagenFeature = BlueprintTools.
                GetBlueprint<BlueprintFeature>("6f5cb651e26bd97428523061b07ffc85");

            GrandMutagenFeature = FeatureConfigurator
                .For(GreaterMutagenFeature)
                .AddPrerequisiteArchetypeLevel
                (
                    characterClass: Fighter.FighterClass.ToReference<BlueprintCharacterClassReference>(),
                    archetype: MutationTitanFighterArchetype.ToReference<BlueprintArchetypeReference>(),
                    group: Prerequisite.GroupType.Any,
                    level: 16
                )
                .Configure();

            BlueprintAbility[] mutagenFeatureAbilities = MutagenFeature.GetComponent<AddFacts>().m_Facts
                .OfType<BlueprintAbility>()
                .ToArray();

            BlueprintAbility[] additionalMutagenAbilities = new BlueprintAbility[] {
                BlueprintTools.GetBlueprint<BlueprintAbility>("7af42862f58edcc4cb825862ff2a0d10"), // Str
                BlueprintTools.GetBlueprint<BlueprintAbility>("b11d314d60f7a38498d1ed6933fe1638"), // Dex
                BlueprintTools.GetBlueprint<BlueprintAbility>("859629f49f06cd04492b1ba455a9b31b"), // Con
                BlueprintTools.GetBlueprint<BlueprintAbility>("ac1680d36a079a44bb58946b9d98f3fa"), // GreaterStrDex
                BlueprintTools.GetBlueprint<BlueprintAbility>("499ba008d5bde104ea9a1f039b3796b2"), // GreaterStrCon
                BlueprintTools.GetBlueprint<BlueprintAbility>("78d953b296fb2154aa2c85e6e724ce56"), // GreaterDexStr
                BlueprintTools.GetBlueprint<BlueprintAbility>("73b97114bf2f9914bba305fc3f032468"), // GreaterDexCon
                BlueprintTools.GetBlueprint<BlueprintAbility>("c942e12092a433440bbc73965b842c8a"), // GreaterConStr
                BlueprintTools.GetBlueprint<BlueprintAbility>("c1e46599fcade78418ef1ada71c1f487"), // GreaterConDex
                BlueprintTools.GetBlueprint<BlueprintAbility>("8444394f44f56b842bc2252782fde2e0"), // GrandStrDex
                BlueprintTools.GetBlueprint<BlueprintAbility>("3c2ef5a7ef926044aa168b494f7b341f"), // GrandStrCon
                BlueprintTools.GetBlueprint<BlueprintAbility>("dd2070ece4664eb42854a564ed4dddce"), // GrandDexStr
                BlueprintTools.GetBlueprint<BlueprintAbility>("b79cf60fbaa644042b98efed62fdd4f9"), // GrandDexCon
                BlueprintTools.GetBlueprint<BlueprintAbility>("3b69541e21f2d2c4fbf5956d0bb52768"), // GrandConStr
                BlueprintTools.GetBlueprint<BlueprintAbility>("49d44c166d9f1294d8dbd78ef93df865")  // GrandConDex
            };

            BlueprintAbility[] MutagenAbilities = mutagenFeatureAbilities
                .Concat(additionalMutagenAbilities)
                .ToArray();

            var mutagenBuffFeatures = new (BlueprintFeature feature, BlueprintBuff buff)[,]
            {
                { (MutagenDamageBonusFeature, MutagenDamageBonusBuff) },
                { (MutatedArmFeature, MutatedArmBuff) }
            };

            foreach (BlueprintAbility ability in MutagenAbilities)
            {
                ContextRankConfig contextRankConfigAbility = ability
                    .GetComponent<ContextRankConfig>();

                ContextRankConfig contextRankConfigBuff = ability
                    .GetComponents<AbilityEffectRunAction>()
                    .FirstOrDefault()
                    .Actions.Actions
                    .OfType<Conditional>()
                    .FirstOrDefault()
                    .IfFalse.Actions
                    .OfType<ContextActionApplyBuff>()
                    .FirstOrDefault()
                    .m_Buff.Get()
                    .GetComponent<ContextRankConfig>();

                ContextRankConfig[] configs = new ContextRankConfig[] {
                    contextRankConfigAbility,
                    contextRankConfigBuff
                };

                foreach (ContextRankConfig config in configs)
                    if (!config.m_AdditionalArchetypes.
                        Contains(MutationTitanFighterArchetype.
                        ToReference<BlueprintArchetypeReference>()))
                        config.m_AdditionalArchetypes = CollectionExtensions.AddToArray(
                            config.m_AdditionalArchetypes,
                            MutationTitanFighterArchetype.ToReference<BlueprintArchetypeReference>()
                    );

                foreach (var (feature, buff) in mutagenBuffFeatures)
                    CreateConditional(ability, feature, buff);
            }
        }


        internal static void PatchFeralMutagenFeature()
        {
            FeralMutagenFeature = FeatureConfigurator
                .For(FeralMutagenFeature)
                .AddPrerequisiteFeature(
                    MutagenFeature.ToReference<BlueprintFeatureReference>(),
                    checkInProgression: false,
                    group: Prerequisite.GroupType.Any,
                    hideInUI: false
                )
                .Configure();
        }

        internal static void PatchFeralWingsFeature()
        {
            FeralWingsFeature = FeatureConfigurator
                .For(FeralWingsFeature)
                .AddPrerequisiteArchetypeLevel(
                    checkInProgression: false,
                    group: Prerequisite.GroupType.Any,
                    hideInUI: false,
                    characterClass: Fighter.FighterClass.ToReference<BlueprintCharacterClassReference>(),
                    archetype: MutationTitanFighterArchetype.ToReference<BlueprintArchetypeReference>(),
                    level: 6
                )
                .Configure();
        }

        internal static void PatchFeralHealingSpontaneousHealingAbilityResourceArchetype()
        {
            BlueprintTools.GetBlueprint<BlueprintAbilityResource>("0b417a7292b2e924782ef2aab9451816").m_MaxAmount.m_ArchetypesDiv = CollectionExtensions.AddToArray(BlueprintTools.GetBlueprint<BlueprintAbilityResource>("0b417a7292b2e924782ef2aab9451816").m_MaxAmount.m_ArchetypesDiv, MutationTitanFighterArchetype.ToReference<BlueprintArchetypeReference>());
        }

        internal static void CreateMutagenDamage()
        {
            Sprite MutagenDamageBonusIcon = BlueprintTools
                .GetBlueprint<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3")
                .Icon;

            MutagenDamageBonusFeature = FeatureConfigurator
                .New(MutagenDamageBonusFeatureName, MutagenDamageBonusFeatureGuid)
                .SetDisplayName(MutagenDamageBonusFeatureDisplayName)
                .SetDescription(MutagenDamageBonusFeatureDescription)
                .SetIcon(MutagenDamageBonusIcon)
                .SetIsClassFeature(false)
                .Configure();

            MutagenDamageBonusBuff = BuffConfigurator
                .New(MutagenDamageBonusBuffName, MutagenDamageBonusBuffGuid)
                .SetDisplayName(MutagenDamageBonusBuffDisplayName)
                .SetDescription(MutagenDamageBonusBuffDescription)
                .SetIcon(MutagenDamageBonusIcon)
                .AddWeaponAttackTypeDamageBonus(
                    value: new ContextValue { ValueType = ContextValueType.Rank },
                    type: WeaponRangeType.Melee,
                    descriptor: ModifierDescriptor.UntypedStackable,
                    attackBonus: 1
                )
                .AddContextRankConfig(Helpers.CreateContextRankConfig(
                    ContextRankBaseValueType.CharacterLevel,
                    ContextRankProgression.StartPlusDivStep,
                    max: null,
                    startLevel: -5,
                    stepLevel: 5,
                    classes: Fighter.getFighterClassArray()
                ))
                .Configure();
        }


        internal static void CreateMutatedArm()
        {
            Sprite MutatedArmIcon = BlueprintTools
                .GetBlueprint<BlueprintFeature>("cffb5cddefab30140ac133699d52a8f8")
                .Icon;

            MutatedArmFeature = FeatureConfigurator
                .New(MutatedArmFeatureName, MutatedArmFeatureGuid)
                .SetDisplayName(MutatedArmFeatureDisplayName)
                .SetDescription(MutatedArmFeatureDescription)
                .SetIcon(MutatedArmIcon)
                .SetIsClassFeature(false)
                .Configure();

            MutatedArmBuff = BuffConfigurator
                .New(MutatedArmBuffName, MutatedArmBuffGuid)
                .SetDisplayName(MutatedArmBuffDisplayName)
                .SetDescription(MutatedArmBuffDescription)
                .SetIcon(MutatedArmIcon)
                .AddComponent<AddExtraOffHandAttack>()
                .Configure();
        }

        internal static void CreateDiscovery()
        {
            Sprite DiscoveryFeatureSelectionIcon = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").Icon;

            DiscoveryFeatureSelection = FeatureSelectionConfigurator.New(DiscoveryFeatureSelectionName, DiscoveryFeatureSelectionGuid)
                .SetDisplayName(DiscoveryFeatureSelectionDisplayName)
                .SetDescription(DiscoveryFeatureSelectionDescription)
                .SetIcon(DiscoveryFeatureSelectionIcon)
                .Configure();

            DiscoveryFeatureSelection.m_AllFeatures = new BlueprintFeatureReference[5]
            {
                FeralMutagenFeature.ToReference<BlueprintFeatureReference>(),
                FeralWingsFeature.ToReference<BlueprintFeatureReference>(),
                PreserveOrgansFeature.ToReference<BlueprintFeatureReference>(),
                SpontaneousHealingFeature.ToReference<BlueprintFeatureReference>(),
                MutagenDamageBonusFeature.ToReference<BlueprintFeatureReference>()
            };
        }

        internal static void CreateGrandDiscovery()
        {
            BlueprintFeature OriginalGreaterMutagenFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("76c61966afdd82048911f3d63c6fe0bc");
            Sprite GrandDiscoveryFeatureSelectionIcon = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("2729af328ab46274394cedc3582d6e98").Icon;

            GrandDiscoveryFeatureSelection = FeatureSelectionConfigurator.New(GrandDiscoveryFeatureSelectionName, GrandDiscoveryFeatureSelectionGuid)
                .SetDisplayName(GrandDiscoveryFeatureSelectionDisplayName)
                .SetDescription(GrandDiscoveryFeatureSelectionDescription)
                .SetIcon(GrandDiscoveryFeatureSelectionIcon)
                .Configure();

            GrandDiscoveryFeatureSelection.m_AllFeatures = new BlueprintFeatureReference[2]
            {
                OriginalGreaterMutagenFeature.ToReference<BlueprintFeatureReference>(),
                MutatedArmFeature.ToReference<BlueprintFeatureReference>(),
            };
        }

        private static void CreateConditional(BlueprintAbility mutagenAbility, BlueprintFeature feature, BlueprintBuff buff)
        {
            mutagenAbility.GetComponent<AbilityEffectRunAction>().TemporaryContext(c => {
                c.Actions.Actions = c.Actions.Actions.AppendToArray(
                    new Conditional()
                    {
                        ConditionsChecker = new ConditionsChecker()
                        {
                            Operation = Operation.Or,
                            Conditions = new Condition[] {
                                new ContextConditionHasFact() {
                                    m_Fact = feature.ToReference<BlueprintUnitFactReference>(), Not = false
                                }
                            }
                        },
                        IfTrue = Helpers.CreateActionList(
                            new ContextActionApplyBuff()
                            {
                                m_Buff = buff.ToReference<BlueprintBuffReference>(),
                                DurationValue = new ContextDurationValue()
                                {
                                    Rate = DurationRate.TenMinutes,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = new ContextValue()
                                    {
                                        ValueType = ContextValueType.Simple,
                                        Value = 0,
                                        ValueRank = AbilityRankType.Default,
                                        ValueShared = AbilitySharedValue.Damage,
                                        Property = UnitProperty.None
                                    },
                                    BonusValue = new ContextValue()
                                    {
                                        ValueType = ContextValueType.Rank,
                                        Value = 0,
                                        ValueRank = AbilityRankType.Default,
                                        ValueShared = AbilitySharedValue.Damage,
                                        Property = UnitProperty.None
                                    },
                                }
                            }
                            ),
                        IfFalse = Helpers.CreateActionList()
                    }
                    );
            });

        }
    }
}