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
        //如果不是常驻行动
        if (!isAlwaysAction)
        {
            //则减少剩余存在时间
            actionCurrentUpdateTime -= Time.deltaTime;
            //如果剩余时间为0，且行动还没有完成，则强制完成(避免游戏卡死)
            if (actionCurrentUpdateTime <= 0 && isCompleted != true)
            {
                isCompleted = true;
                //DebugCore.AddDebugInfo(new DebugInfo());
            }
        }
      
    }
}
