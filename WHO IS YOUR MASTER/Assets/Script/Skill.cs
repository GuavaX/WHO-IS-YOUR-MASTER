﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1 keydown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2 keydown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3 keydown");
        }
    }
}
