using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscGroup : MonoBehaviour
{
    //private GameObject background;
    //private GameObject btnSurrebder;
    //private GameObject btnBackToGame;   
    private GameObject[] objs;
    private bool groupOpened;
    private bool surrendered;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().localPosition = Vector3.zero; //讓Esc版面回到畫面中央

        //background = transform.GetChild(0).gameObject;
        //btnSurrebder = transform.GetChild(1).gameObject;
        //btnBackToGame = transform.GetChild(2).gameObject;

        objs = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objs[i] = transform.GetChild(i).gameObject;
            objs[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(surrendered == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (groupOpened == false)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        objs[i].SetActive(true);
                    }
                    Cursor.lockState = CursorLockMode.None; //顯示滑鼠
                    groupOpened = true;
                }
                else
                {
                    groupOpened = false;
                    BackToGame();
                }
            }
        }        
    }


    /// <summary>
    /// 投降
    /// </summary>
    public void Surrender()
    {
        Time.timeScale = 1;
        if (SelectRole.GetRole() == "tiger")
        {
            FindObjectOfType<GameManager>().WHOISTHEMASTER("father");
        }

        if (SelectRole.GetRole() == "father")
        {
            FindObjectOfType<GameManager>().WHOISTHEMASTER("tiger");
        }

        surrendered = true;
        InvisibleEscGroup();
        Cursor.lockState = CursorLockMode.Locked;
        groupOpened = false;

    }

    /// <summary>
    /// 返回遊戲
    /// </summary>
    public void BackToGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

        InvisibleEscGroup();
        groupOpened = false;
    }

    /// <summary>
    /// 隱藏Esc群組
    /// </summary>
    private void InvisibleEscGroup()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            objs[i].SetActive(false);
        }
    }
}
