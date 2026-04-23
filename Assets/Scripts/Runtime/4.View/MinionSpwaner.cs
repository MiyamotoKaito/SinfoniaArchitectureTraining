using Application;
using UnityEngine;

namespace View
{
    public class MinionSpawner : MonoBehaviour
    {
        public void Initialize(IMinionRepository repository)
        {
            _repository = repository;
        }
        public void SpawnMinion(IMinionRepository repository)
        {
            var minion = Instantiate(_minionView, _spawnPoint.position, Quaternion.identity);
            repository.RegisterMinion(minion.ID, minion.MinionType);
        }
        [SerializeField] private MinionView _minionView;
        [SerializeField] private Transform _spawnPoint;
        private IMinionRepository _repository;
    }
}
