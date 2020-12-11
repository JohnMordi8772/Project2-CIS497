/*
 * Name: Josh Bumbalough, John Mordi, George Tang
 * Project Dream
 * Purpose: Loads next scene upon portal entry
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{

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
        if(other.CompareTag("Player") && GameManager.currentLevelName != 1)
        {
            Destroy(gameObject);
            GameManager.collectables += 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
