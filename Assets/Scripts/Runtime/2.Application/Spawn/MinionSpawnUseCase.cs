using UnityEngine;

namespace Application
{
    public class MinionSpawnUseCase : ISpawnUseCase
    {
        public MinionSpawnUseCase(IMinionRepository repository)
        {
            _repository = repository;
        }
        public void SpawnMinion(int id)
        {
            _repository.RegisterMinion(id);
        }

        private IMinionRepository _repository;
    }
}
