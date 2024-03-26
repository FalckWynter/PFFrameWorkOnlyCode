using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����̨��̬�࣬���ڳ����ڲ����ԡ�
/// </summary>
public static class DebugUIConsole
{
    # region ָ���б�
    private static readonly string[] command =
    {
        "help",
        "cls",
        "test"
    };
    # endregion

    # region ��̬��Ա����
    private static int position = -1;   // ��ǰ��ȡ��ʷ��¼��λ��
    private static List<string> consoleHistory = new List<string>();    // ����̨��ʷ��¼
    # endregion

    # region ��̬���з���
    /// <summary>
    /// �����̨����ָ�
    /// </summary>
    /// <param name="input">ָ���ַ�����</param>
    /// <returns>�ص���Ϣ��</returns>
    public static string Input(string input)
    {
        // �ָ��ַ�����ȡ�����б�
        List<string> args = new List<string>(input.Split(' '));
        consoleHistory.Add(input);
        position = consoleHistory.Count;
        // ������ص�
        string output = null;
        switch (args[0])
        {
            // ����
            case "help":
                output = Show();
                break;
            // ��տ���̨
            case "cls":
                output = Clear();
                break;
            // ����
            case "test":
                output = Test();
                break;
            case "DebugCode":
                output = DebugCode(int.Parse(args[1]));
                break;
            // ����ָ��
            default:
                output = "No such command.";
                break;
        }
        return output;
    }

    public static string DebugCode(int code)
    {
        return DebugData.GetDebugMessageByID(code);
    }
    /// <summary>
    /// ��ȡ����̨��һ����ʷ��¼��
    /// </summary>
    /// <returns>��һ��ָ���ֶΡ�</returns>
    public static string Last()
    {
        if (position == -1)
            return null;
        position -= 1;
        if (position < 0)
            position = 0;
        return consoleHistory[position];
    }

    /// <summary>
    /// ��ȡ����̨��һ����ʷ��¼��
    /// </summary>
    /// <returns>��һ��ָ���ֶΡ�</returns>
    public static string Next()
    {
        if (position == -1)
            return null;
        position += 1;
        if (position >= consoleHistory.Count)
            position = consoleHistory.Count - 1;
        return consoleHistory[position];
    }
    #endregion

    #region ��̬˽�з���
    /// <summary>
    /// ��ʾȫ������̨���
    /// </summary>
    /// <returns>�ص���Ϣ��</returns>
    private static string Show()
    {
        string output = null;
        for (int i = 0; i < command.Length; i++)
        {
            output += command[i];
            if (i != command.Length - 1)
                output += "\n";
        }
        return output;
    }

    /// <summary>
    /// ��տ���̨��¼��
    /// </summary>
    /// <returns>�ص���Ϣ��</returns>
    private static string Clear()
    {
        position = -1;
        consoleHistory.Clear();
        return "cls";
    }
    #endregion

    #region ����̨����
    /// <summary>
    /// ���Է�����
    /// </summary>
    /// <returns>�ص���Ϣ��</returns>
    private static string Test()
    {
        GameObject gameObject = Resources.Load("Test") as GameObject;
        if (gameObject)
        {
            GameObject.Instantiate(gameObject);
            return "Object has been generated.";
        }
        return "There have no such object.";
    }
    #endregion
}

