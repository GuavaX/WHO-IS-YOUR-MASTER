using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class FatherAI : MonoBehaviour
{

    private GameObject[] furnitures;
    private int[] furnitureLastConfusionRates;
    private int min;
    private int MAX;

    private NavMeshAgent nav;
    private Animator ani;
    private GameObject target;

    private bool haveTarget;



    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        ani = gameObject.GetComponent<Animator>();
        nav.enabled = false;


        furnitures = GameObject.FindGameObjectsWithTag("家具");
        furnitureLastConfusionRates = new int[furnitures.Length];
        InvokeRepeating("RefreshFurnitureLastConfusionRates", 0, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (SelectRole.selectOver == false) { return; }
        

        if (SelectRole.GetRole() == "tiger") { nav.enabled = true;}
        if (SelectRole.GetRole() == "father") { nav.enabled = false;}
         



        //if (haveTarget == false)
        {
            FindTarget();
        }
        //else
        {
            if(nav.isStopped == false)
            {                
                nav.destination = target.transform.position;
                print("設定目標位置");
                ani.SetInteger("idle_walk_run", 1);
            }

            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                ani.SetInteger("idle_walk_run", 0);
            }
                        
        }
    }

    /// <summary>
    /// 更新混亂度
    /// </summary>
    private void RefreshFurnitureLastConfusionRates()
    {
        for (int i = 0; i < furnitures.Length; i++)
        {
            //print(i.ToString());
            //print(furnitures[i].transform.name);
            furnitureLastConfusionRates[i] = furnitures[i].transform.parent.parent.GetComponent<ConfusionThingsNew>().GetLastConfusionRate();
            //print(furnitureLastConfusionRates[i].ToString());
        }
    }

    private void FindTarget()
    {
        min = furnitureLastConfusionRates.Min();
        MAX = furnitureLastConfusionRates.Max();
        int index = furnitureLastConfusionRates.ToList().IndexOf(MAX);

        print(furnitures[index].name);

        target = furnitures[index];

        if (target != null)
        {
            haveTarget = true;
        }
    }


}
