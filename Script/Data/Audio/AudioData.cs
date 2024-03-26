using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using GameCore.Tool;
public class AudioData : Singleton<AudioData>
{
    //��Ƶ·����
    public List<List<string[]>> AudioPath;
    /*
     *ȡIDͷλ��(��Ƶ���):��ƵID/�������(�Զ�ȡ��),clipID / GameParameter.AUDIO_Range
     *ȡID��λ��(��Ƶ���):��ƵID-��Ƶͷλ��*�������,clipID - ((clipID / GameParameter.AUDIO_Range) * GameParameter.AUDIO_Range)
     *��ȡ˳��:AudioPath[Ҫ���õı��][Ҫ���õ��к�][Ҫ���õ��к�(Ĭ����1����)]
     *ȡĸ·��:AudioPath[0][IDͷλ��][~]
     *ȡ��·��:AudioPath[IDͷλ��][ID��λ��][~]
    /*
    //0�� Parent ĸ·����
    public List<string[]> PATH_Parent = new List<string[]>();
    //1�� Music ���ֵ�·��
    public List<string[]> PATH_Music = new List<string[]>();
    //2�� Voice ������·��
    public List<string[]> PATH_Voice = new List<string[]>();
    //3�� Audio ��Ч��·��
    public List<string[]> PATH_Audio = new List<string[]>();
    */
    public string Path;
    //��ƵԤ����
    public GameObject AudioPrefab;
    //2D��Ƶ����Object
    public GameObject Audio2DManager;
    //��Ƶ�����AudioMixer
    public AudioMixer Audiomixer;
    //��ƵObject�б�
    public List<List<GameObject>> MusicObject = new List<List<GameObject>> { new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>() };

    public string NAME_AudioManagerObject = "AudioManagerObject";
    public string NAME_BackgroundObject = "BackgroundSource";
    public string NAME_VoiceObject = "VoiceSource";
    public string NAME_AudioObject = "AudioSource";


    public override void Initialize()
    {
        //������Ч���ӹ��ò����е��ò�����·��
        AudioPath = GameComponent.LoadExcelDataByPath(GameParameter.AudioExcelPath);
        //������ЧԤ����
        AudioPrefab = Resources.Load<GameObject>(GameParameter.AudioPrefabPath);
        //������ЧMixer
        Audiomixer = Resources.Load<AudioMixer>(GameParameter.AudioMixerPath);
        //����2D��Ч����Object
        Audio2DManager = GameObject.Find(GameParameter.Audio2DManagerPath);
        base.Initialize();
    }
    public AudioClip GetAudioClip(int clipID)
    {
        AudioClip temp;
        //ȡIDͷλ�����������ͣ�ȡID��λ������Ƶ����
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
