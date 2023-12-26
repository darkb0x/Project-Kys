using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.Services.Factory;
using ProjectKYS.Infrasturcture.Services.HUD;
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

        public PlayerController SpawnPlayer(Infrasturcture.Services.Input.IInputService inputService, IHUDService hudService)
        {
            var player = ServiceLocator.Instance.Get<IGameFactory>().CreatePlayer(inputService, hudService);
            player.PlayerMove.SetPositionAndRotation(transform.position, transform.eulerAngles);
            player.PlayerLook.ResetOrigin();

            return player;
        }
    }
}