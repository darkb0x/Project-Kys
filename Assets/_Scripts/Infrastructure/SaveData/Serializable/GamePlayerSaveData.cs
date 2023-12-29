using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GamePlayerSaveData
    {
        public Vector3SaveData PlayerPos;
        public Vector3SaveData PlayerRot;
        public Vector3SaveData PlayerCameraRot;
        public bool Empty;
        public int SelectedSlot;

        public GamePlayerSaveData()
        {
            PlayerPos = new Vector3SaveData();
            PlayerRot = new Vector3SaveData();
            PlayerCameraRot = new Vector3SaveData();
            Empty = true;
            SelectedSlot = 0;
        }
        public GamePlayerSaveData(Vector3SaveData playerPos, Vector3SaveData playerRot, Vector3SaveData playerCameraRot, int selectedSlot)
        {
            PlayerPos = playerPos;
            PlayerRot = playerRot;
            PlayerCameraRot = playerCameraRot;
            Empty = false;
            SelectedSlot = selectedSlot;
        }
    }
}
