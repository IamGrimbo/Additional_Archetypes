using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic;
using Kingmaker.PubSubSystem;

namespace Additional_Archetypes.Components
{
    [ComponentName("Damage Bonus Order Of Axe")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class DamageBonusOrderOfAxe : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateWeaponStats>
    {
        public ContextValue BonusValue;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            int bonus = BonusValue.Calculate(this.Fact.MaybeContext);
            evt.DamageBonusStat += bonus;
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }
    }
}