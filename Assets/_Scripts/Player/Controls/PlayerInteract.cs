using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player.Controls
{
    public class PlayerInteract : MonoBehaviour
    {
        public const KeyCode INTERACTION_BUTTON = KeyCode.E;

        [SerializeField] private Camera _camera;
        [SerializeField] private float _rayDistance;
        [SerializeField] private LayerMask _interactableLayers;

        private void OnDrawGizmosSelected()
        {
            if (_camera == null)
                return;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + _camera.transform.forward * _rayDistance);
        }


        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(new Ray(_camera.transform.position, _camera.transform.forward), out hit, _rayDistance, _interactableLayers))
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                {
                    if (!interactable.IsInteractable)
                        return;

                    if(Input.GetKeyDown(INTERACTION_BUTTON))
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}