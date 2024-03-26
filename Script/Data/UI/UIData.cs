using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameCore.Tool;
public static class UIData
{
    //UI����·����
    public static List<List<string[]>> UIText;

    public static void Initialize()
    {
        //������Ч���ӹ��ò����е��ò�����·��
        UIText = GameComponent.LoadExcelDataByPath(GameParameter.UIExcelPath);

    }
    public static string GetUIText(int textID)
    {

        //Debug.Log(textID + "|" + GameParameter.LanguageID + "|" + GameParameter.UIExcelTextPlace);
        return UIText[GameParameter.LanguageID][textID][GameParameter.UIExcelTextPlace];
        //return null;
    }

}
