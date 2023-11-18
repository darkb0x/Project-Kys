using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Test
{
    public class InteractTest : Interactable
    {
        public override string InteractableName => "Test";

        public override void Interact()
        {
            gameObject.SetActive(false);
        }
    }
}
