using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCore.Tool
{
    public static class GameParameter
    {
        //当前游戏语言
        public static int LanguageID = 1;

        //游戏UI/MessageManager路径
        public static string UIMessageManagerPath = "MainCanvas/MessageManager";
        //游戏UI/SelectManager路径
        public static string UISelectManagerPath = "MainCanvas/SelectManager";

        //音乐音效表路径
        public static string AudioExcelPath = Application.dataPath + "/Resources/DataExcel/Audio/AudioPath.xls";
        //音频音效表string位置
        public static int AudioExcelPathPlace = 1;
        //音乐音效基础路径
        public static string AudioBasicPath = "Sounds/";
        //音乐音效表类间距
        public static int AUDIO_Range = 10000;
        //音频预制体路径
        public static string AudioPrefabPath = "Prefabs/Audio/AudioSourcePrefab";
        //2D音频管理Object名称路径
        public static string Audio2DManagerPath = "GameCore/2DAudioManager";
        //音频混合器AudioMixer路径
        public static string AudioMixerPath = "AudioMixer/AudioMixer";
        //音频混合器AudioMixer母路径
        public static string AudioMixerParentName = "Master";

        //Card数据表路径
        public static string CardExcelPath = Application.dataPath + "/Resources/DataExcel/Card/CardPath.xls";
        //Card预制体路径
        public static string CardPrefabPath = "Prefabs/Card/CardPrefab";
        //Card基础信息表位置
        public static int CardExcelBasicDataPlace = 0;
        //Card名称表string位置
        public static int CardExcelNamePlace = 1;
        //Card描述表string位置
        public static int CardExcelDescriptionPlace = 2;
        //CardStringID表string位置
        public static int CardExcelStringIDPlace = 1;
        //Card图片表string位置
        public static int CardExcelImagePlace = 2;

        //UI文本表路径
        public static string UIExcelPath = Application.dataPath + "/Resources/DataExcel/UI/UIPath.xls";
        //UI文本表string位置
        public static int UIExcelTextPlace = 1;



        //Message文本表路径
        public static string MessageExcelPath = Application.dataPath + "/Resources/DataExcel/Message/MessagePath.xls";
        //Message预制体路径
        public static string MessagePrefabPath = "Prefabs/Message/MessagePrefab";
        //Message文本表标题位置
        public static int MessageExcelTitlePlace = 1;
        //Message文本表描述位置
        public static int MessageExcelTextPlace = 2;
        //Message按钮文本表标题位置
        public static int MessageButtonExcelTitlePlace = 3;
        //Message按钮文本表描述位置
        public static int MessageButtonExcelTextPlace = 4;

        //Select文本表路径
        public static string SelectExcelPath = Application.dataPath + "/Resources/DataExcel/Select/SelectPath.xls";
        //SelectButton文本表路径
        public static string SelectButtonExcelPath = Application.dataPath + "/Resources/DataExcel/Select/SelectButton.xls";
        //Select预制体路径
        public static string SelectPrefabPath = "Prefabs/Select/SelectPanelPrefab";
        //SelectButton预制体路径
        public static string SelectButtonPrefabPath = "Prefabs/Select/SelectButtonPrefab";
        //Select文本表标题位置
        public static int SelectExcelTitlePlace = 1;
        //Select文本表描述位置
        public static int SelectExcelTextPlace = 2;
        //Select按钮文本表标题位置
        public static int SelectButtonExcelTitlePlace = 1;
        //Select按钮文本表描述位置
        public static int SelectButtonExcelTextPlace = 2;
        //Select按钮数量位置
        public static int SelectButtonExcelCountPlace = 4;
        //Select按钮修正
        public static int SelectButtonExcelOffset = 5;
    }
}