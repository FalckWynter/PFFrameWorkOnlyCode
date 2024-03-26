using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreCenter : MonoBehaviour
{
    //游戏是否开始
    public bool isGameStarted;
    //数据是否载入完毕
    public bool isGameDataLoadedSuccess = false;
    private void Awake()
    {
        //锁帧
        Application.targetFrameRate = 60;

        //将核心脚本设置到各个Game脚本中
        SetGameCore();

        //载入Excel数据
        LoadData();

        isGameDataLoadedSuccess = true;


    }
    //将核心脚本设置到各个Game脚本中
    public void SetGameCore()
    {

        //设置GameData中的核心
        GameData.GameCoreCenter = this.GetComponent<GameCoreCenter>();
        //设定GameComponent中的核心
        //GameComponent.GameCore = this.GetComponent<GameCore>();
    }
    //载入Excel数据
    public void LoadData()
    {
        //必须最先载入的数据，如文件数据
        GameData.Initialize();

        //ImageData.Initialize();

        //第二顺序载入的数据，如游戏开始时就存在的、需要文件数据的内容

        //UIData.Initialize();

        //最后载入的数据，通常为游戏进行时生成的实体数据


    }

    // Start is called before the first frame update
    void Start()
    {




    }
    //生成预制体并返还GameObject
    public GameObject createObject(GameObject prefab)
    {
        prefab = Instantiate(prefab);
        return prefab;
    }
    // Update is called once per frame
    void Update()
    {
        //更新行动管理器
        GameActionManager.Instance.Update();
    }
}
/*
                   _ooOoo_
                  o8888888o
                  88" . "88
                  (| -_- |)
                  O\  =  /O
               ____/`---'\____
             .'  \\|     |//  `.
            /  \\|||  :  |||//  \
           /  _||||| -:- |||||-  \
           |   | \\\  -  /// |   |
           | \_|  ''\---/''  |   |
           \  .-\__  `-`  ___/-. /
         ___`. .'  /--.--\  `. . __
      ."" '<  `.___\_<|>_/___.'  >'"".
     | | :  `- \`.;`\ _ /`;.`/ - ` : | |
     \  \ `-.   \_ __\ /__ _/   .-` /  /
======`-.____`-.___\_____/___.-`____.-'======
                   `=---='
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
         鸣大钟一次！ 推动杠杆，启动活塞和泵

         鸣大钟两次！ 按下按钮，发动机点火，点燃涡轮，注入生命

         鸣大钟三次！ 齐声歌唱，赞美万机之神！

    =====================================
    2023/11/15 21:28 上香还愿
    2024/2/15 13:25 上个香拜一拜
*/
