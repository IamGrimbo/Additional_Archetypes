using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic;
using Kingmaker.PubSubSystem;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace Additional_Archetypes.Components
{
    [ComponentName("Damage Bonus Order Of Axe")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class DamageBonusOrderOfAxe : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateWeaponStats>
    {
        static internal BlueprintUnitFactReference CheckedFact = BlueprintTools.GetBlueprint<BlueprintBuff>("4f0218323ad379248b69de8a9501159f").ToReference< BlueprintUnitFactReference>();

        public ContextValue BonusValue;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if (Owner.HasFact(CheckedFact))
            {
                int bonus = BonusValue.Calculate(Fact.MaybeContext);
                evt.DamageBonusStat += bonus;
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }
    }
}
