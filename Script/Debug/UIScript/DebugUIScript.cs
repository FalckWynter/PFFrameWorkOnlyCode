using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUIScript : MonoBehaviour
{
    # region ���ܷ���
    /// <summary>
    /// ��һ֡����֮ǰ������
    /// </summary>
    private void Start()
    {
        // ��ʼ��Ϊ����
        GameInputManager.ConsoleKeyEvent.AddListener(ExchangeActive);
        gameObject.SetActive(false);
    }
    # endregion
    public void ExchangeActive()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

}
