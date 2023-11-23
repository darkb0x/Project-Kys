using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GamePlayerOrientationSaveData
    {
        public Vector3SaveData PlayerPos;
        public Vector3SaveData PlayerRot;
        public Vector3SaveData PlayerCameraRot;
        public bool Empty;

        public GamePlayerOrientationSaveData()
        {
            PlayerPos = new Vector3SaveData();
            PlayerRot = new Vector3SaveData();
            PlayerCameraRot = new Vector3SaveData();
            Empty = true;
        }
        public GamePlayerOrientationSaveData(Vector3SaveData playerPos, Vector3SaveData playerRot, Vector3SaveData playerCameraRot)
        {
            PlayerPos = playerPos;
            PlayerRot = playerRot;
            PlayerCameraRot = playerCameraRot;
            Empty = false;
        }
    }
}
