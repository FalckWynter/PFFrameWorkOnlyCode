using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Tool;
public static class GameData
{
    public static GameCoreCenter GameCoreCenter;
    //��Ϣ����Object
    public static GameObject MessageManagerObject;
    //ѡ�����Object
    public static GameObject SelectManagerObject;
    //���ƹ���Object
    public static GameObject CardManagerObject;
    //��ʼ��
    public static void Initialize()
    {
        //����Object
        MessageManagerObject = GameObject.Find(GameParameter.UIMessageManagerPath);
        SelectManagerObject = GameObject.Find(GameParameter.UISelectManagerPath);
        //CreateCardObject = GameComponent.GameCore
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
