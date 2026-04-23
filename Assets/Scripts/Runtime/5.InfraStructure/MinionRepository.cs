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

        public void RegisterMinion(int id, MinionType minionType)
        {
            if (!_minions.ContainsKey(id))
            {
                _minions.Add(id, ConvertEntity(minionType));
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

        [SerializeField] private List<MinionAsset> _assets;
        private Dictionary<int, MinionEntity> _minions = new Dictionary<int, MinionEntity>();

        private MinionEntity ConvertEntity(MinionType minionType)
        {
            var asset = _assets.Find(a => a.MinionType == minionType);
            if (asset == null)
            {
                Debug.LogError($"MinionAsset not found for MinionType: {minionType}");
                return null;
            }

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
