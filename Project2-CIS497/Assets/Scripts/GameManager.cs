/*
 * Name: John Mordi
 * Project Dream
 * Purpose: controls the aspects of the game, win/loss conditions, timer, collecting objects
 */

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
    public static int currentLevelName = 0;
    public static float collectables = 0f;
    public Text dialogue;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        time = 300;
        tutorialOver = false;
        dialogue.alignment = TextAnchor.LowerCenter;
        dialogue.fontSize = 20;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        //float collectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        if (time > 0 && collectables == 12 && tutorialOver && currentLevelName == 1)
        {
            StopAllCoroutines();
            gameOver = true;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "You Win!\n(Press R to play again!)";
        }
        else if(time == 0 && collectables != 12)
        {
            gameOver = true;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "You Lose!\n(Press R to try again!)";
        }
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(currentLevelName == 0 || currentLevelName == 1)
        {
            dialogue.text = "";
        }
        //Diaglouge goes here
        else
        {
            /*
             * these quotes can be changed later to fit something more linear with the "character" of the story later. 
             * For now these quotes are in place for the playtesting part of our project. 
             * 
             */
            if (currentLevelName == 2 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            { 
                dialogue.text = "...There are no words that can tell the hidden spirit of the wilderness "             +
                    "that can reveal its mystery, its melancholy and its charm. The nation behaves well if it "        +
                    "treats the natural resources as assets which it must turn over to the next generation increased " +
                    "and not impaired in value. - Theodore Roosevelt";
            }
            else if(currentLevelName == 3 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                dialogue.text = "A good traveller has no fixed plans, and is not intent on arriving. - Lao Tzu";
            }
            else if(currentLevelName == 4 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                //George Mallory passed in 1924. Copyrights on text go into public domain after 70 years after the death of an author/ commmentator (so clear as of 1994). 
                dialogue.text = "I look back on tremendous effects and exhaustion and dismal looking out of a tent door onto " +
                                 "a dismal world of snow and vanishing hopes - and yet... there have been a good many things to set on the other side." +
                                 " - George Mallory";
            }
            else if(currentLevelName == 5 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                dialogue.text = "Egypt";
            }
        }
    }

    public void LoadLevel(int levelName)
    {
        Cursor.lockState = CursorLockMode.Locked;
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        currentLevelName = levelName;
    }
    public static void LoadLevelStatic(int levelName)
    {
        Cursor.lockState = CursorLockMode.Locked;
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        currentLevelName = levelName;
    }

    public void RestartLevel()
    {
        int restartName = currentLevelName;
        AsyncOperation ao = SceneManager.UnloadSceneAsync(restartName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + restartName);
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        ao = SceneManager.LoadSceneAsync(restartName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + restartName);
            return;
        }
        currentLevelName = restartName;
    }

    public void UnloadLevel(int levelName)
    {
        Cursor.lockState = CursorLockMode.Confined;
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

    public static void UnloadLevelStatic(int levelName)
    {
        Cursor.lockState = CursorLockMode.Confined;
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + currentLevelName);
            return;
        }
    }

    //public void Pause()
    //{
    //    Time.timeScale = 0f;
    //    pauseMenu.SetActive(true);
    //    Cursor.lockState = CursorLockMode.Confined;
    //}

    //public void Unpause()
    //{
    //    Time.timeScale = 1f;
    //    pauseMenu.SetActive(false);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        Pause();
    //    }
    //}

    IEnumerator Timer()
    {

        //timeText.text = "Time: " + time;
        while(time >0)
        {
            if (currentLevelName != 1 && currentLevelName != 0)
            {
                timeText.text = "Time: " + time;
                yield return new WaitForSeconds(1);
                --time;
            }
            yield return null;
        }
        yield break;
    }
}
