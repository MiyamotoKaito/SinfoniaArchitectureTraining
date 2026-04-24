using UnityEngine;
using UnityEngine.AI;

namespace View
{
    public class MinionMove : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private MinionView _target;
        private float _speed;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(_target == null)
            {
                _target = FindAnyObjectByType<MinionView>();
            }
            if (_target != null)
            {
                _agent.SetDestination(_target.transform.position);
            }
        }
    }
}
