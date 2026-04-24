using Domain;

namespace Application
{
    public interface IMinionRepository
    {
        void RegisterMinion(int id);
        bool TryGetMinion(int id, out MinionEntity minion);
        bool ContainsMinion(int id);
        void RemoveMinion(int id);
    }
}
