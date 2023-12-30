using NaughtyAttributes;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public class AutoSaveTrigger : SavableSceneObject
    {
        [SerializeField] private BoxCollider _collider;

        private ISaveService _saveService;

        private void OnDrawGizmos()
        {
            if (_collider == null)
                return;

            Gizmos.color = new Color(0, 0, 1, 0.3f);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }

        private void Awake()
        {
            _saveService = ServiceLocator.Instance.Get<ISaveService>();
        }

        private void Save()
        {
            _saveService.Save(_saveService.SaveData.SaveIndex);
            gameObject.SetActive(false);
            Debug.Log("Auto Save");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerController _))
            {
                Save();
            }
        }

        public override GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            return new GameSceneObjectSaveData(ID, gameObject.activeSelf);
        }

        public override void Load(GameProgressSaveData save, GameSceneObjectSaveData objSave)
        {
            gameObject.SetActive(objSave.Enabled);
        }
    }
}
