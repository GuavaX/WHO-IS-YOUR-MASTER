using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("移動資料")]
    public MoveData data;


    private float walkSpeed;    //走路速度
    private float runSpeed;     //跑步速度 
    
    private float turnSpeed;    //轉向速度
    private float jumpPower;    //跳躍強度

    private float rayLength;    //射線長度

    protected Rigidbody rig;
    protected Animator ani;


    protected float speed;   //移動速度
    protected float X, Y, Z; //控制前後左右前進的方向
    protected float mouseX;  //控制左右轉向

    protected bool pressLeftShift;

    protected bool isGround;



    protected void Start()
    {       
        walkSpeed = data.walkSpeed;
        runSpeed = data.runSpeed;

        turnSpeed = data.turnSpeed;
        jumpPower = data.jumpPower;

        rayLength = data.rayLength;
        FindObjectOfType<CameraRay>().SetRayLength(rayLength);

        isGround = true;
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();   //動畫控制器 = 取得元件<動畫控制器>()   
    }

    // Update is called once per frame
    protected void Update()
    {
        Walk();
        Turn();
        Jump();        
    }

    /// <summary>
    /// 控制跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("按下了空白建");
            if (isGround)
            {
                //print("我該跳了");                
                rig.AddForce(Vector3.up * jumpPower);
                isGround = false;
            }
        }
    }


    /// <summary>
    /// 重置跳躍
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "地板"|| collision.gameObject.tag == "家具")
        {
            if (isGround == false)
            {
                isGround = true;
            }
            
        }
    }
    

    /// <summary>
    /// 控制走路、跑步
    /// </summary>
    private void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))        //如果按下左邊的shift
        { speed = runSpeed; }                       //移動速度 = 跑步速度
        else                                        //其他情況
        { speed = walkSpeed; }                      //移動速度 =走路速度

        X = Input.GetAxisRaw("Horizontal") * speed; //左右移動
        Y = 0;                                      //上下移動
        Z = Input.GetAxisRaw("Vertical") * speed;   //前後移動        

        Vector3 moveVector3 = new Vector3(X, Y, Z);

        transform.Translate(moveVector3);
    }

    /// <summary>
    /// 控制轉向
    /// </summary>
    private void Turn()
    {
        mouseX = turnSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(transform.up, mouseX);
    }

    public float GetTurnSpeed()
    {
        return turnSpeed;
    }




}
