/*  George Tang
 *  Project 2
 * tells the story of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public Text storyText;

    
    protected virtual void Awake()
    {
        StartCoroutine(storyFuntions());
    }


    IEnumerator storyFuntions()
    {
        // This is a temporary template. Repeat this for each line if needed to continue story
        storyText.text = "You are asleep. Imagine a world of happiness";
        while (!Input.GetKeyDown(KeyCode.R))
        {
            yield return null;
        }

        
        // breaks from the story porton and makes storyText = NULL
        storyText.text = "";

        yield break;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
