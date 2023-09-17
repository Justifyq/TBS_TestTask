using Damage;
using Effects;
using Health;

public interface IUnit : IDamageable, IDamageDealer, IBuffHandler, IDebuffApplier
{
    void FinishTurn();
}