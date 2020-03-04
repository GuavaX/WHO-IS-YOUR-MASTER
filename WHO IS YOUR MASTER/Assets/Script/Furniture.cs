using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    bool resetOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if(collision.transform.tag == "地板")
        {
            if (resetOnce)
            {
                transform.GetComponentInParent<ConfusionThingsNew>().ResetOriginTra();
                transform.GetComponentInParent<ConfusionThingsNew>().ResetBottomTra(contact.point);
                resetOnce = false;
            }
        }
        
    }
}
