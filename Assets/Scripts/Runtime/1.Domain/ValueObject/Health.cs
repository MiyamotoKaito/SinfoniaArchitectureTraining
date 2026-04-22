using System;

namespace Domain
{
    /// <summary>
    ///     ミニオンの体力を表すValueObject
    /// </summary>
    public readonly struct Health : IEquatable<Health>
    {
        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="hp">初期体力</param>
        public Health(float hp)
        {
            //　コンストラクタの引数が1未満の場合は例外を投げる
            //  存在してはいけないインスタンスはそもそも生成されないようにするため
            if (hp < 1)
            {
                throw new ArgumentOutOfRangeException("初期体力は1以上で無ければならない" + (nameof(hp)));
            }
            _hp = hp;
        }
        /// <summary>体力のプロパティ</summary>
        public float Hp => _hp;
        /// <summary>
        ///     値を減らす処理
        ///     新しいHealthオブジェクトを返す
        ///     ValueObjectは値の変更ができないため、減らす処理は新しいオブジェクトを返す形で実装する
        /// </summary>
        /// <param name="damage"></param>
        public Health TakeDamage(float damage)
        {
            return new Health(Hp - damage);
        }
        public bool IsDead() => Hp <= 0;
        /// <summary>
        ///     指定されたHealthオブジェクトと等しいかどうかを判断する(同値性)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Health other) => Hp == other.Hp;

        /// <summary>体力のフィールド変数(書き換え不能)</summary>
        private readonly float _hp;
    }
}
