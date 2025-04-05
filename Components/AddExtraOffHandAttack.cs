using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace Additional_Archetypes.Components
{
    [ComponentName("Add Extra Off-Hand Attack")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("327faf39b9a643c2bbca12c7e8f81ccb")]
    public class AddExtraOffHandAttack : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt)
        {
            if (!evt.Initiator.Body.SecondaryHand.Weapon.Blueprint.IsTwoHanded ||
                evt.Initiator.Body.SecondaryHand.Weapon.IsSecondPartOfDoubleWeapon)
                return;

            evt.Result.SecondaryHand.AdditionalAttacks += 1 + (evt.Initiator.Stats.BaseAttackBonus.ModifiedValue / 20);
        }

        public void OnEventDidTrigger(RuleCalculateAttacksCount evt) { }
    }
}