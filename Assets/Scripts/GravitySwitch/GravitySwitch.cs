using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    public bool canPress = false;
    
    [SerializeField] private KeyCode switcGravity;

    private Transform _playerTransform;

    private float _gravityMultiplier = 9.81f;
    
    private Vector2[] _gravityDirection =
    {
        new Vector2(0, -9.81f), //Down(0)
        new Vector2(9.81f, 0), //Right (1)
        new Vector2(0, 9.81f), //Up(2)
        new Vector2(-9.81f, 0), //Left (3)
    };
    
    private int[] _playerDirection =
    {
        0,
        90,
        180,
        270
    };

    private int _directionCount = 0;
    
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress && Input.GetKeyDown(switcGravity))
        {
            GravityChanage();
        }
    }

    private void GravityChanage()
    {
        if (_directionCount >= 3)
        {
            _directionCount = 0;
        }
        else
        {
            _directionCount++;
        }
        
        _playerTransform.Rotate(0,0,_playerDirection[_directionCount]);
        Physics2D.gravity = _gravityDirection[_directionCount];
    }
}
