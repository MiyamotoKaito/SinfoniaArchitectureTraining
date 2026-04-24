using Application;

namespace Adaptor
{
    public class RegisterController
    {
        public RegisterController(ISpawnUseCase spawnUseCase)
        {
            _spawnUseCase = spawnUseCase;
        }
        public void Register(int id)
        {
            _spawnUseCase.SpawnMinion(id);
        }
        private readonly ISpawnUseCase _spawnUseCase;
    }
}
