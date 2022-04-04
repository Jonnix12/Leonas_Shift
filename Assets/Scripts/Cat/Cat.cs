using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] DialogueTrigger dialogueTrigger;

    [SerializeField] GameObject popUp;

    [SerializeField] KeyCode StartDialogue;

    bool isPlayerOverlap = false;

    void Start()
    {
        popUp.SetActive(false);
    }

    
    void Update()
    {
        if (isPlayerOverlap && Input.GetKeyDown(StartDialogue))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        popUp.SetActive(true);
        isPlayerOverlap = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOverlap = false;
        popUp.SetActive(false);
    }
}
