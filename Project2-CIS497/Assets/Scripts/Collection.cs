﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public GameObject hide1;
    //public GameObject hide2;

    // Start is called before the first frame update
    void Start()
    {
        //hide1 = GameObject.Find("Eagle1");
        //hide2 = GameObject.Find("Eagle2");
        //hide1.gameObject.SetActive(true);
        //hide2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //hide2.gameObject.SetActive(true);
        }
    }
}
