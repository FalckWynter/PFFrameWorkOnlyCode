using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Tool;
public static class GameData
{
    public static GameCoreCenter GameCoreCenter;
    //信息管理Object
    public static GameObject MessageManagerObject;
    //选择管理Object
    public static GameObject SelectManagerObject;
    //卡牌管理Object
    public static GameObject CardManagerObject;
    //初始化
    public static void Initialize()
    {
        //载入Object
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
