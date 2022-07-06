using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotateCamera))]
[RequireComponent(typeof(Rigidbody))]
public class RBPlayerMove : MonoBehaviour
{
    RotateCamera cameraReference;
    private Rigidbody rb;
    public float speed = 6f;
    public float speedRunMoltiplicator = 1.2f;
    public float jumpH = 3f;
    public bool isGround = false;

    float horizontal;
    float vertical;


    public float getHorizontal()
    {
        return horizontal;
    }

    public float getVertical()
    {
        return vertical;
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraReference = GetComponent<RotateCamera>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 rotationCamera = cameraReference.cameraObject.transform.rotation.eulerAngles;
        Vector3 newRotation = new Vector3(0, rotationCamera.y, 0);
        direction =  Quaternion.Euler(newRotation) * direction;

        if (Input.GetKey(KeyCode.LeftShift))
            direction *= speedRunMoltiplicator;

        Vector3 velocity = rb.velocity;
        velocity.x = direction.x * speed;
        velocity.z = direction.z * speed;
        rb.velocity = velocity;

        transform.rotation = Quaternion.Euler( new Vector3(0, rotationCamera.y, 0)); // Danger! QuATERNION MATH!


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpH, ForceMode.Impulse);
            isGround = false;
        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }

}
