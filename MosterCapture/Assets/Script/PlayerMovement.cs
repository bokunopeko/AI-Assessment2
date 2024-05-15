using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private Vector3 input;
    public Camera camera;
    public bool isGrounded;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();

        if (camera == null )
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ////input
        // input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //    transform.position += input * speed * Time.deltaTime;

        Vector3 vertInput = new Vector3(0, 0, Input.GetAxis("Vertical"));
        Vector3 hortInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);


       /* if (input.magnitude > 1)
        {
            input.Normalize();
        }*/

        //relational movement 
        vertInput = camera.transform.TransformDirection(vertInput);
        hortInput = camera.transform.TransformDirection(hortInput);
        input = vertInput + hortInput;
        input.y = 0f;
        input.Normalize();
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
        }

    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(transform.position + input * speed * Time.deltaTime);

       isGrounded =  Physics.Raycast(transform.position, -transform.up, 1f, groundMask);
       //Debug.DrawRay(transform.position, -transform.up * 1f, Color.magenta, 0.1f);
       
    }
}
