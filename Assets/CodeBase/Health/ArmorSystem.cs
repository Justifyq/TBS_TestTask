using System;
using UnityEngine;

namespace Health
{
    public class ArmorSystem : IArmorSystem
    {
        public event Action<int> ArmorChanged;

        public int Armor
        {
            get
            {
                int armor = _baseArmor + AdditionalArmor - ReduceArmor;

                
                if (armor < 0)
                    armor = 0;
                
                if (armor > _maxArmor)
                    armor = _maxArmor;

                return armor;
            }
        }

        public int MaxArmor => _maxArmor;

        public int AdditionalArmor
        {
            get => _additionalArmor;
            set
            {
                _additionalArmor = value;
                ArmorChanged?.Invoke(Armor);
            }
        }

        public int ReduceArmor
        {
            get => _reduceArmor;
            set
            {
                _reduceArmor = value;
                ArmorChanged?.Invoke(Armor);
            }
        }

        private int _reduceArmor;
        private int _additionalArmor;
    
        private readonly int _baseArmor;
        private readonly int _maxArmor;

        public ArmorSystem(int baseArmor = 0, int maxArmor = 100)
        {
            _baseArmor = baseArmor;
            _maxArmor = maxArmor;
        }

        public int CalculateDamage(int incomeDamage) => (int)(incomeDamage - incomeDamage * Armor.Normalize());
    }
}