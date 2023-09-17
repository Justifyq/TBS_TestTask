using System;

namespace Health
{
    public interface IArmorSystem
    {
        event Action<int> ArmorChanged; 
        int Armor { get; }
        
        int MaxArmor { get; }
        int AdditionalArmor { get; set; }
    
        int ReduceArmor { get; set; }
        int CalculateDamage(int incomeDamage);
    }
}