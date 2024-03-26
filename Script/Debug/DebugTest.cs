using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public void TrySend(string msg)
    {
        Debug.Log(msg);
    }
    // Start is called before the first frame update
    void Start()
    {
        DebugCore.AddListen_SendMessage(TrySend);
        //DebugCore.SendDebugMessageEvent.Invoke("≤‚ ‘");

        DebugCore.ResetListToTrue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
