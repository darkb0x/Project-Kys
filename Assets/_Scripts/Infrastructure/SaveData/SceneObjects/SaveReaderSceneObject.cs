using ProjectKYS.Infrasturcture.SaveData.Interfaces;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public abstract class SaveReaderSceneObject : MonoBehaviour, ISaveReaderObject
    {
        public virtual void Load(GameProgressSaveData save) { }
    }
}