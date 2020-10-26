/*
 * Name: George Tang
 * Project Dream
 * Purpose: Loads previous scene upon portal entry
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// attach to a portal so player can go back and forth
public class PreviousScene : MonoBehaviour
{
    private int prevSceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        // move to previous scene
        prevSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;

    }

    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene(prevSceneToLoad);
    }
}
