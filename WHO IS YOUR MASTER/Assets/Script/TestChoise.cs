using UnityEngine;

public class TestChoise : MonoBehaviour
{
    private GameObject testChioseGroup;

    private void Start()
    {
        testChioseGroup = GameObject.Find("測試選項群組");

        if (SelectRole.selectOver)
        {
            if (SelectRole.GetRole()=="tiger")
            {
                TestTiger();
            }

            if (SelectRole.GetRole() == "father")
            {
                TestFather();
            }

        }
    }

    /// <summary>
    /// 測試老虎按鈕
    /// </summary>
    public void TestTiger()
    {
        SelectRole.SetRole("tiger");        
        FindObjectOfType<Tiger>().enabled = true;
        FindObjectOfType<Tiger>().GetComponentInParent<DealWithThings>().enabled = true;
        SelectRole.selectOver = true;
        SetScreen();
    }

    /// <summary>
    /// 測試老爸按鈕
    /// </summary>
    public void TestFather()
    {
        SelectRole.SetRole("father");
        FindObjectOfType<Father>().enabled = true;
        FindObjectOfType<Father>().GetComponentInParent<DealWithThings>().enabled = true;
        SelectRole.selectOver = true;
        SetScreen();
    }

    /// <summary>
    /// 測試怪物按鈕
    /// </summary>
    public void TestMonster()
    {
        SelectRole.SetRole("monster");
        SetScreen();
    }


    private void SetScreen()
    {
        testChioseGroup.SetActive(false);
        FindObjectOfType<Pan.CameraControl>().enabled = true; //喚醒腳本
    }

    


}
