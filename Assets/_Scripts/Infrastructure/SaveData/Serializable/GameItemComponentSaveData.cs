using ProjectKYS.Infrasturcture.SaveData.Variables;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData
{
    public class GameItemComponentSaveData : GameSceneObjectSaveData
    {
        public Vector3SaveData Position;
        public Vector3SaveData Rotation;
        public int SlotIndex;

        public GameItemComponentSaveData(int id, bool enabled, Vector3SaveData position, Vector3SaveData rotation, int slotindex) : base(id, enabled)
        {
            Position = position;
            Rotation = rotation;
            SlotIndex = slotindex;
        }
    }
}