using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DebugUIController : MonoBehaviour
{
    public TMP_InputField inputField = null;
    public TextMeshProUGUI consoleText = null;
    public string inputingText;
    public static string publicText
    {
        set
        {
            
        }
        get
        {
            return publicText;
        }
    }
    public void Awake()
    {
        try
        {
            if (inputField == null)
                inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
            if (consoleText == null)
                consoleText = transform.Find("MessagePanel").Find("MessageText").GetComponent<TextMeshProUGUI>();
        }
        catch
        {
            DebugCore.Log(53001);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //inputField.ActivateInputField();
    }
    private void OnEnable()
    {
        inputField.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        inputingText = inputField.text;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (inputingText == null)
                return;
            consoleText.text += ">>" + inputingText + "\n";

            //将信息输入控制判断逻辑
            string output = DebugUIConsole.Input(inputingText);
            if (output != null)
            {
                // 回调信息为cls时清空控制台面板内容
                if (output.Equals("cls"))
                    consoleText.text = "";
                else
                    consoleText.text += output + "\n";
            }
            inputField.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            inputField.text = DebugUIConsole.Last();
        // 按下下跳转到下一条指令
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            inputField.text = DebugUIConsole.Next();
        inputField.ActivateInputField();
    }
    public void AddMessage(string message)
    {

    }
    private void OnDisable()
    {
        inputField.DeactivateInputField();
    }
}
