using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectKYS.SceneProps
{
    public class StalkingBloodSpot : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _distanceFromPlayer;

        private PlayerController _player;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            if(_startPosition != null)
                Gizmos.DrawCube(_startPosition.position, new Vector3(0.2f, 0.2f, 2));
            if(_endPosition != null)
                Gizmos.DrawCube(_endPosition.position, new Vector3(0.2f, 0.2f, 2));

            Gizmos.DrawLine(transform.position, transform.position - new Vector3(_distanceFromPlayer, 0, 0));
        }

        public void Initialize(PlayerController player)
        {
            _player = player;
        }

        private void LateUpdate()
        {
            if (_player == null)
                return;

            if (!PlayerIsLooking())
                Move();
        }

        private bool PlayerIsLooking()
        {
            Vector3 direction = (transform.position - _player.transform.position).normalized;
            float dot = Vector3.Dot(direction, _player.transform.forward.normalized);

            if (dot > 0)
                return true;

            return false;
        }
        private void Move()
        {
            float x = Mathf.Clamp(_player.transform.position.x + _distanceFromPlayer, _endPosition.position.x, _startPosition.position.x);
            Vector3 target = new Vector3(x, transform.position.y, transform.position.z);

            if(x < transform.position.x)
                transform.position = target;
        }
    }
}
