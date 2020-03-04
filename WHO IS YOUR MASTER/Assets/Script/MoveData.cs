using UnityEngine;

[CreateAssetMenu(fileName = "移動資料",menuName = "GuavaX/移動資料")]
public class MoveData : ScriptableObject
{
    [Header("走路速度"), Range(0, 1f)]
    public float walkSpeed;
    [Header("跑步速度"), Range(0, 2f)]
    public float runSpeed;

    [Header("轉向速度"), Range(0, 10.0f)]
    public float turnSpeed;

    [Header("跳躍強度"), Range(0, 10000)]
    public float jumpPower;

    [Header("射線長度"), Range(0, 20)]
    public float rayLength;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
