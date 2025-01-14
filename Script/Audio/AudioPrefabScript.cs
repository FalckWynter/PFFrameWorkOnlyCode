using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrefabScript : MonoBehaviour
{
    public int audioID;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (source.isPlaying == false)
        {
            AudioData.Instance.RemoveAudioObject(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void SetAudioID(int id)
    {
        audioID = id;
    }
    public int GetAudioID()
    {
        return audioID;
    }
}
