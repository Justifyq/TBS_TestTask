namespace Damage
{
    public interface IDamageMultiplier
    {
        int AdditionalMultiply { get; set; }
        int ReduceMultiply { get; set; }
        int RecalculateDamage(int baseDamage);
    }
}