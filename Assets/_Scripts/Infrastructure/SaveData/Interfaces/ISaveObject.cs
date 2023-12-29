namespace ProjectKYS.Infrasturcture.SaveData.Interfaces
{
    public interface ISaveObject : ISaveReaderObject
    {
        public int ID { get; }
        GameSceneObjectSaveData Save(GameProgressSaveData save);
    }
}
