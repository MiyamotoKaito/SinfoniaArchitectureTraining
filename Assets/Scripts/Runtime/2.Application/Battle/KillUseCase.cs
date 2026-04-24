namespace Application
{
    public class KillUseCase : IKillUseCase
    {
        public KillUseCase(IMinionRepository minionRepository)
        {
            _repository = minionRepository;
        }
        public void Kill(int id)
        {
            _repository.RemoveMinion(id);
        }
        private IMinionRepository _repository;
    }
}
