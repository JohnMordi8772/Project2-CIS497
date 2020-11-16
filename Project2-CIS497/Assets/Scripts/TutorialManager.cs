/*
 * Name: John Mordi
 * Project Dream
 * Purpose: Manages the tutorial and all objects associated with it
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public GameObject[] rings, portals;
    public GameObject collectable, player;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject[] array = GameObject.FindGameObjectsWithTag("RingMarker");
        if (!GameManager.tutorialOver)
            StartCoroutine(Tutorial());
        else
        {
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].SetActive(true);
            }
        }
    }

    IEnumerator Tutorial()
    {
        GameManager.tutorialOver = true;

        tutorialText.alignment = TextAnchor.LowerCenter;
        tutorialText.fontSize = 20;
        tutorialText.text = "Welcome to the tutorial for \"Fly to Your Dreams!\". (Press the LEFT-MOUSE BUTTON to get through the tutorial.)";

        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "Here we'll show you the basics of playing the game.";

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "As you might have noticed, you can look around using the mouse. This will also control the direction in which you move.";

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "But to move, you will press W to go forward and S to go backwards.";

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "To ensure that you understand how to play, please pass thorugh all the rings in this area.";
        
        for (int i = 0; i < rings.Length; i++)
        {
            rings[i].SetActive(true);
        }
        

        while (GameObject.FindGameObjectsWithTag("RingMarker").Length != 0)
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "Now that you understand movement, the real goal of this game is to collect all collectables, like the burger down by the tree, from each level within 5 minutes. You just have to touch them.";

        Instantiate(collectable, new Vector3(-8,35,70), transform.rotation);

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "There are three items in each level. You should get all of them before leaving a level and after you have done so, you'll have to get to the portal to come back here.";

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "Finally, to enter and exit levels you will need to go into a portal. Portals are represented by colored walls like the ones that just spawned.";

        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].SetActive(true);
        }

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "Now you're ready to start. Go through any portal and get started. The timer won't start till you do and will stop when you come back.";

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        
        tutorialText.text = "";

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
