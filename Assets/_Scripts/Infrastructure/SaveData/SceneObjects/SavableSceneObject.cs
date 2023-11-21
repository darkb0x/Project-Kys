using NaughtyAttributes;
using ProjectKYS.Infrasturcture.SaveData.Interfaces;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public abstract class SavableSceneObject : SaveReaderSceneObject, ISaveObject
    {
        [SerializeField] protected int _id;

        public int ID => _id;

        public abstract void Save(GameProgressSaveData save);

        [Button]
        protected void GenerateID()
        {
            _id = Random.Range(0, 10000);
        }
    }
}