using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public static event Action Switch;

    public static bool isLight = true;

    [SerializeField] KeyCode ActiveKey;


    private void Update()
    {
        if (Input.GetKeyDown(ActiveKey))
        {
            if (isLight == true)
            {
                isLight = false;
            }
            else if (isLight == false)
            {
                isLight = true;
            } 

            Switch?.Invoke();
        }
    }
}
