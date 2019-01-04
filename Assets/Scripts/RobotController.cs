using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour {
    public float topSpeed = 10f;
    bool isFacingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    // how big the circle will be when we check distance to ground
    float groundRadius = 0.2f;
    public float jumpForce = 700f;
    public LayerMask groundLayer;


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // check if ground circle touch ground
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,groundLayer);

        animator.SetBool("Ground",grounded);
        // How fest we are moving up/down
        animator.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move));

        if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight))
        {
            Flip();
        }
    }

    void Update()
    {
        if (grounded && Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Ground",false);
            // Add jump force
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // loading tutorial scene if player got to the arrow
        if (col.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
