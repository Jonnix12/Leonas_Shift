using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    [SerializeField] GameObject visual;

    [SerializeField] bool isDefaultLight;

    [SerializeField] bool isDeactive;

    [SerializeField] Sprite darkSprite;

    [SerializeField] Sprite lightSprite;

    bool isActive;

    SpriteRenderer spriteRend;


    void Start()
    {
        SwitchManager.Switch += Switch;

        spriteRend = GetComponentInChildren<SpriteRenderer>();

        isActive = isDefaultLight;

        if (isDeactive)
        {
            if (isDefaultLight)
            {
                spriteRend.sprite = lightSprite;
            }
            else
            {
                spriteRend.sprite = darkSprite;
            }

            visual.SetActive(isActive);
        }
        else
        {
            spriteRend.sprite = lightSprite;
        }
    }

    void Switch()
    {
        if (isDeactive)
        {
            if (SwitchManager.isLight == true)
            {
                if (isDefaultLight)
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }
            }
            else if (SwitchManager.isLight == false)
            {
                if (isDefaultLight)
                {
                    isActive = false;
                }
                else
                {
                    isActive = true;
                }
            }

            visual.SetActive(isActive);
        }
        else
        {
            if (SwitchManager.isLight == false)
            {
                spriteRend.sprite = darkSprite;
            }
            else if (SwitchManager.isLight == true)
            {
                spriteRend.sprite = lightSprite;
            }
        }

    }
}
