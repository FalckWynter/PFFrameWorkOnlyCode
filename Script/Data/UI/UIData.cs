using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameCore.Tool;
public static class UIData
{
    //UI名称路径表
    public static List<List<string[]>> UIText;

    public static void Initialize()
    {
        //载入音效表，从公用参数中调用并输入路径
        UIText = GameComponent.LoadExcelDataByPath(GameParameter.UIExcelPath);

    }
    public static string GetUIText(int textID)
    {

        //Debug.Log(textID + "|" + GameParameter.LanguageID + "|" + GameParameter.UIExcelTextPlace);
        return UIText[GameParameter.LanguageID][textID][GameParameter.UIExcelTextPlace];
        //return null;
    }

}
