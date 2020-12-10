/*
 * Name: John Mordi, George Tang
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
    //public static int score;
    private int time;
    private bool gameOver;
    public static bool tutorialOver;
    public static int currentLevelName = 0;
    public static float collectables;
    public Text dialogue;
    public GameObject intro, introImage1, introImage2, introImage3, introImage4, introImage5, winOutro, lossOutro;
    //public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        time = 300;
        tutorialOver = false;
        collectables = 0f;
        //score = 0;
        //UpdateScore(0);
        dialogue.alignment = TextAnchor.LowerCenter;
        dialogue.fontSize = 20;
        StartCoroutine(Timer());
    }
    // score adding when collectible has been hit
    //public void UpdateScore(int scoreToAdd)
    //{
    //    score += scoreToAdd;
    //    scoreText.text = "Score: " + score;
    //}

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(currentLevelName) && SceneManager.sceneCount > 1)
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentLevelName));
        
        if (time > 0 && collectables == 12 && tutorialOver && currentLevelName == 1)
        {
            StopAllCoroutines();
            gameOver = true;
            winOutro.SetActive(true);
            SceneManager.UnloadSceneAsync(currentLevelName);
            currentLevelName = 0;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "Max remembered the dream and decided to follow it!\n(You Win! Press R to play again!)";
        }
        else if(time == 0 && collectables != 12)
        {
            gameOver = true;
            lossOutro.SetActive(true);
            SceneManager.UnloadSceneAsync(currentLevelName);
            currentLevelName = 0;
            timeText.alignment = TextAnchor.MiddleCenter;
            timeText.fontSize = 40;
            timeText.text = "The dream has been forgotten and Max is still missing something in life.\n(You Lose! Press R to try again!)";
        }
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(currentLevelName == 0 || currentLevelName == 1)
        {
            dialogue.text = "";
            
        }
        //Dialogue goes here
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
                dialogue.text = "Our escape is complete, but our journey is just beginning.  And that journey brings many gifts and many challenges… and sometimes those are the same things. - Moses";
            }
        }
    }
    public void IntroMethod()
    {
        StartCoroutine(Intro());
    }
    IEnumerator Intro()
    {
        intro.SetActive(true);
        timeText.alignment = TextAnchor.MiddleCenter;
        timeText.fontSize = 30;
        timeText.text = "(PLACEHOLDER IMAGE1)Through the progression of life many lose their will or inspiration to see the world. It is often these journeys that lead to a better understanding of our surroundings, and a renewed perspective on where we started." +
            " Max has lost his will to see the world. Renew his will and complete his dream.\n(Press the LEFT-MOUSE BUTTON to get through the tutorial.)";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage1.SetActive(false);
        introImage2.SetActive(true);

        timeText.text = "(PLACEHOLDER IMAGE2)";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage2.SetActive(false);
        introImage3.SetActive(true);

        timeText.text = "(PLACEHOLDER IMAGE3)";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage3.SetActive(false);
        introImage4.SetActive(true);

        timeText.text = "(PLACEHOLDER IMAGE4)";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage4.SetActive(false);
        introImage5.SetActive(true);

        timeText.text = "(PLACEHOLDER IMAGE5)";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;


        intro.SetActive(false);
        timeText.alignment = TextAnchor.UpperLeft;
        timeText.fontSize = 14;
        timeText.text = "";
        LoadLevel(1);
        yield break;
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
