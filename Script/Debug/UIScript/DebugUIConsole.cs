using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制台静态类，用于程序内部调试。
/// </summary>
public static class DebugUIConsole
{
    # region 指令列表
    private static readonly string[] command =
    {
        "help",
        "cls",
        "test"
    };
    # endregion

    # region 静态成员变量
    private static int position = -1;   // 当前读取历史记录的位置
    private static List<string> consoleHistory = new List<string>();    // 控制台历史记录
    # endregion

    # region 静态公有方法
    /// <summary>
    /// 向控制台输入指令。
    /// </summary>
    /// <param name="input">指令字符串。</param>
    /// <returns>回调信息。</returns>
    public static string Input(string input)
    {
        // 分割字符串获取参数列表
        List<string> args = new List<string>(input.Split(' '));
        consoleHistory.Add(input);
        position = consoleHistory.Count;
        // 控制与回调
        string output = null;
        switch (args[0])
        {
            // 帮助
            case "help":
                output = Show();
                break;
            // 清空控制台
            case "cls":
                output = Clear();
                break;
            // 测试
            case "test":
                output = Test();
                break;
            case "DebugCode":
                output = DebugCode(int.Parse(args[1]));
                break;
            // 错误指令
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
    /// 获取控制台上一条历史记录。
    /// </summary>
    /// <returns>上一条指令字段。</returns>
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
    /// 获取控制台下一条历史记录。
    /// </summary>
    /// <returns>下一条指令字段。</returns>
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

    #region 静态私有方法
    /// <summary>
    /// 显示全部控制台命令。
    /// </summary>
    /// <returns>回调信息。</returns>
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
    /// 清空控制台记录。
    /// </summary>
    /// <returns>回调信息。</returns>
    private static string Clear()
    {
        position = -1;
        consoleHistory.Clear();
        return "cls";
    }
    #endregion

    #region 控制台方法
    /// <summary>
    /// 测试方法。
    /// </summary>
    /// <returns>回调信息。</returns>
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

