using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.Interfaces;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.SaveData.Variables;
using UnityEngine;

namespace ProjectKYS
{
    public static class SaveExtension
    {
        #region Vector
        public static Vector3SaveData ToSaveData(this Vector2 vector)
        {
            return new Vector3SaveData(vector.x, vector.y, 0);
        }
        public static Vector3SaveData ToSaveData(this Vector2Int vector)
        {
            return new Vector3SaveData(vector.x, vector.y, 0);
        }
        public static Vector3SaveData ToSaveData(this Vector3 vector)
        {
            return new Vector3SaveData(vector.x, vector.y, vector.z);
        }
        public static Vector3SaveData ToSaveData(this Vector3Int vector)
        {
            return new Vector3SaveData(vector.x, vector.y, vector.z);
        }

        public static Vector3 ToUnityVector(this Vector3SaveData saveVector)
        {
            return new Vector3(saveVector.X, saveVector.Y, saveVector.Z);
        }
        #endregion

        #region Scene Objects
        public static GameSceneObjectStateSaveData ToObjectStateSaveData(this SavableSceneObject saveObject)
        {
            return new GameSceneObjectStateSaveData(saveObject.ID, saveObject.gameObject.activeSelf);
        }
        #endregion
    }
}
