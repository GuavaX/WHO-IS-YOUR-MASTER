using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int confusionRate = 50;  //混亂度-本遊戲最重要的數值

    private int minConfusionRate = 0;
    private int MaxConfusionRate = 100;

    private Image confusionRate_Image;
    private Text confusionRate_Text;
    private Text incConfusionRate_Text;
    private Text decConfusionRate_Text;

    private Text gameoverHint_Text;

    private GameObject centerMark;

    public bool alreadyGameover;
    public bool gameover = false;
    
    public Color c0, c100,cCon;


    private void Start()
    {
        Time.timeScale = 1;
        confusionRate_Image = GameObject.Find("混亂比例").GetComponent<Image>();
        confusionRate_Text = GameObject.Find("混亂比例文字").GetComponent<Text>();
        incConfusionRate_Text = GameObject.Find("混亂比例增加").GetComponent<Text>();
        decConfusionRate_Text = GameObject.Find("混亂比例減少").GetComponent<Text>();
        incConfusionRate_Text.color -= new Color(0, 0, 0, 1); //數字初始透明化
        decConfusionRate_Text.color -= new Color(0, 0, 0, 1); //數字初始透明化

        gameoverHint_Text = GameObject.Find("遊戲結束提示字幕").GetComponent<Text>();
        centerMark = GameObject.Find("標記");
    }

    private void Update()
    {
        if (alreadyGameover == false)
        {
            if ((confusionRate == 0) || (confusionRate == 100))
            {
                alreadyGameover = true;
                FindObjectOfType<CountDown>().IRCountDownTimer();
            }
        }     
        
        if (gameover == true)
        {
            gameoverHint_Text.text = "按下任意鍵\n回到選擇畫面";            
            if (Input.anyKeyDown)
            {
                gameover = false;
                SceneManager.LoadScene("選擇遊戲模式及角色");
            }
        }

        //血條變色
        cCon = Color.Lerp(c0, c100, confusionRate * 0.01f);
        confusionRate_Image.color = cCon;
    }

    private void FixedUpdate()
    {
        if (confusionRate < minConfusionRate) confusionRate = minConfusionRate;
        if (confusionRate > MaxConfusionRate) confusionRate = MaxConfusionRate;

        confusionRate_Text.text = confusionRate + "%";
        confusionRate_Image.fillAmount = confusionRate * 0.01f;
    }

    /// <summary>
    /// 得到混亂度現值
    /// </summary>
    /// <returns></returns>
    public int getConfusionRate()
    {
        return confusionRate;
    }

    /// <summary>
    /// 增加混亂度(增加的數值)
    /// </summary>
    /// <param name="incNumber"></param>
    public void IncConfusion(int incNumber)
    {
        if ((minConfusionRate <= confusionRate) && (confusionRate <= MaxConfusionRate))
        {
            confusionRate += incNumber;                                    //增加總混亂度
            incConfusionRate_Text.text = "+" + incNumber;                  //設定增加的數字
            incConfusionRate_Text.color += new Color(0, 0, 0, 1);          //顯示增加的數字
            StartCoroutine(TransparentTextColor(incConfusionRate_Text));   //讓顯示出來的數字透明化
            
            if (MaxConfusionRate <= confusionRate) { confusionRate = MaxConfusionRate; }
        }
    }
    /// <summary>
    /// 減少混亂度(減少的數值)
    /// </summary>
    /// <param name="decNumber"></param>
    public void decConfusion(int decNumber)
    {
        if ((minConfusionRate <= confusionRate) && (confusionRate <= MaxConfusionRate))
        {
            confusionRate -= decNumber;                                    //減少總混亂度
            decConfusionRate_Text.text = "-" + decNumber;                  //設定減少的數字
            decConfusionRate_Text.color += new Color(0, 0, 0, 1);          //顯示減少的數字
            StartCoroutine(TransparentTextColor(decConfusionRate_Text));   //讓顯示出來的數字透明化

            if (minConfusionRate >= confusionRate) { confusionRate = minConfusionRate; }
        }
    }

    /// <summary>
    /// 數字顏色透明化
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator TransparentTextColor(Text text)
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);
            text.color -= new Color(0, 0, 0, 0.02f);
        }        
    }

    /// <summary>
    /// 以按鍵隨機增加混亂度(1~10)
    /// </summary>
    public void IncConfusionButton()
    {
        if ((0 <= confusionRate) && (confusionRate <= MaxConfusionRate))
        {
            confusionRate += Random.Range(0, 10);
            if (MaxConfusionRate <= confusionRate) { confusionRate = MaxConfusionRate; }
        }                
    }

    /// <summary>
    /// 以按鍵隨機減少混亂度(1~10)
    /// </summary>
    public void decConfusionButton()
    {
        if ((minConfusionRate <= confusionRate) && (confusionRate <= MaxConfusionRate))
        {
            confusionRate -= Random.Range(0, 10);
            if (minConfusionRate >= confusionRate) { confusionRate = minConfusionRate; }
        }         
    }

    /// <summary>
    /// 誰才是主人！！ (遊戲結果)
    /// </summary>
    /// <param name="MASTER"></param>
    public void WHOISTHEMASTER(string MASTER)
    {
        centerMark.SetActive(false);
        if (MASTER == "tiger") { gameoverHint_Text.text = "貓咪獲勝！"; }
        if (MASTER == "father") { gameoverHint_Text.text = "人類獲勝！"; }
        StartCoroutine(Gameover());
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    private IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3);
        gameover = true;
    }
}
