using System.Collections;
using UnityEngine;

namespace ProjectKYS.Test
{
    public class DoorTest : InteractableWithRequirableItem
    {
        [SerializeField] private GameObject _doorObj;

        public override void Interact()
        {
            _doorObj.SetActive(!_doorObj.activeSelf);
            base.Interact();
        }
    }
}