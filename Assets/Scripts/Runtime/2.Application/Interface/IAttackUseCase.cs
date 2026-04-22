using Domain;

namespace Application
{
    public interface IAttackUseCase
    {
        void Execute(MinionEntity minion , MinionEntity other);
    }
}
