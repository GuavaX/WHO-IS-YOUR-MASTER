using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private int count = 3;
    private GameObject count_obj;
    private Text count_Text;

    private GameManager gm;

    private void Start()
    {
        count_obj = GameObject.Find("倒數數字");
        count_Text = GameObject.Find("倒數數字").GetComponent<Text>();
        gm = GameObject.Find("遊戲管理器").GetComponent<GameManager>(); //取得遊戲管理器中GM的資料

        count_obj.SetActive(false); //隱藏倒數計時物件   
    }

    private void Update()
    {
        if (gm.alreadyGameover == true)
        {
            if ((gm.getConfusionRate() > 0) && (gm.getConfusionRate() < 100))
            {
                //print("混亂度沒有超過極限");

                CancelInvoke("CountDownTimer"); //停止倒數計時器
                count = 3;                      //重設倒數計時的時間  
                count_Text.text = count + "";
                gm.alreadyGameover = false;     //

                count_obj.SetActive(false); //隱藏倒數計時物件           
            }
        }        
    }

    /// <summary>
    /// 重複啟用倒數計時器(CountDownTimer)
    /// </summary>
    public void IRCountDownTimer()
    {
        InvokeRepeating("CountDownTimer", 1, 1);
    }

    /// <summary>
    /// 倒數計時器
    /// </summary>
    public void CountDownTimer()
    {
        count_obj.SetActive(true); //顯示倒數計時物件
        count_Text.text = count + "";
        count -= 1;

        if (count == 0)
        {
            if (gm.getConfusionRate() == 0)   { gm.WHOISTHEMASTER("tiger"); }
            if (gm.getConfusionRate() == 100) { gm.WHOISTHEMASTER("father"); }            
            
            CancelInvoke("CountDownTimer");
        }

    }
}
