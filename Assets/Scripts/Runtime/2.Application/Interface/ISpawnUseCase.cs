using UnityEngine;

namespace Application
{
    public interface ISpawnUseCase
    {
        void SpawnMinion(IMinionRepository repository);
    }
}
