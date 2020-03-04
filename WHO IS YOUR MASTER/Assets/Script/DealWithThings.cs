using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithThings : MonoBehaviour
{
    [Header("拿取物品後的位置")]
    public Transform handTra;

    [Header("是否正在拿取物品")]
    public bool getting;            

    private GameObject objHit;      //被拿取的物品
    private Animator ani;           //動畫控制器

    private float hitPower = 200;  //攻擊力道


    void Start()
    {
        ani = gameObject.GetComponent<Animator>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (SelectRole.GetRole() == "father")
        {
            GetThings();
        }

        //if (SelectRole.GetRole() == "tiger")
        {
            HitThings();
        }
    }


    /// <summary>
    /// AI拿取物品
    /// </summary>
    private void AIGetThings()
    {
        if (Input.GetMouseButtonDown(1))    //如果按下滑鼠右鍵
        {
            if (FindObjectOfType<CameraRay>().GetObjHit() != null )
            {
                Physics.IgnoreLayerCollision(10, 12);

                objHit = GameObject.Find("Main Camera").GetComponent<CameraRay>().GetObjHit(); //取得將要被移動的物品
                objHit.transform.position = handTra.position;
                objHit.GetComponent<Rigidbody>().freezeRotation = true;
                objHit.GetComponent<Rigidbody>().useGravity = false;
                getting = true;
            }
        }
        else if (Input.GetMouseButtonUp(1)|| !Input.GetMouseButton(1))       //如果放開滑鼠右鍵
        {
            if (objHit != null)
            {
                Physics.IgnoreLayerCollision(10, 12, false);
                objHit.GetComponent<Rigidbody>().freezeRotation = false;
                objHit.GetComponent<Rigidbody>().useGravity = true;
                getting = false;
                objHit = null;                
            }
        }


        if (objHit != null && getting == true)
        {
            //重置位置
            objHit.transform.position = Vector3.Lerp(objHit.transform.position, handTra.position, 0.8f * Time.deltaTime * 10);
        }
    }    
    
    /// <summary>
    /// 拿取物品
    /// </summary>
    private void GetThings()
    {
        if (Input.GetMouseButtonDown(1))    //如果按下滑鼠右鍵
        {
            if (FindObjectOfType<CameraRay>().GetObjHit() != null )
            {
                Physics.IgnoreLayerCollision(10, 12);

                objHit = GameObject.Find("Main Camera").GetComponent<CameraRay>().GetObjHit(); //取得將要被移動的物品
                objHit.transform.position = handTra.position;
                objHit.GetComponent<Rigidbody>().freezeRotation = true;
                objHit.GetComponent<Rigidbody>().useGravity = false;
                getting = true;
            }
        }
        else if (Input.GetMouseButtonUp(1)|| !Input.GetMouseButton(1))       //如果放開滑鼠右鍵
        {
            if (objHit != null)
            {
                Physics.IgnoreLayerCollision(10, 12, false);
                objHit.GetComponent<Rigidbody>().freezeRotation = false;
                objHit.GetComponent<Rigidbody>().useGravity = true;
                getting = false;
                objHit = null;                
            }
        }


        if (objHit != null && getting == true)
        {
            //重置位置
            objHit.transform.position = Vector3.Lerp(objHit.transform.position, handTra.position, 0.8f * Time.deltaTime * 10);
        }
    }

    /// <summary>
    /// 攻擊物品
    /// </summary>
    private void HitThings()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FindObjectOfType<CameraRay>().GetObjHit() != null)
            {
                //ani.SetTrigger("hit_Trigger"); //攻擊動畫

                objHit = GameObject.Find("Main Camera").GetComponent<CameraRay>().GetObjHit(); //取得將要被移動的物品
                objHit.GetComponent<Rigidbody>().AddForce(transform.forward * hitPower);       //將家具往前方推                              
            }            
        }
    }

    

}
