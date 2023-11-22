using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Menu
{
    public class StartGameController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public void Initialize()
        {

        }

        private void Close()
        {
            _panel.SetActive(false);
        }
    }
}
