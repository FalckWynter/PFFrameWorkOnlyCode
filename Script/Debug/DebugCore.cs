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
        //将输入的info添加到存储表中
        debugInfoList.Add(info);
        //如果info的type和level都可以被添加
        if (isTypeAreAllowAdd(info) && isLevelAreAllowAdd(info))
        {
            //广播info
            SendDebugMessageEvent.Invoke(info.debugMessage);
        }
    }
    //对应的tag是否允许展示
    public static bool isTypeAreAllowAdd(DebugInfo info)
    {
        //如果对应位置的type允许展示
        if (debugTypeAllowList[(int)info.debugMessageType] == true)
        {
            return true;
        }
        else
            return false;
    }
    public static bool isLevelAreAllowAdd(DebugInfo info)
    {
        //如果对应位置的level允许展示
        if (debugLevelAllowList[(int)info.debugMessageLevel] == true)
        {
            return true;
        }
        else
            return false;
    }
    //增删对Debug信息的订阅
    public static void AddListen_SendMessage(UnityAction<string> eventToAdd)
    {
        SendDebugMessageEvent.AddListener(eventToAdd);
    }
    public static void RemoveListen_SendMessage(UnityAction<string> eventToRemove)
    {
        SendDebugMessageEvent.RemoveListener(eventToRemove);
    }
    //重设所有选项为真
    public static void ResetListToTrue()
    {
        debugLevelAllowList.AddRange(Enumerable.Repeat(true, Enum.GetValues(typeof(DebugInfo.DebugMessageLevel)).Length));
        debugTypeAllowList.AddRange(Enumerable.Repeat(true, Enum.GetValues(typeof(DebugInfo.DebugMessageType)).Length));

    }
}
