using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float rotationSpeed = 30f;
    private float zRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical");

        //zRotation -= x;
        
        //zRotation = Mathf.Clamp(zRotation, -90f, 90f);
        
        //transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
        

        Vector3 vector = transform.forward * 5 + transform.right * x * speed;
        controller.Move(vector * speed * Time.deltaTime);
    }
}
