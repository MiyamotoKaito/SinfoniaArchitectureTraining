using UnityEngine;

namespace View
{
    /// <summary>
    /// 各陣営のミニオンを管理するレジストリ。
    /// </summary>
    public class MinionRegistry
    {
        private MinionView _teamAMinion;
        private MinionView _teamBMinion;

        /// <summary>
        /// 指定した陣営にミニオンを登録する。
        /// </summary>
        public void Register(Team team, MinionView minion)
        {
            if (team == Team.A) { _teamAMinion = minion; }
            else { _teamBMinion = minion; }
        }

        /// <summary>
        /// 指定した陣営の敵ミニオンを返す。
        /// </summary>
        public MinionView GetEnemy(Team team)
        {
            return team == Team.A ? _teamBMinion : _teamAMinion;
        }
    }
}
