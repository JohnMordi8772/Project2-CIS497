/*
 * Name: John Mordi
 * Project Dream
 * Purpose: Gives player control of camera rotation via the mouse
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    public GameObject player;
    public float mouseSensitivity = 100f;
    private float verticalLookRotation = 0f;
    private float mouseX, mouseY, mouseZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        mouseZ = Mathf.Clamp(mouseZ, 0f, 0f);

        player.transform.localRotation = Quaternion.Euler(mouseY, mouseX, mouseZ);
        
        
        //player.transform.Rotate(Vector3.right * -mouseY);
        //verticalLookRotation -= mouseY;
        //transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
