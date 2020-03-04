using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : Move
{
    private new void Start()
    {
        base.Start();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TigerAnimatorControll();
    }


    /// <summary>
    /// 控制老虎動畫
    /// </summary>
    private void TigerAnimatorControll()
    {
        if (Input.GetKey(KeyCode.LeftShift) && ((X != 0) || (Z != 0)))
        {
            ani.SetInteger("idle_walk_run", 2); //跑步
        }
        else if ((X != 0) || (Z != 0))
        {
            ani.SetInteger("idle_walk_run", 1); //走路
        }
        else
        {
            ani.SetInteger("idle_walk_run", 0); //待機
        }        
    }
}
