using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    public GameObject player;
    public float mouseSensitivity = 100f;
    private float verticalLookRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        player.transform.Rotate(Vector3.up * mouseX);
        player.transform.Rotate(Vector3.right * -mouseY);
        //verticalLookRotation -= mouseY;
        //transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
