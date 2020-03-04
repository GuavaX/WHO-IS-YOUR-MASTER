using UnityEngine;

public class ConfusionThings : MonoBehaviour
{
    private Transform furnitureTra;
    private Transform bottomTra;        
    
    private int lastConfusionRate = 0; //前次混亂度

    //private int minConfusionRate = 0;
    private int MaxConfusionRate = 3;


    private GameManager gm;

    private void Start()
    {
        furnitureTra = transform.GetChild(0).transform;
        bottomTra = transform;
        InvokeRepeating("countDistance", 1, 1);

        gm = GameObject.Find("遊戲管理器").GetComponent<GameManager>();
    }

    private void Update()
    {
        //countDistance();
    }

    public void countDistance()
    {
        int count = 0;
        int nowConfusionRate = 0; //現在混亂度        

        float distance = Vector3.Distance(furnitureTra.position, bottomTra.position);
        if (distance < 0.1f) { distance = 0.0f; }
        
        //print(distance); //列印出與該物件原點的距離


        if (distance > MaxConfusionRate)
        {
            nowConfusionRate = MaxConfusionRate; //離原點過遠，混亂度為最大混亂度
        }
        else
        {
            nowConfusionRate = (int)Mathf.Floor(distance); //依照現在距離定義混亂度
        }

        //print(transform.GetChild(0).name+nowConfusionRate); //顯示現在該物體提供的混亂度



       if (nowConfusionRate > lastConfusionRate)             //如果混亂度增加
       {
            count = nowConfusionRate - lastConfusionRate;     //計算出增加的混亂度數值
            gm.IncConfusion(count);                          //增加總體混亂度

       }else if (nowConfusionRate < lastConfusionRate)       //如果混亂度減少
       {
            count = -(nowConfusionRate - lastConfusionRate); //計算出減少的混亂度數值
            gm.decConfusion(count);                          //減少總體混亂度
       }
       
       lastConfusionRate = nowConfusionRate; //更新混亂度現值                
    }
}
