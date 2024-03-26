using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameActionManager : Singleton<GameActionManager>
{

    //�����б�ÿһ֡���
    public  List<AbstractAction> actionList = new List<AbstractAction>();
    //�ӳ��б������б���������
    public  List<AbstractAction> actionLateList = new List<AbstractAction>();
    //��פ�б�ÿһ֡����һ��
    public  List<AbstractAction> alwaysList = new List<AbstractAction>();
    //��Action��ӵ������б�ײ�
    public  void AddToBottom(AbstractAction action)
    {
        actionList.Add(action);
        //Debug.Log("��ӵ��б�ײ�:" + action + "��ǰ��������:" + actionList.Count + "���е�һ��:" + actionList[0]);

    }
    //��Action��ӵ������б��� *���ܴ����������BUG������
    public  void AddToTop(AbstractAction action)
    {
        actionList.Insert(0, action);
    }
    //��Action��ӵ������б�ĵڶ���(��ǰ�ж�������ִ�и��ж�)
    public  void AddToSecond(AbstractAction action)
    {
        actionList.Insert(1, action);
    }
    //��Action��ӵ���פ�б�ײ�����פ�б����������Ⱥ����
    public  void AddToAlways(AbstractAction action)
    {
        alwaysList.Add(action);
    }
    //��ӵ��ӳ��б�ײ�
    public  void AddToLate(AbstractAction action)
    {
        actionLateList.Add(action);
    }
    //����Action
    public  void Update()
    {
        //���û��Ҫ���µ�Action����������
        if (actionList.Count == 0 && alwaysList.Count == 0 && actionLateList.Count == 0)
            return;
        //��������б����ж�
        while (actionList.Count != 0)
        {
            //����ϵ��ж���û�����
            if (actionList[0].isCompleted == false)
            {
                //���¸��ж�
                actionList[0].Update();
            }
            else
            {
                //��ǰ�ж������ ��ɾ�����ж�
                actionList.Remove(actionList[0]);
            }
        }
        //����ӳ��б����ж�
        while (actionLateList.Count != 0)
        {
            //����ϵ��ж���û�����
            if (actionLateList[0].isCompleted == false)
            {
                //���¸��ж�
                actionLateList[0].Update();
            }
            else
            {
                //��ǰ�ж������ ��ɾ�����ж�
                actionLateList.Remove(actionLateList[0]);
            }
        }
        //�����פ�б����ж�
        if (alwaysList.Count != 0)
        {
            //������ʱ�б�
            List<AbstractAction> temp = new List<AbstractAction>();
            //������פ�б��е��ж�
            foreach (AbstractAction action in alwaysList)
            {
                //�����ж�
                action.Update();
                //������ж���ɣ�����ӵ�ɾ���б���
                if (action.isCompleted == true)
                {
                    temp.Add(action);
                }
            }
            //ɾ����ʱ�б��е��ж�
            foreach (AbstractAction action in temp)
            {
                alwaysList.Remove(action);
            }
        }
    }
}
