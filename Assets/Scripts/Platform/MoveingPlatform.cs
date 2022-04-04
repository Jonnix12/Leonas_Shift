using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 moveTo;
    [SerializeField] float speed = 3;
    [SerializeField] float disToTarget = 0.5f;
    [SerializeField] bool isPlayerActive;

    Vector2 startPos;
    Vector2 moveTarget;

    bool playerOn = false;


    string playerTag = "Player";

    void Start()
    {
        startPos = transform.position;
        moveTarget = moveTo;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isPlayerActive)
        {
            if (playerOn)
            {
                Move();
            }
            else
            {
                ReturnToStartPos();
            }
        }
        else
        {
            Move();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains(playerTag))
        {
            collision.gameObject.transform.parent = transform;
            playerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains(playerTag))
        {
            collision.gameObject.transform.parent = null;
            playerOn = false;
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTarget, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, moveTarget) < disToTarget)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (moveTarget == moveTo)
        {
            moveTarget = startPos;
        }
        else if (moveTarget == startPos)
        {
            moveTarget = moveTo;
        }
    }

    void ReturnToStartPos()
    {
        moveTarget = startPos;
        transform.position = Vector2.MoveTowards(transform.position, moveTarget, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, startPos) < disToTarget)
        {
            moveTarget = moveTo;
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(moveTo, 0.3f);
    }
}
