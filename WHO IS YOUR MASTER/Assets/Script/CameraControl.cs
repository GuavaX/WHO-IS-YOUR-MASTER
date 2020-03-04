using UnityEngine;
namespace Pan
{
    public class CameraControl : MonoBehaviour
    {
        [Header("速度"), Range(0, 10000)]
        public float speed = 1.5f;
        [Header("上方限制")]
        public float top;
        [Header("下方限制")]
        public float bottom;

        [Header("轉向上限制")]
        public float xmin;
        [Header("轉向下限制")]
        public float xMax;
        


        private Transform player;
        private Transform cameraTarget;
        private Transform cameraTargetLookAt;

        private Vector3 rot;
        private float mouseX;  //控制左右轉向
        private float mouseY;  //控制上下轉向

        private string character = "tiger"; //角色預設為老虎

        private void Start()
        {
            character = SelectRole.GetRole(); //將角色設定為Role裡選擇的角色

            Cursor.lockState = CursorLockMode.Locked;        // 選擇完角色後鎖定滑鼠

            if (character == "tiger")
            {
                player = GameObject.Find("Tiger").transform;
                cameraTarget = GameObject.Find("CameraTarget_tiger").transform;
                cameraTargetLookAt = GameObject.Find("CameraTargetLookAt_tiger").transform;                
            }

            if (character == "father")
            {
                player = GameObject.Find("爸").transform;
                cameraTarget = GameObject.Find("CameraTarget_man").transform;
                cameraTargetLookAt = GameObject.Find("CameraTargetLookAt_man").transform;
            }

            if (character == "monster")
            {
                player = GameObject.Find("warrok_w_kurniawan").transform;
                cameraTarget = GameObject.Find("CameraTarget_monster").transform;
                //cameraTargetLookAt = GameObject.Find("CameraTargetLookAt_man").transform;
            }

            transform.LookAt(cameraTargetLookAt.position);
        }


        //在update之後才執行:攝影機追蹤、物件追蹤
        private void LateUpdate()
        {
            Turn();
            Track();
        }
        ///<summary>
        ///攝影機追蹤效果
        ///<summary>
        private void Track()
        {
            Vector3 posP  = player.position;  //玩家
            Vector3 posCT = cameraTarget.position;  //攝影機目標
            Vector3 posC  = transform.position; //攝影機
            
            //posP.x = 0f;  //固定x軸
            //posP.y -= 1.3f; //固定y軸
            //posP.z -= 2.6f; //固定在玩家後num

            //posP.z = Mathf.Clamp(posP.z, top, bottom); //玩家.z夾住 上方限制~下方限制

            //transform.position = Vector3.Lerp(posC, posP, 0.4f * Time.deltaTime * speed);
            transform.position = Vector3.Lerp(posC, posCT, 0.4f * Time.deltaTime * speed);
            //transform.LookAt(cameraTargetLookAt.position);
        }

        private void Turn()
        {     
            float cameraTurnSpeed = FindObjectOfType<Tiger>().GetTurnSpeed();           

            if (character == "tiger")
            {
                cameraTurnSpeed = FindObjectOfType<Tiger>().GetTurnSpeed();
            }
            else if (character == "father")
            {
                cameraTurnSpeed = FindObjectOfType<Father>().GetTurnSpeed();
            }


                mouseX = cameraTurnSpeed * Input.GetAxis("Mouse X");
            mouseY = cameraTurnSpeed * Input.GetAxis("Mouse Y");
            rot.x -= mouseY;  //控制攝影機轉動上下
            rot.y += mouseX;  //控制攝影機轉動左右

            rot.x = Mathf.Clamp(rot.x, xmin, xMax);
            //rot.y = Mathf.Clamp(rot.y, ymin, yMax);
            rot.z = 0;

            transform.eulerAngles = rot;          
        }
    }
}

