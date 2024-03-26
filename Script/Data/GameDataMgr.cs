//using GameFramework.MusicManager;
//using GameFramework.PersistenceDataMgr;

public class GameDataMgr : Singleton<GameDataMgr>
{
    //public MusicData musicData;

    public override void Initialize()
    {
        //musicData = BinaryDataMgr.Instance.LoadData<MusicData>("MusicData");
        //if (musicData == null) musicData = new MusicData();
    }

    public void SaveMusicData()
    {
        //BinaryDataMgr.Instance.SaveData(musicData, "MusicData");
        //MusicMgr.Instance.UpdateMusicData();
    }
}