using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Tool;
public static class DebugData
{
    //实现的功能
    //存储
    //
    //写入
    //
    //取出
    //
    //数据表
    public static List<List<string[]>> Data = new List<List<string[]>>();
    //Debug数据表路径
    public static string DebugExcel_Path = Application.dataPath + "/Resources/DataExcel/Debug/DebugDataExcel.xls";
    //Debug表等级位置
    public static int DataExcel_Level_Place = 1;
    //Debug表类型位置
    public static int DataExcel_Type_Place = 2;
    //Debug文本位置
    public static int DebugExcel_Message_Place = 3;


    static DebugData()
    {
        
        LoadData();
    }

    public static void LoadData()
    {
        Data = GameComponent.LoadExcelDataByPath(DebugExcel_Path);
        
    }
    //通过ID获取Debug信息文本
    public static string GetDebugMessageByID(int debugID)
    {
        return Data[GameParameter.LanguageID].Find(x => x[0] == debugID.ToString())[3];
    }
    //输出不含参数Debug信息
    public static DebugInfo GetDebugInfoByID_NoValue(int debugID)
    {
        string[] debugDataLine= Data[GameParameter.LanguageID].Find(x => int.Parse(x[0]) == debugID);
        DebugInfo info = new DebugInfo(debugDataLine[DebugExcel_Message_Place],
            (DebugInfo.DebugMessageLevel)System.Enum.Parse(typeof(DebugInfo.DebugMessageLevel),debugDataLine[DataExcel_Level_Place]), 
            (DebugInfo.DebugMessageType)System.Enum.Parse(typeof(DebugInfo.DebugMessageType), debugDataLine[DataExcel_Type_Place]));
        return info;
    }
    //输出含有参数的Debug信息
    public static DebugInfo GetDebugInfoByID_HaveValue(int debugID,List<object> valueList)
    {
        string[] debugDataLine = Data[GameParameter.LanguageID].Find(x => int.Parse(x[0]) == debugID);
        //多一步含有分裂、插入值的函数
        debugDataLine[DebugExcel_Message_Place] = GameComponent.SplitMessageByValue(debugDataLine[DebugExcel_Message_Place], valueList);
        DebugInfo info = new DebugInfo(debugDataLine[DebugExcel_Message_Place],
            (DebugInfo.DebugMessageLevel)System.Enum.Parse(typeof(DebugInfo.DebugMessageLevel), debugDataLine[DataExcel_Level_Place]),
            (DebugInfo.DebugMessageType)System.Enum.Parse(typeof(DebugInfo.DebugMessageType), debugDataLine[DataExcel_Type_Place]));
        return info;
    }
}
