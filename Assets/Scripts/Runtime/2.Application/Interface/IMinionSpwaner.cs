namespace Application
{
    public class MinionFactory
    {
        public MinionFactory(IMinionRepository repository, ISpawnUseCase spawnUseCase)
        {
            _repository = repository;
            _spawnUseCase = spawnUseCase;
        }
        private readonly IMinionRepository _repository;
        private readonly ISpawnUseCase _spawnUseCase;
    }
}
