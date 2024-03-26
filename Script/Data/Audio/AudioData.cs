using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using GameCore.Tool;
public class AudioData : Singleton<AudioData>
{
    //音频路径表
    public List<List<string[]>> AudioPath;
    /*
     *取ID头位数(音频类别):音频ID/分类距离(自动取整),clipID / GameParameter.AUDIO_Range
     *取ID子位数(音频编号):音频ID-音频头位数*分类距离,clipID - ((clipID / GameParameter.AUDIO_Range) * GameParameter.AUDIO_Range)
     *调取顺序:AudioPath[要调用的表号][要调用的行号][要调用的列号(默认填1即可)]
     *取母路径:AudioPath[0][ID头位数][~]
     *取子路径:AudioPath[ID头位数][ID子位数][~]
    /*
    //0号 Parent 母路径表
    public List<string[]> PATH_Parent = new List<string[]>();
    //1号 Music 音乐的路径
    public List<string[]> PATH_Music = new List<string[]>();
    //2号 Voice 语音的路径
    public List<string[]> PATH_Voice = new List<string[]>();
    //3号 Audio 音效的路径
    public List<string[]> PATH_Audio = new List<string[]>();
    */
    public string Path;
    //音频预制体
    public GameObject AudioPrefab;
    //2D音频管理Object
    public GameObject Audio2DManager;
    //音频混合器AudioMixer
    public AudioMixer Audiomixer;
    //音频Object列表
    public List<List<GameObject>> MusicObject = new List<List<GameObject>> { new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>() };

    public string NAME_AudioManagerObject = "AudioManagerObject";
    public string NAME_BackgroundObject = "BackgroundSource";
    public string NAME_VoiceObject = "VoiceSource";
    public string NAME_AudioObject = "AudioSource";


    public override void Initialize()
    {
        //载入音效表，从公用参数中调用并输入路径
        AudioPath = GameComponent.LoadExcelDataByPath(GameParameter.AudioExcelPath);
        //载入音效预制体
        AudioPrefab = Resources.Load<GameObject>(GameParameter.AudioPrefabPath);
        //载入音效Mixer
        Audiomixer = Resources.Load<AudioMixer>(GameParameter.AudioMixerPath);
        //载入2D音效管理Object
        Audio2DManager = GameObject.Find(GameParameter.Audio2DManagerPath);
        base.Initialize();
    }
    public AudioClip GetAudioClip(int clipID)
    {
        AudioClip temp;
        //取ID头位数得所属类型，取ID子位数得音频名字
        string path = GameParameter.AudioBasicPath + AudioPath[0][GetTypeID(clipID)][GameParameter.AudioExcelPathPlace]
            + "/" + AudioPath[GetTypeID(clipID)][GetCountID(clipID)][GameParameter.AudioExcelPathPlace];
        temp = Resources.Load<AudioClip>(path);
        return temp;
    }
    public void AddAudioObject(GameObject audioObject)
    {
        int id = audioObject.GetComponent<AudioPrefabScript>().audioID;
        MusicObject[GetTypeID(id)].Add(audioObject);
    }
    public void RemoveAudioObject(GameObject audioObject)
    {
        int id = audioObject.GetComponent<AudioPrefabScript>().audioID;
        MusicObject[GetTypeID(id)].Remove(audioObject);
    }
    public int GetCountID(int clipID)
    {
        return (clipID - ((clipID / GameParameter.AUDIO_Range) * GameParameter.AUDIO_Range));
    }
    public int GetTypeID(int clipID)
    {
        return clipID / GameParameter.AUDIO_Range;
    }

    public AudioType GetAudioType(int clipID)
    {
        return (AudioType)Enum.ToObject(typeof(AudioType), clipID / GameParameter.AUDIO_Range);

    }
    public enum AudioType
    {
        Sound, Music, Voice, Audio, None
    }

    // Start is called before the first frame 
}
