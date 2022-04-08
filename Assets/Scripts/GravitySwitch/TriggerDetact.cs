using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetact : MonoBehaviour
{
   [SerializeField] private GravitySwitch _gravitySwitch;
   
   private void OnTriggerEnter2D(Collider2D col)
   {
      _gravitySwitch.canPress = true;
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      _gravitySwitch.canPress = false;
   }
}
