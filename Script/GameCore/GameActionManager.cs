using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameActionManager : Singleton<GameActionManager>
{

    //常规列表，每一帧清空
    public  List<AbstractAction> actionList = new List<AbstractAction>();
    //延迟列表，在主列表结束后结算
    public  List<AbstractAction> actionLateList = new List<AbstractAction>();
    //常驻列表，每一帧遍历一次
    public  List<AbstractAction> alwaysList = new List<AbstractAction>();
    //将Action添加到常规列表底部
    public  void AddToBottom(AbstractAction action)
    {
        actionList.Add(action);
        //Debug.Log("添加到列表底部:" + action + "当前队列数量:" + actionList.Count + "队列第一个:" + actionList[0]);

    }
    //将Action添加到常规列表顶部 *可能存在少许结算BUG，少用
    public  void AddToTop(AbstractAction action)
    {
        actionList.Insert(0, action);
    }
    //将Action添加到常规列表的第二个(当前行动结束后执行该行动)
    public  void AddToSecond(AbstractAction action)
    {
        actionList.Insert(1, action);
    }
    //将Action添加到常驻列表底部，常驻列表几乎不存在先后概念
    public  void AddToAlways(AbstractAction action)
    {
        alwaysList.Add(action);
    }
    //添加到延迟列表底部
    public  void AddToLate(AbstractAction action)
    {
        actionLateList.Add(action);
    }
    //更新Action
    public  void Update()
    {
        //如果没有要更新的Action，结束更新
        if (actionList.Count == 0 && alwaysList.Count == 0 && actionLateList.Count == 0)
            return;
        //如果常规列表还有行动
        while (actionList.Count != 0)
        {
            //且最顶上的行动还没有完成
            if (actionList[0].isCompleted == false)
            {
                //更新该行动
                actionList[0].Update();
            }
            else
            {
                //当前行动已完成 则删除该行动
                actionList.Remove(actionList[0]);
            }
        }
        //如果延迟列表还有行动
        while (actionLateList.Count != 0)
        {
            //且最顶上的行动还没有完成
            if (actionLateList[0].isCompleted == false)
            {
                //更新该行动
                actionLateList[0].Update();
            }
            else
            {
                //当前行动已完成 则删除该行动
                actionLateList.Remove(actionLateList[0]);
            }
        }
        //如果常驻列表还有行动
        if (alwaysList.Count != 0)
        {
            //建立临时列表
            List<AbstractAction> temp = new List<AbstractAction>();
            //遍历常驻列表中的行动
            foreach (AbstractAction action in alwaysList)
            {
                //更新行动
                action.Update();
                //如果该行动完成，则添加到删除列表中
                if (action.isCompleted == true)
                {
                    temp.Add(action);
                }
            }
            //删除临时列表中的行动
            foreach (AbstractAction action in temp)
            {
                alwaysList.Remove(action);
            }
        }
    }
}
