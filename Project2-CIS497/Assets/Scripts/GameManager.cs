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
    public static GameObject portal = null;
    public bool closeSOL, closeF, closeME, closeP, done;
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
        closeSOL = true;
        closeF = true;
        closeME = true;
        closeP = true;
        done = false;
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
        
        if(currentLevelName == 1 && !done)
        {
                GameObject.FindGameObjectWithTag("SOL").SetActive(closeSOL);
                GameObject.FindGameObjectWithTag("FC").SetActive(closeF);
                GameObject.FindGameObjectWithTag("ME").SetActive(closeME);
                GameObject.FindGameObjectWithTag("P").SetActive(closeP);
                done = true;
        }

        if(currentLevelName != 1 && currentLevelName != 0 && portal == null)
        {
            portal = GameObject.FindGameObjectWithTag("Portal");
            portal.SetActive(false);
        }
        
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
            if (currentLevelName == 2 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            { 
                dialogue.text = "A symbol of hope comes to light in Max’s Mind. Max wants to learn more about his home and understand its roots more clearly. ";
                portal.SetActive(true);
                closeSOL = false;
                done = false;
            }
            else if(currentLevelName == 3 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                dialogue.text = "Visions of complex structures in a far away land. Max wants to understand the world better." +
                    " Finding these fragments helps Max remember to see the world in his lifetime. ";
                portal.SetActive(true);
                closeF = false;
                done = false;
            }
            else if(currentLevelName == 4 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                dialogue.text = "A titan climbs through the clouds as Max begins to remember the mountains of the Himalayas in Nepal." +
                    " To see the world from such great heights may change Max’s perspective on what is important in life.";
                portal.SetActive(true);
                closeME = false;
                done = false;
            }
            else if(currentLevelName == 5 && GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
            {
                dialogue.text = "With these fragments of his memory Max begins to remember great Pyramids from an ancient civilization." +
                    " Finding these fragments helps Max remember to see the world in his lifetime.";
                portal.SetActive(true);
                closeP = false;
                done = false;
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
        timeText.alignment = TextAnchor.LowerCenter;
        timeText.fontSize = 25;
        timeText.text = "This is Max. After another long day in the workplace his ability to stay focus has dwindled.(Press the LEFT-MOUSE BUTTON to progress the story.";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage1.SetActive(false);
        introImage2.SetActive(true);

        timeText.text = "Throughout the day Max daydreams of where he would rather be. Max’s daily work and daily routine has left him unfocused and distracted from his goals. ";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage2.SetActive(false);
        introImage3.SetActive(true);

        timeText.text = "Even when enjoying taking a break from a long day’s work…";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage3.SetActive(false);
        introImage4.SetActive(true);

        timeText.text = "…Max still finds himself distracted thinking about where he could be.";

        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        yield return null;

        introImage4.SetActive(false);
        introImage5.SetActive(true);

        timeText.text = "All of Max’s hard work has always been a means to be able to afford a comfortable life where such adventures can be taken. " +
            "Max, however, has forgotten to do what is important to him most. While Max begins to fall asleep, he has a dream." +
            " A dream of travels that take him far from home.";

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
