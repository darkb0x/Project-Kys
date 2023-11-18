using ProjectKYS.Infrasturcture.Services;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            float sphereRadius = .2f;
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, sphereRadius);
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        }

        private void Awake()
        {
            var player = ServiceLocator.Instance.Get<PlayerController>();

            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
        }
    }
}