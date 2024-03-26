using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameCore.Tool;
public class PlayAudioAction : AbstractAction
{
    //音频ID
    public int audioID;
    //音频持续时间
    public float audioExistTime;
    //音频音量大小
    public float audioVolume;
    //音频是否循环
    public bool isAudioLoop;
    //音频是否为3D音频
    public bool isAudio3D;
    //音频的类型：Music/Voice/Audio等
    public AudioData.AudioType audioType;
    //音频挂载在哪个物体下,2D默认为GameCore/AudioManager
    public GameObject audioParent;
    //要播放的音频
    public AudioClip audioClip;
    //默认音频音量
    public static float audioDefaultVolume = 0.25f;
    //常用情况:播放2D音频,ID为输入值
    public PlayAudioAction(int id):this(id, audioDefaultVolume) { }
    public PlayAudioAction(int id, float audiovolume) : this(id, audiovolume, false) { }
    public PlayAudioAction(int id,bool isloop) : this(id, audioDefaultVolume, isloop) { }
    //2D音频最复杂的形式:ID，音量，是否循环，音频类型
    public PlayAudioAction(int id,float audiovolume,bool isloop) : this(id, audiovolume, isloop, false, AudioData.Instance.Audio2DManager) { }
    //3D音频简洁版
    public PlayAudioAction(int id,bool is3D,GameObject audioparent) : this(id, audioDefaultVolume, false, is3D, audioparent) { }
    //3D音频完整版:ID，音量，是否循环，是否为3D,要挂载到的父物体
    public PlayAudioAction(int id, float audiovolume, bool isloop, bool is3D,GameObject audioparent)
    {
        //设置id 音量 是否循环 是否3D，音频类型自动分配
        audioID = id;
        audioVolume = audiovolume;
        isAudioLoop = isloop;
        isAudio3D = is3D;
        audioType = AudioData.Instance.GetAudioType(id);
        if (is3D)
        {
            audioParent = audioparent;
        }
        else
        {
            audioParent = AudioData.Instance.Audio2DManager;
        }
        audioClip = AudioData.Instance.GetAudioClip(id);
    }
    // Update is called once per frame
    public override void Update()
    {

        GameObject audioPrefab = GameObject.Instantiate(AudioData.Instance.AudioPrefab);

        AudioSource prefabSource = audioPrefab.GetComponent<AudioSource>();

        //设置音频基本参数:音量 是否循环 是否3D 
        prefabSource.volume = audioVolume;
        prefabSource.loop = isAudioLoop;
        prefabSource.spatialBlend = Convert.ToInt32(isAudio3D);
        //设置音频ID
        audioPrefab.GetComponent<AudioPrefabScript>().audioID = audioID;
        //设置音频所属轨道
        prefabSource.outputAudioMixerGroup = AudioData.Instance.Audiomixer.FindMatchingGroups(GameParameter.AudioMixerParentName)[AudioData.Instance.GetTypeID(audioID)];

        //设置GameObject的Tag和名字
        audioPrefab.tag = audioType.ToString();
        audioPrefab.name = audioID + "." + audioClip.name + "." + audioType;
        //设置音频位置和挂载
        audioPrefab.transform.position = audioParent.transform.position;
        audioPrefab.transform.parent = audioParent.transform;

        //将音频Object添加到管理列表
        AudioData.Instance.AddAudioObject(audioPrefab);
        //让播放器播放音频
        prefabSource.PlayOneShot(audioClip);

        isCompleted = true;

    }

}
