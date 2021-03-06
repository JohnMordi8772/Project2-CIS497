﻿/*
 * Name: George Tang, John Mordi
 * Project Dream
 * Purpose: Loads next scene upon portal entry
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // uncomment line to load next scenes 
    // TO DO: make tags for each portal? then if/else to go to which order , ex: +2 for two scenes next, -3 for hub area
    public int nextSceneToLoad;
    public int currentLevel;
    //private GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
    // attach to a portal so player can go back and forth
    // void Start()
    // {
    //     nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    // }

    private void OnTriggerEnter(Collider collision)
    {
        GameManager.UnloadLevelStatic(currentLevel);
        GameManager.LoadLevelStatic(nextSceneToLoad);
        GameManager.portal = null;
        
        //if(GameObject.FindObjectOfType<Text>() != null)
            //GameManager.timeText = GameObject.FindObjectOfType<Text>();
    }
}
