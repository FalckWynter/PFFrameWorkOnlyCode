using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Tool;
public static class DebugData
{
    //ʵ�ֵĹ���
    //�洢
    //
    //д��
    //
    //ȡ��
    //
    //���ݱ�
    public static List<List<string[]>> Data = new List<List<string[]>>();
    //Debug���ݱ�·��
    public static string DebugExcel_Path = Application.dataPath + "/Resources/DataExcel/Debug/DebugDataExcel.xls";
    //Debug��ȼ�λ��
    public static int DataExcel_Level_Place = 1;
    //Debug������λ��
    public static int DataExcel_Type_Place = 2;
    //Debug�ı�λ��
    public static int DebugExcel_Message_Place = 3;


    static DebugData()
    {
        
        LoadData();
    }

    public static void LoadData()
    {
        Data = GameComponent.LoadExcelDataByPath(DebugExcel_Path);
        
    }
    //ͨ��ID��ȡDebug��Ϣ�ı�
    public static string GetDebugMessageByID(int debugID)
    {
        return Data[GameParameter.LanguageID].Find(x => x[0] == debugID.ToString())[3];
    }
    //�����������Debug��Ϣ
    public static DebugInfo GetDebugInfoByID_NoValue(int debugID)
    {
        string[] debugDataLine= Data[GameParameter.LanguageID].Find(x => int.Parse(x[0]) == debugID);
        DebugInfo info = new DebugInfo(debugDataLine[DebugExcel_Message_Place],
            (DebugInfo.DebugMessageLevel)System.Enum.Parse(typeof(DebugInfo.DebugMessageLevel),debugDataLine[DataExcel_Level_Place]), 
            (DebugInfo.DebugMessageType)System.Enum.Parse(typeof(DebugInfo.DebugMessageType), debugDataLine[DataExcel_Type_Place]));
        return info;
    }
    //������в�����Debug��Ϣ
    public static DebugInfo GetDebugInfoByID_HaveValue(int debugID,List<object> valueList)
    {
        string[] debugDataLine = Data[GameParameter.LanguageID].Find(x => int.Parse(x[0]) == debugID);
        //��һ�����з��ѡ�����ֵ�ĺ���
        debugDataLine[DebugExcel_Message_Place] = GameComponent.SplitMessageByValue(debugDataLine[DebugExcel_Message_Place], valueList);
        DebugInfo info = new DebugInfo(debugDataLine[DebugExcel_Message_Place],
            (DebugInfo.DebugMessageLevel)System.Enum.Parse(typeof(DebugInfo.DebugMessageLevel), debugDataLine[DataExcel_Level_Place]),
            (DebugInfo.DebugMessageType)System.Enum.Parse(typeof(DebugInfo.DebugMessageType), debugDataLine[DataExcel_Type_Place]));
        return info;
    }
}
