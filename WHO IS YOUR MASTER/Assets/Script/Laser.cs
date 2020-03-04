using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    LineRenderer line;

    void Start()
    {

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;

        //Screen.lockCursor = true; //鎖定滑鼠，可有可無

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire2"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin); //設定 Line Render 的起始點位置

            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point); //設定第二個 Line Render 第二個點位置，即可連成一條線
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 50, hit.point); //如果 ray 打到的物體是剛體，就讓物體作功
                }
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100)); //如果都沒打到物體，就發射 100 這麼長的射線
            }


            yield return null;
        }

        line.enabled = false;
    }
}