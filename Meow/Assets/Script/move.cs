using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f; 
    public Vector3 jumpForce = new Vector3 (0.0f, 10.0f, 0.0f);
    public float rotationSpeed = 1f; 
    private Rigidbody rb; 
    private float yRotate = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        { 
            
            rb.AddForce(jumpForce, ForceMode.Impulse); 
        }

    }

    // Update is called once per frame
void RotateView()
{
yRotate += Input.GetAxis("Mouse X") * rotationSpeed;

transform.eulerAngles = new Vector3(0, yRotate, 0);
}

bool isGrounded()
{
   int layerMask = LayerMask.GetMask("Ground");
    Vector3 offset = new Vector3(0.0f, -0.5f, 0.0f);
    return Physics.Raycast(transform.position + offset, Vector3.down,
    0.6f,layerMask);

}


    void Update()
    {
        Vector3 moveDir = Vector3.zero;  
        if (Input.GetKey(KeyCode.A))
        {   
           moveDir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
           moveDir.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
           moveDir.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
           moveDir.x = 1.0f;
        }
     
        Vector3 movement = transform.forward * moveDir.y + 
        transform.right * moveDir.x;
        moveDir = movement * speed * Time.deltaTime;

        transform.Translate(moveDir, Space.World);
        
        Jump();
        RotateView();
        // Vector3 position = transform.position;
        // position.x += speed * Time.deltaTime;
        // transform.position = position;


    }
}
