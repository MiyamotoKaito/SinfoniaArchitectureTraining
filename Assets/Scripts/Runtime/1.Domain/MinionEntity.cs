namespace Domain
{
    public class MinionEntity
    {
        public MinionEntity(int health, 
                            int defence, 
                            float moveSpeed,
                            int attackPower, 
                            float attackRange,
                            float attackSpeed ,
                            float criticalChance,
                            float criticalDamage)
        {
            _health = new Health(health);
            Defence = new Defence(defence);
            MoveSpeed = new MoveSpeed(moveSpeed);
            AttackPower = new AttackPower(attackPower);
            AttackRange = new AttackRange(attackRange);
            AttackSpeed = new AttackSpeed(attackSpeed);
            CriticalChance = new CriticalChance(criticalChance);
            CriticalDamage = new CriticalDamage(criticalDamage);
        }

        public Health Health => _health;
        public Defence Defence { get; }
        public MoveSpeed MoveSpeed { get; }
        public AttackPower AttackPower { get; }
        public AttackRange AttackRange { get; }
        public AttackSpeed AttackSpeed { get; }
        public CriticalChance CriticalChance { get; }
        public CriticalDamage CriticalDamage { get; }

        public void TakeDamage(float damage)
        {
            _health = Health.TakeDamage(damage);
        }
        private Health _health;
    }
}
