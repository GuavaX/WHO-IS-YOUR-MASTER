using System.Collections;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [Header("攝影機拿取到的物件")]
    public GameObject objHit;    

    [Header("射線")]
    public GameObject gizmosLine;
    
    private float hitLength = 3;        //射線長度
    private float defaultLength = 3;    //預設射線長度

    private void Start()
    {
        gizmosLine = GameObject.Find("GizmosLine");
    }

    private void Update()
    {
        if (FindObjectOfType<DealWithThings>().getting == false) //若手上沒有拿東西
        {
            GetThingsGameObject();       
        }
    }

    private void GetThingsGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);            //從螢幕中央射出射線

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hitLength))
        {
            if (hit.transform.tag == "家具")
            {
                objHit = hit.transform.gameObject;

                //加上輪廓線
                if (objHit.GetComponent<Outline>() == false)
                {
                    Destroy(FindObjectOfType<Outline>()); //先刪除其他物體的輪廓線

                    //再幫新的物體加上輪廓線
                    objHit.AddComponent<Outline>();
                    objHit.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                    objHit.GetComponent<Outline>().OutlineColor = Color.red;
                    objHit.GetComponent<Outline>().OutlineWidth = 8;
                }
            }
            else
            {
                Destroy(FindObjectOfType<Outline>()); //先刪除其他物體的輪廓線
                objHit = null;
            }
        }
        else
        {
            Destroy(FindObjectOfType<Outline>()); //先刪除其他物體的輪廓線            
            objHit = null;
        }        
    }



    /// <summary>
    /// 得到被射線擊中的物品
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjHit()
    {
        return objHit;
    }

    /// <summary>
    /// 設定射線長度
    /// </summary>
    public void SetRayLength(float length)
    {
        if (length >= 0 && length <= 10)
        {
            hitLength = length;
        }
        else
        {
            hitLength = defaultLength;
        }
    }

    /// <summary>
    /// 依照射線長度畫出模擬的射線
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gizmosLine.transform.position, gizmosLine.transform.forward * hitLength);
    }

}
