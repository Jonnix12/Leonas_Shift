using System;
using UnityEngine;

namespace Platform
{
    public class CollisionDetact : MonoBehaviour
    {
        [SerializeField] private MoveingPlatform platform;


        private void OnCollisionEnter2D(Collision2D col)
        {
            platform.SetParant(col.transform,true);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            platform.SetParant(other.transform,false);
        }
    }
}
