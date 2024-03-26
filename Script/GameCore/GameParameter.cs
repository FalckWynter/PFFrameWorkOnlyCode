using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCore.Tool
{
    public static class GameParameter
    {
        //��ǰ��Ϸ����
        public static int LanguageID = 1;

        //��ϷUI/MessageManager·��
        public static string UIMessageManagerPath = "MainCanvas/MessageManager";
        //��ϷUI/SelectManager·��
        public static string UISelectManagerPath = "MainCanvas/SelectManager";

        //������Ч��·��
        public static string AudioExcelPath = Application.dataPath + "/Resources/DataExcel/Audio/AudioPath.xls";
        //��Ƶ��Ч��stringλ��
        public static int AudioExcelPathPlace = 1;
        //������Ч����·��
        public static string AudioBasicPath = "Sounds/";
        //������Ч������
        public static int AUDIO_Range = 10000;
        //��ƵԤ����·��
        public static string AudioPrefabPath = "Prefabs/Audio/AudioSourcePrefab";
        //2D��Ƶ����Object����·��
        public static string Audio2DManagerPath = "GameCore/2DAudioManager";
        //��Ƶ�����AudioMixer·��
        public static string AudioMixerPath = "AudioMixer/AudioMixer";
        //��Ƶ�����AudioMixerĸ·��
        public static string AudioMixerParentName = "Master";

        //Card���ݱ�·��
        public static string CardExcelPath = Application.dataPath + "/Resources/DataExcel/Card/CardPath.xls";
        //CardԤ����·��
        public static string CardPrefabPath = "Prefabs/Card/CardPrefab";
        //Card������Ϣ��λ��
        public static int CardExcelBasicDataPlace = 0;
        //Card���Ʊ�stringλ��
        public static int CardExcelNamePlace = 1;
        //Card������stringλ��
        public static int CardExcelDescriptionPlace = 2;
        //CardStringID��stringλ��
        public static int CardExcelStringIDPlace = 1;
        //CardͼƬ��stringλ��
        public static int CardExcelImagePlace = 2;

        //UI�ı���·��
        public static string UIExcelPath = Application.dataPath + "/Resources/DataExcel/UI/UIPath.xls";
        //UI�ı���stringλ��
        public static int UIExcelTextPlace = 1;



        //Message�ı���·��
        public static string MessageExcelPath = Application.dataPath + "/Resources/DataExcel/Message/MessagePath.xls";
        //MessageԤ����·��
        public static string MessagePrefabPath = "Prefabs/Message/MessagePrefab";
        //Message�ı������λ��
        public static int MessageExcelTitlePlace = 1;
        //Message�ı�������λ��
        public static int MessageExcelTextPlace = 2;
        //Message��ť�ı������λ��
        public static int MessageButtonExcelTitlePlace = 3;
        //Message��ť�ı�������λ��
        public static int MessageButtonExcelTextPlace = 4;

        //Select�ı���·��
        public static string SelectExcelPath = Application.dataPath + "/Resources/DataExcel/Select/SelectPath.xls";
        //SelectButton�ı���·��
        public static string SelectButtonExcelPath = Application.dataPath + "/Resources/DataExcel/Select/SelectButton.xls";
        //SelectԤ����·��
        public static string SelectPrefabPath = "Prefabs/Select/SelectPanelPrefab";
        //SelectButtonԤ����·��
        public static string SelectButtonPrefabPath = "Prefabs/Select/SelectButtonPrefab";
        //Select�ı������λ��
        public static int SelectExcelTitlePlace = 1;
        //Select�ı�������λ��
        public static int SelectExcelTextPlace = 2;
        //Select��ť�ı������λ��
        public static int SelectButtonExcelTitlePlace = 1;
        //Select��ť�ı�������λ��
        public static int SelectButtonExcelTextPlace = 2;
        //Select��ť����λ��
        public static int SelectButtonExcelCountPlace = 4;
        //Select��ť����
        public static int SelectButtonExcelOffset = 5;
    }
}