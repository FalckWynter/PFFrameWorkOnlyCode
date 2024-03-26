using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractAction 
{
    public string actionName;

    public string actionType;

    public bool isCompleted = false;

    public bool isAlwaysAction = false;

    public float actionMaxUpdateTime = 15, actionCurrentUpdateTime;
    // Start is called before the first frame update
    public virtual void Start()
    {
        actionCurrentUpdateTime = actionMaxUpdateTime;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //������ǳ�פ�ж�
        if (!isAlwaysAction)
        {
            //�����ʣ�����ʱ��
            actionCurrentUpdateTime -= Time.deltaTime;
            //���ʣ��ʱ��Ϊ0�����ж���û����ɣ���ǿ�����(������Ϸ����)
            if (actionCurrentUpdateTime <= 0 && isCompleted != true)
            {
                isCompleted = true;
                //DebugCore.AddDebugInfo(new DebugInfo());
            }
        }
      
    }
}
