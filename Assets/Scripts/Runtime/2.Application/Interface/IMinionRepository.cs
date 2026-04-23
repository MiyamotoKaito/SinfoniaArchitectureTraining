using Domain;

namespace Application
{
    interface IMinionRepository
    {
        void RegisterMinion();
        bool TryGetMinion(int id, out MinionEntity minion);
        bool ContainsMinion(int id);
        void RemoveMinion(int id);
    }
}
