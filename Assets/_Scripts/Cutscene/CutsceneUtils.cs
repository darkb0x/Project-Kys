using ProjectKYS.Player;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Cutscene
{
    public class CutsceneUtils : MonoBehaviour
    {
        public void Intialize(PlayerController player)
        {

        }

        public void SetFogEnabled(bool value)
        {
            RenderSettings.fog = value;
        }
    }
}