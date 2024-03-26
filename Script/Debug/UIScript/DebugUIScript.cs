using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUIScript : MonoBehaviour
{
    # region 功能方法
    /// <summary>
    /// 第一帧调用之前触发。
    /// </summary>
    private void Start()
    {
        // 初始化为隐藏
        GameInputManager.ConsoleKeyEvent.AddListener(ExchangeActive);
        gameObject.SetActive(false);
    }
    # endregion
    public void ExchangeActive()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

}
