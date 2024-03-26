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
        //游戏核心
        //public static GameCore GameCore;
        //音频管理器
        //public static AudioManager AudioManager;

        /// <summary>
        /// 功能: 读取Excel表内容到List中
        /// 流程: 输入路径 读对应路径的表内容 传回内容
        /// </summary>
        /// <param name="Path">要读取的文件路径</param>
        /// <param name="Data">要读取的Excel表</param> 
        /// <returns>
        /// 返还导入成功的Excel,格式为List<List<String[]>>
        /// </returns>
        /*表的格式与调用:List<List<string[]>> ExampleList - 表现为ExampleList[][][]
         *取ID头位数(音频类别):音频ID/分类距离(自动取整),clipID / GameParameter.AUDIO_Range
         *取ID子位数(音频编号):音频ID-音频头位数*分类距离,clipID - ((clipID / GameParameter.AUDIO_Range) * GameParameter.AUDIO_Range)
         *调取顺序:AudioPath[要调用的表号][要调用的行号][要调用的列号(默认填1即可)]
         *取母路径:AudioPath[0][ID头位数][~]
         *取子路径:AudioPath[ID头位数][ID子位数][~]
         *完成于:2024/2/8 1:25
         */
        //输入文件路径，读Excel表数据后调用:输入Excel版本
        public static List<List<string[]>> LoadExcelDataByPath(string ExcelPath)
        {
            //调用ReadExcel,通过path获取DataSet表
            return loadExcelDataByTable(ReadExcel(ExcelPath));
        }
        //输入Excel表数据，返还List<List<string[]>>列表
        public static List<List<string[]>> loadExcelDataByTable(DataSet excelData)
        {
            //新建临时列表
            List<List<string[]>> tempList;
            //获取Excel表数量
            int tableCount = excelData.Tables.Count;
            //Debug.Log("正在载入表:" + excelData.DataSetName + "表数量:" + tableCount);
            //设置列表长度 防止index超出范围
            tempList = new List<List<string[]>>(excelData.Tables.Count);

            //检测表数量是否合法
            if (tableCount <= 0)
            {
                //报告错误:表数量不对
                Debug.LogWarning("表数量不足");
                return null;
            }

            //为表格赋值，Excel里的表与List一一对应
            for (int i = 0; i < tableCount; i++)
            {
                //调用读Excel到List函数，读第i张表，结果添加到List中
                tempList.Add(LoadExcelToList(excelData.Tables[i]));
            }
            return tempList;
        }
        //输入DataTable表，返还单表List<string[]>
        public static List<string[]> LoadExcelToList(DataTable table)
        {
            List<string[]> temp = new List<string[]>();
            //获取表的行列数
            int rows = table.Rows.Count;
            int cols = table.Columns.Count;
            //Debug.Log("表名:" +table.TableName + "有"+  rows + "行" + cols + "列:");
            for (int i = 0; i < rows; i++)
            {
                temp.Add(new string[cols]);
                for (int j = 0; j < cols; j++)
                {
                    temp[i][j] = table.Rows[i][j].ToString();
                    //Debug.Log("表格内容-" + i + "行" + j + "列:" + temp[i][j]);
                }
            }
            return temp;
        }
        //输入路径，读并返还Excel表
        public static DataSet ReadExcel(string Path)
        {
            //Path为表的路径
            //打开IO流
            Stream stream = File.Open(Path, FileMode.Open, FileAccess.Read);
            //读表
            IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
            //存表
            DataSet result = excelReader.AsDataSet();
            //返回表
            return result;
        }

        public static void ExchangeLanguage(int languageID)
        {
            //设置要载入的语言ID
            GameParameter.LanguageID = languageID;
            //建立临时列表，存储所有有Text组件的Object
            TextMeshProUGUI[] textList = GameObject.FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in textList)
            {
                //发送消息,让text重新载入文本
                text.gameObject.SendMessage("ReloadText");
            }
        }
        //将string按照一定规则切分,并将值置入其中
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
                Debug.Log("拆解消息出错!可能是值数量与消息需要值数量不匹配!错误类型:" + e);
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
