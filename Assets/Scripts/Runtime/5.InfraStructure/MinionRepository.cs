using System.Collections.Generic;
using Application;
using Domain;
using UnityEngine;

namespace InfraStructure
{
    public class MinionRepository : MonoBehaviour, IMinionRepository
    {
        public bool ContainsMinion(int id)
        {
            return _minions.ContainsKey(id);
        }

        public void RegisterMinion(int id)
        {
            if (!_minions.ContainsKey(id))
            {
                _minions.Add(id, ConvertEntity());
            }
        }

        public void RemoveMinion(int id)
        {
            if (_minions.ContainsKey(id))
            {
                _minions.Remove(id);
            }
        }

        public bool TryGetMinion(int id, out MinionEntity minion)
        {
            return _minions.TryGetValue(id, out minion);
        }

        [SerializeField] private MinionAsset _assets;
        private Dictionary<int, MinionEntity> _minions = new Dictionary<int, MinionEntity>();

        private MinionEntity ConvertEntity()
        {
            var asset = _assets;

            return new MinionEntity(asset.Health,
                asset.Defense,
                asset.MoveSpeed,
                asset.AttackPower,
                asset.AttackRange,
                asset.AttackSpeed,
                asset.CriticalChance,
                asset.CriticalDamage);
        }
    }
}
