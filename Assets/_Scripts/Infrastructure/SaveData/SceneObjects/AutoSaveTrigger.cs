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
        [SerializeField, OnValueChanged("OnSizeChanged"), HideIf("IsColliderNull")] private Vector3 _size = new Vector3(1, 1, 1);
        [SerializeField] private BoxCollider _collider;

        private ISaveService _saveService;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.3f);
            Gizmos.DrawCube(transform.position, _size);
        }
        private void OnSizeChanged()
        {
            if (IsColliderNull())
                return;

            _collider.size = _size;
        }
        private bool IsColliderNull() => _collider == null;

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
