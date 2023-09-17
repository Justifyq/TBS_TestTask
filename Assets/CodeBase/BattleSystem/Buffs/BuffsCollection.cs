using System;
using Effects;
using Random = UnityEngine.Random;

namespace BattleSystem.Buffs
{
    public class BuffsCollection
    {
        private readonly Type[] _buffsTypes =
        {
            typeof(VampireBuff),
            typeof(VampireDecreaseBuff),
            typeof(ArmorSelfBuff),
            typeof(ArmorDecreaseBuff),
            typeof(DoubleDamageBuff)
        };

        public Type GetRandomBuff() => _buffsTypes[Random.Range(0, _buffsTypes.Length)];
    }
}