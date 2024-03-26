using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreCenter : MonoBehaviour
{
    //��Ϸ�Ƿ�ʼ
    public bool isGameStarted;
    //�����Ƿ��������
    public bool isGameDataLoadedSuccess = false;
    private void Awake()
    {
        //��֡
        Application.targetFrameRate = 60;

        //�����Ľű����õ�����Game�ű���
        SetGameCore();

        //����Excel����
        LoadData();

        isGameDataLoadedSuccess = true;


    }
    //�����Ľű����õ�����Game�ű���
    public void SetGameCore()
    {

        //����GameData�еĺ���
        GameData.GameCoreCenter = this.GetComponent<GameCoreCenter>();
        //�趨GameComponent�еĺ���
        //GameComponent.GameCore = this.GetComponent<GameCore>();
    }
    //����Excel����
    public void LoadData()
    {
        //����������������ݣ����ļ�����
        GameData.Initialize();

        //ImageData.Initialize();

        //�ڶ�˳����������ݣ�����Ϸ��ʼʱ�ʹ��ڵġ���Ҫ�ļ����ݵ�����

        //UIData.Initialize();

        //�����������ݣ�ͨ��Ϊ��Ϸ����ʱ���ɵ�ʵ������


    }

    // Start is called before the first frame update
    void Start()
    {




    }
    //����Ԥ���岢����GameObject
    public GameObject createObject(GameObject prefab)
    {
        prefab = Instantiate(prefab);
        return prefab;
    }
    // Update is called once per frame
    void Update()
    {
        //�����ж�������
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
         ������һ�Σ� �ƶ��ܸˣ����������ͱ�

         ���������Σ� ���°�ť����������𣬵�ȼ���֣�ע������

         ���������Σ� �����質���������֮��

    =====================================
    2023/11/15 21:28 ���㻹Ը
    2024/2/15 13:25 �ϸ����һ��
*/
