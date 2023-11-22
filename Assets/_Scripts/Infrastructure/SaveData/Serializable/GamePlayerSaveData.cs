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

        public GamePlayerSaveData()
        {
            PlayerPos = new Vector3SaveData();
            PlayerRot = new Vector3SaveData();
            PlayerCameraRot = new Vector3SaveData();
        }
        public GamePlayerSaveData(Vector3SaveData playerPos, Vector3SaveData playerRot, Vector3SaveData playerCameraRot)
        {
            PlayerPos = playerPos;
            PlayerRot = playerRot;
            PlayerCameraRot = playerCameraRot;
        }
    }
}
