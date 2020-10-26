/*
 * Name: George Tang
 * Project Dream
 * Purpose: Loads next scene upon portal entry
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    // attach to a portal so player can go back and forth
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
