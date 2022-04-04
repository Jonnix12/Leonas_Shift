using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAnimation : MonoBehaviour
{
    //This Movement script is very short and simple
    

    [SerializeField] LayerMask layer;

    [SerializeField] GameObject shadow;

    [SerializeField] float speed = 10f;

    [SerializeField] float jumpMuliteplayer = 25f;

    [HideInInspector] public bool canMove = true;

    float horizontal;

    public bool faceingRight = true;

    Rigidbody2D rb;

    BoxCollider2D Collider;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private bool IsGrounded()//Check if the player is grounded
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 0.1f, layer);
        animator.SetBool("isJumping", false);
        return raycastHit2D.collider != null;
    }

    private void Filp()//flip the player 
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.World);
    }

    private void Movement()//the movement function
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0 && faceingRight)
        {
            Filp();
            faceingRight = false;
        }
        else if (horizontal > 0 && !faceingRight)
        {
            Filp();
            faceingRight = true;
        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpMuliteplayer;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("Jump");
        }


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void AnimationUpdate()
    {
        animator.SetFloat("velocityY", rb.velocity.y);

        if (rb.velocity.x > 0.1 || rb.velocity.x < -0.1)
        {
            animator.SetBool("isRuning", true);
        }
        else
        {
            animator.SetBool("isRuning", false);
        }

        if (IsGrounded())
        {
            shadow.SetActive(true);
        }
        else
        {
            shadow.SetActive(false);
        }
    }

    private void Update()
    {
        AnimationUpdate();
        Movement();    
    }
}
