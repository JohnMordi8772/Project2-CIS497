using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public GameObject[] rings, portals;
    public GameObject collectable;
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

        tutorialText.text = "Now that you understand movement, the real goal of this game is to collect all collectables, like the one in front of you, within 5 minutes.";

        //Instantiate(collectable);

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        yield return null;

        tutorialText.text = "Finally, to enter and exit levels you will need to go into a portal.";

        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].SetActive(true);
        }

        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }

        GameManager.tutorialOver = true;
        tutorialText.text = "";

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
