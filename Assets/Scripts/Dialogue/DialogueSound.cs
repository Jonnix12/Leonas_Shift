using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSrc;
    AudioClip  textSound1, textSound2, textSound3;
    void Start()
    {
        textSound1 = Resources.Load<AudioClip>("Audio/Text/text1");
        textSound2 = Resources.Load<AudioClip>("Audio/Text/text2");
        textSound3 = Resources.Load<AudioClip>("Audio/Text/text3");
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "text1":
                audioSrc.PlayOneShot(textSound1);
                break;
            case "text2":
                audioSrc.PlayOneShot(textSound2);
                break;
            case "text3":
                audioSrc.PlayOneShot(textSound3);
                break;
        }
    }
}
