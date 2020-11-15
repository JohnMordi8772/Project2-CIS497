using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager :  Singleton<GameManager>
{
    public Text timeText;
    private int time;
    private bool gameOver;
    public static bool tutorialOver;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        time = 60;
        tutorialOver = false;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        float collectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        if(time > 0 && collectables == 0)
        {
            StopAllCoroutines();
            gameOver = true;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "You Win!\n(Press R to play again!)";
        }
        else if(time == 0 && collectables > 0)
        {
            gameOver = true;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "You Lose!\n(Press R to try again!)";
        }
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Timer()
    {
        timeText.text = "Time: " + time;
        while(time >0)
        {
            yield return new WaitForSeconds(1);
            --time;
            timeText.text = "Time: " + time;
        }
        yield break;
    }
}
