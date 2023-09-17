namespace AttackEffects
{
    public interface IVampireSystem
    {
        int AdditionalVampire { get; set; }
        int ReduceVampire { get; set; }
        int Vampire { get; }
        void ApplyVampire(int damage);
    }
}