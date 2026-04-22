namespace Adaptor
{
    public readonly ref struct MinionHealthDTO
    {
        public MinionHealthDTO(int health)
        {
            Health = health;
        }
        public int Health { get; }
    }
}