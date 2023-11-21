using System;

namespace ProjectKYS.Infrasturcture.SaveData.Variables
{
    [Serializable]
    public class Vector3SaveData
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3SaveData()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Vector3SaveData(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
