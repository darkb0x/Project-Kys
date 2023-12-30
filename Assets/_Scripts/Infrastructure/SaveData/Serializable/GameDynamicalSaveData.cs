using System;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData
{
    public class GameDynamicalSaveData : GameSceneObjectSaveData
    {
        #region Data
        [Serializable]
        public class Data
        {
            public string Key;
        }

        public class DataFloat : Data
        {
            public float Value;

            public DataFloat(string key, float value)
            {
                Key = key;
                Value = value;
            }
        }
        public class DataString : Data
        {
            public string Value;

            public DataString(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }
        public class DataBool : Data
        {
            public bool Value;

            public DataBool(string key, bool value)
            {
                Key = key;
                Value = value;
            }
        }
        #endregion

        [SerializeReference] public Data[] DataList;

        public GameDynamicalSaveData(params Data[] dataList) : base(0, false)
        {
            DataList = dataList;
        }

        public TData GetData<TData>(string key) where TData : Data
        {
            foreach (var item in DataList)
            {
                if (item.Key == key)
                    return item as TData;
            }
            return null;
        }
        public bool GetData<TData>(string key, out TData output) where TData : Data
        {
            foreach (var item in DataList)
            {
                if (item.Key == key)
                {
                    output = item as TData;
                    return true;
                }
            }
            output = null;
            return false;
        }
    }
}
