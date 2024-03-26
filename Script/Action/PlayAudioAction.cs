using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameCore.Tool;
public class PlayAudioAction : AbstractAction
{
    //��ƵID
    public int audioID;
    //��Ƶ����ʱ��
    public float audioExistTime;
    //��Ƶ������С
    public float audioVolume;
    //��Ƶ�Ƿ�ѭ��
    public bool isAudioLoop;
    //��Ƶ�Ƿ�Ϊ3D��Ƶ
    public bool isAudio3D;
    //��Ƶ�����ͣ�Music/Voice/Audio��
    public AudioData.AudioType audioType;
    //��Ƶ�������ĸ�������,2DĬ��ΪGameCore/AudioManager
    public GameObject audioParent;
    //Ҫ���ŵ���Ƶ
    public AudioClip audioClip;
    //Ĭ����Ƶ����
    public static float audioDefaultVolume = 0.25f;
    //�������:����2D��Ƶ,IDΪ����ֵ
    public PlayAudioAction(int id):this(id, audioDefaultVolume) { }
    public PlayAudioAction(int id, float audiovolume) : this(id, audiovolume, false) { }
    public PlayAudioAction(int id,bool isloop) : this(id, audioDefaultVolume, isloop) { }
    //2D��Ƶ��ӵ���ʽ:ID���������Ƿ�ѭ������Ƶ����
    public PlayAudioAction(int id,float audiovolume,bool isloop) : this(id, audiovolume, isloop, false, AudioData.Instance.Audio2DManager) { }
    //3D��Ƶ����
    public PlayAudioAction(int id,bool is3D,GameObject audioparent) : this(id, audioDefaultVolume, false, is3D, audioparent) { }
    //3D��Ƶ������:ID���������Ƿ�ѭ�����Ƿ�Ϊ3D,Ҫ���ص��ĸ�����
    public PlayAudioAction(int id, float audiovolume, bool isloop, bool is3D,GameObject audioparent)
    {
        //����id ���� �Ƿ�ѭ�� �Ƿ�3D����Ƶ�����Զ�����
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

        //������Ƶ��������:���� �Ƿ�ѭ�� �Ƿ�3D 
        prefabSource.volume = audioVolume;
        prefabSource.loop = isAudioLoop;
        prefabSource.spatialBlend = Convert.ToInt32(isAudio3D);
        //������ƵID
        audioPrefab.GetComponent<AudioPrefabScript>().audioID = audioID;
        //������Ƶ�������
        prefabSource.outputAudioMixerGroup = AudioData.Instance.Audiomixer.FindMatchingGroups(GameParameter.AudioMixerParentName)[AudioData.Instance.GetTypeID(audioID)];

        //����GameObject��Tag������
        audioPrefab.tag = audioType.ToString();
        audioPrefab.name = audioID + "." + audioClip.name + "." + audioType;
        //������Ƶλ�ú͹���
        audioPrefab.transform.position = audioParent.transform.position;
        audioPrefab.transform.parent = audioParent.transform;

        //����ƵObject��ӵ������б�
        AudioData.Instance.AddAudioObject(audioPrefab);
        //�ò�����������Ƶ
        prefabSource.PlayOneShot(audioClip);

        isCompleted = true;

    }

}
