using UnityEngine;

public class Father : Move
{
    void FixedUpdate()
    {
        FatherAnimatorControll();
    }

    /// <summary>
    /// 控制老爸動畫
    /// </summary>
    private void FatherAnimatorControll()
    {
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            ani.SetBool("Carrying", false); //放下物品
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ani.SetBool("Carrying", true); //拿取物品
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ani.SetBool("Carrying", false); //放下物品
        }        



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
