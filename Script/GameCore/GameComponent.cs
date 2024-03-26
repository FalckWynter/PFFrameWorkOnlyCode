using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using ExcelDataReader;
using TMPro;
using UnityEngine.UI;
using System;
namespace GameCore.Tool
{
    public static class GameComponent
    {
        //��Ϸ����
        //public static GameCore GameCore;
        //��Ƶ������
        //public static AudioManager AudioManager;

        /// <summary>
        /// ����: ��ȡExcel�����ݵ�List��
        /// ����: ����·�� ����Ӧ·���ı����� ��������
        /// </summary>
        /// <param name="Path">Ҫ��ȡ���ļ�·��</param>
        /// <param name="Data">Ҫ��ȡ��Excel��</param> 
        /// <returns>
        /// ��������ɹ���Excel,��ʽΪList<List<String[]>>
        /// </returns>
        /*��ĸ�ʽ�����:List<List<string[]>> ExampleList - ����ΪExampleList[][][]
         *ȡIDͷλ��(��Ƶ���):��ƵID/�������(�Զ�ȡ��),clipID / GameParameter.AUDIO_Range
         *ȡID��λ��(��Ƶ���):��ƵID-��Ƶͷλ��*�������,clipID - ((clipID / GameParameter.AUDIO_Range) * GameParameter.AUDIO_Range)
         *��ȡ˳��:AudioPath[Ҫ���õı��][Ҫ���õ��к�][Ҫ���õ��к�(Ĭ����1����)]
         *ȡĸ·��:AudioPath[0][IDͷλ��][~]
         *ȡ��·��:AudioPath[IDͷλ��][ID��λ��][~]
         *�����:2024/2/8 1:25
         */
        //�����ļ�·������Excel�����ݺ����:����Excel�汾
        public static List<List<string[]>> LoadExcelDataByPath(string ExcelPath)
        {
            //����ReadExcel,ͨ��path��ȡDataSet��
            return loadExcelDataByTable(ReadExcel(ExcelPath));
        }
        //����Excel�����ݣ�����List<List<string[]>>�б�
        public static List<List<string[]>> loadExcelDataByTable(DataSet excelData)
        {
            //�½���ʱ�б�
            List<List<string[]>> tempList;
            //��ȡExcel������
            int tableCount = excelData.Tables.Count;
            //Debug.Log("���������:" + excelData.DataSetName + "������:" + tableCount);
            //�����б��� ��ֹindex������Χ
            tempList = new List<List<string[]>>(excelData.Tables.Count);

            //���������Ƿ�Ϸ�
            if (tableCount <= 0)
            {
                //�������:����������
                Debug.LogWarning("����������");
                return null;
            }

            //Ϊ���ֵ��Excel��ı���Listһһ��Ӧ
            for (int i = 0; i < tableCount; i++)
            {
                //���ö�Excel��List����������i�ű������ӵ�List��
                tempList.Add(LoadExcelToList(excelData.Tables[i]));
            }
            return tempList;
        }
        //����DataTable����������List<string[]>
        public static List<string[]> LoadExcelToList(DataTable table)
        {
            List<string[]> temp = new List<string[]>();
            //��ȡ���������
            int rows = table.Rows.Count;
            int cols = table.Columns.Count;
            //Debug.Log("����:" +table.TableName + "��"+  rows + "��" + cols + "��:");
            for (int i = 0; i < rows; i++)
            {
                temp.Add(new string[cols]);
                for (int j = 0; j < cols; j++)
                {
                    temp[i][j] = table.Rows[i][j].ToString();
                    //Debug.Log("�������-" + i + "��" + j + "��:" + temp[i][j]);
                }
            }
            return temp;
        }
        //����·������������Excel��
        public static DataSet ReadExcel(string Path)
        {
            //PathΪ���·��
            //��IO��
            Stream stream = File.Open(Path, FileMode.Open, FileAccess.Read);
            //����
            IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
            //���
            DataSet result = excelReader.AsDataSet();
            //���ر�
            return result;
        }

        public static void ExchangeLanguage(int languageID)
        {
            //����Ҫ���������ID
            GameParameter.LanguageID = languageID;
            //������ʱ�б��洢������Text�����Object
            TextMeshProUGUI[] textList = GameObject.FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in textList)
            {
                //������Ϣ,��text���������ı�
                text.gameObject.SendMessage("ReloadText");
            }
        }
        //��string����һ�������з�,����ֵ��������
        public static string SplitMessageByValue(string initMessage, List<object> valueList)
        {
            string returnMessage = null;
            try
            {
                List<string> splitedMessage = new List<string>(initMessage.Split(new string("{value}")));

                int counter = 0;
                foreach (string split in splitedMessage)
                {
                    returnMessage += split;
                    if (counter < valueList.Count)
                    {
                        returnMessage += valueList[counter];
                        counter++;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("�����Ϣ����!������ֵ��������Ϣ��Ҫֵ������ƥ��!��������:" + e);
            }
            return returnMessage;
        }
        public static List<string> SplitMessageBySpace(string initMessage)
        {
            List<string> returnMessage = new List<string>(initMessage.Split(new string(" ")));
            return returnMessage;
        }
        public static string ClearMessageValue(string initMessage)
        {
            initMessage.Replace("{value}", "");
            return initMessage;
        }
        public static int Get5thDigitByNumber(int number)
        {
            number = number / 10000;
            number = number % 10;
            return number;
        }
        public static int Get4thDightByNumber(int number)
        {
            number = number / 1000;
            number = number % 10;
            return number;
        }
    }
}
