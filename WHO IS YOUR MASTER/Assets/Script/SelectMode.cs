using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectMode : MonoBehaviour
{
    private bool cat, human, one, two;

    private Button btnCat;
    private Button btnHuman;
    private Button btnOne;
    private Button btnTwo;

    private GameObject hint;
    private Text hintText;

    private int count = 3;

    private void Start()
    {
        btnCat   = GameObject.Find("貓咪").GetComponent<Button>();
        btnHuman = GameObject.Find("人類").GetComponent<Button>();
        btnOne   = GameObject.Find("單機模式按鈕").GetComponent<Button>();
        btnTwo   = GameObject.Find("雙人模式按鈕").GetComponent<Button>();

        hint = GameObject.Find("提示文字");
        hintText = hint.GetComponent<Text>();

        hint.SetActive(false); //一開始先將提示文字隱藏

        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// 選擇貓咪
    /// </summary>
    public void SelectCat()
    {
        cat   = true;
        SelectRole.SetRole("tiger");
        human = false;

        btnCat.interactable   = false;
        btnHuman.interactable = true;
    }

    /// <summary>
    /// 選擇人類
    /// </summary>
    public void SelectHuman()
    {
        cat   = false;
        SelectRole.SetRole("father");
        human = true;

        btnCat.interactable   = true;
        btnHuman.interactable = false;

    }

    /// <summary>
    /// 選擇單機模式
    /// </summary>
    public void SelectOnePlayer()
    {
        one = true;
        two = false;

        btnOne.interactable = false;
        //btnTwo.interactable = true;
    }

    /// <summary>
    /// 選擇雙人模式
    /// </summary>
    public void SelectTwoPlayer()
    {
        one = false;
        two = true;

        btnOne.interactable = true;
        btnTwo.interactable = false;
    }

    private void Update()
    {
        if (SelectRole.selectOver == true) { return; }

        if ((cat || human) && (one || two))
        {            
            StartCoroutine(LoadPKScene());
        }
    }

    private IEnumerator LoadPKScene()
    {
        hint.SetActive(true);
        SelectRole.selectOver = true;
        

        InvokeRepeating("CountDownTimer", 0, 1);

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("PK場景");        
    }

    /// <summary>
    /// 倒數計時器
    /// </summary>
    public void CountDownTimer()
    {
        hintText.text = "選擇完畢\n將於 " + count.ToString() + " 秒後\n開始遊戲";
        count -= 1;
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
