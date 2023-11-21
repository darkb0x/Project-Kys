using ProjectKYS.Infrasturcture.SaveData.Interfaces;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public abstract class SaveReaderSceneObject : MonoBehaviour, ISaveReaderObject
    {
        public abstract void Load(GameProgressSaveData save);
    }
}