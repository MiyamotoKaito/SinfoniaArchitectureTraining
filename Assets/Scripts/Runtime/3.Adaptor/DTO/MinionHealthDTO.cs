namespace Adaptor
{
    public readonly ref struct MinionHealthDTO
    {
        public MinionHealthDTO(float health)
        {
            Health = health;
        }
        public float Health { get; }
    }
}