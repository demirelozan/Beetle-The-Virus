using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float jumpForce = 10f;
    private bool grounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontal * speed * Time.deltaTime, rb.velocity.y, vertical * speed * Time.deltaTime);

        /*
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;

        }
        */
        if (horizontal > 0 || vertical > 0)
        {
            GetComponent<Player>().direction = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else if(horizontal < 0 || vertical < 0)
        {
            GetComponent<Player>().direction = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsMoving", false);
        }

    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }
    */
}
