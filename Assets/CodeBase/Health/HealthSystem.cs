namespace Health
{
    public class HealthSystem : BaseHealthSystem
    {
        private readonly IArmorSystem _armorSystem;
        
        public HealthSystem(IArmorSystem armorSystem) => _armorSystem = armorSystem;

        public override void GetDamage(int damage) => Health -= _armorSystem.CalculateDamage(damage);

        public override void RecoverHealth(int health) => Health += health;
    }
}