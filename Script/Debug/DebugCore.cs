using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;
public static class DebugCore
{
    public static List<DebugInfo> debugInfoList;

    public static List<bool> debugLevelAllowList = new List<bool>(Enum.GetValues(typeof(DebugInfo.DebugMessageLevel)).Length);

    public static List<bool> debugTypeAllowList = new List<bool>(Enum.GetValues(typeof(DebugInfo.DebugMessageType)).Length);

    public static SendDebugMessageClass SendDebugMessageEvent = new SendDebugMessageClass();

    public class SendDebugMessageClass : UnityEvent<string> { }

    public static void Log()
    {
        Log(50001);
    }
    public static void Log(int debugID)
    {
        AddDebugInfo(DebugData.GetDebugInfoByID_NoValue(debugID));
    }
    public static void AddDebugInfo(DebugInfo info)
    {
        //�������info��ӵ��洢����
        debugInfoList.Add(info);
        //���info��type��level�����Ա����
        if (isTypeAreAllowAdd(info) && isLevelAreAllowAdd(info))
        {
            //�㲥info
            SendDebugMessageEvent.Invoke(info.debugMessage);
        }
    }
    //��Ӧ��tag�Ƿ�����չʾ
    public static bool isTypeAreAllowAdd(DebugInfo info)
    {
        //�����Ӧλ�õ�type����չʾ
        if (debugTypeAllowList[(int)info.debugMessageType] == true)
        {
            return true;
        }
        else
            return false;
    }
    public static bool isLevelAreAllowAdd(DebugInfo info)
    {
        //�����Ӧλ�õ�level����չʾ
        if (debugLevelAllowList[(int)info.debugMessageLevel] == true)
        {
            return true;
        }
        else
            return false;
    }
    //��ɾ��Debug��Ϣ�Ķ���
    public static void AddListen_SendMessage(UnityAction<string> eventToAdd)
    {
        SendDebugMessageEvent.AddListener(eventToAdd);
    }
    public static void RemoveListen_SendMessage(UnityAction<string> eventToRemove)
    {
        SendDebugMessageEvent.RemoveListener(eventToRemove);
    }
    //��������ѡ��Ϊ��
    public static void ResetListToTrue()
    {
        debugLevelAllowList.AddRange(Enumerable.Repeat(true, Enum.GetValues(typeof(DebugInfo.DebugMessageLevel)).Length));
        debugTypeAllowList.AddRange(Enumerable.Repeat(true, Enum.GetValues(typeof(DebugInfo.DebugMessageType)).Length));

    }
}
