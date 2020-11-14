using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRb;
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
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //zRotation -= x;

        //zRotation = Mathf.Clamp(zRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);


        Vector3 vector = transform.forward * z;// + transform.right * x * speed;
        controller.Move(vector);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.forward * 30, ForceMode.Impulse);
        }
    }
}
