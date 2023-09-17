namespace Damage
{
    public class DamageMultiplier : IDamageMultiplier
    {
        public int AdditionalMultiply { get; set; }
        public int ReduceMultiply { get; set; }

        private int DamageMultiply => AdditionalMultiply - ReduceMultiply;
    
        public int RecalculateDamage(int baseDamage) => baseDamage + (int)(baseDamage * DamageMultiply.Normalize());
    }
}