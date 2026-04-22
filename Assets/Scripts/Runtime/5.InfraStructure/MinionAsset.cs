using UnityEngine;

namespace InfraStructure
{
    /// <summary>
    ///     ミニオンの初期設定を保存するSO
    /// </summary>
    [CreateAssetMenu(fileName = "MinionAsset", menuName = "Scriptable Objects/Asset/MinionAsset")]
    public class MinionAsset : ScriptableObject
    {
        #region プロパティ
        /// <summary> 体力 </summary>
        public int Health => _health;
        /// <summary> 防御力 </summary>
        public int Defense => _defense;
        /// <summary> 移動速度 </summary>
        public float MoveSpeed => _moveSpeed;
        /// <summary> 攻撃力 </summary>
        public int AttackPower => _attackPower;
        /// <summary> 攻撃距離 </summary>
        public float AttackRange => _attackRange;
        /// <summary> 攻撃速度 </summary>
        public float AttackSpeed => _attackSpeed;
        /// <summary> クリティカル率 </summary>
        public float CriticalChance => _CriticalChance;
        /// <summary> クリティカル倍率 </summary>
        public float CriticalDamage => _CriticalDamage;
        #endregion

        #region Private変数
        [Header("体力")]
        [SerializeField, Tooltip("体力")] private int _health;

        [Header("防御力")]
        [SerializeField, Tooltip("防御力")] private int _defense;

        [Header("移動速度")]
        [SerializeField, Tooltip("移動速度")] private float _moveSpeed;

        [Header("攻撃力")]
        [SerializeField, Tooltip("攻撃力")] private int _attackPower;

        [SerializeField, Tooltip("攻撃距離")] private float _attackRange;

        [SerializeField, Tooltip("攻撃速度")] private float _attackSpeed;

        [SerializeField, Tooltip("クリティカル率")] private float _CriticalChance;

        [SerializeField, Tooltip("クリティカル倍率")] private float _CriticalDamage;
        #endregion
    }
}
