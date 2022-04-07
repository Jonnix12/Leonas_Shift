using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 moveTo;
    [SerializeField] float speed = 3;
    [SerializeField] float disToTarget = 0.5f;
    [SerializeField] bool isPlayerActive;

    private GameObject _player;

    private Vector2 _startPos;
    private Vector2 _moveTarget;
    private Vector2 _offset;

    public bool _playerOn = false;
    
    void Start()
    {
        _startPos = transform.position;
        _moveTarget = moveTo;
        _player = null;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isPlayerActive)
        {
            if (_playerOn)
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

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTarget, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, _moveTarget) < disToTarget)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (_moveTarget == moveTo)
        {
            _moveTarget = _startPos;
        }
        else if (_moveTarget == _startPos)
        {
            _moveTarget = moveTo;
        }
    }

    void ReturnToStartPos()
    {
        _moveTarget = _startPos;
        transform.position = Vector2.MoveTowards(transform.position, _moveTarget, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, _startPos) < disToTarget)
        {
            _moveTarget = moveTo;
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(moveTo, 0.3f);
    }

    public void SetParant(Transform obj, bool chack)
    {
        if (chack)
        {
            obj.parent = transform;
        }
        else
        {
            obj.parent = null;
        }
    }
}
