using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour {
	
	public static event Action DialogueEvent;

	[SerializeField] TextMeshProUGUI dialogueText;

	[SerializeField] Animator animator;

	[SerializeField] DialogueSound sound;

	[SerializeField] float typingSpeed;

	private Queue<string> sentences;

	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
		//Starts the dialogue and takes the new sentences and compares
       //it to a queue of present sentences
	{
		DialogueEvent?.Invoke();
		animator.SetBool("IsOpen", true);

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
		//An action for the next sentence is called at the beginning of each dialogue 
		//and each time the player presses the continue button
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)//A simple Coroutines that displays one letter at a time on the screen
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			sound.PlaySound("text1");//need work!!!
			yield return new WaitForSeconds(typingSpeed);
		}
	}

	void EndDialogue()
	{
		DialogueEvent?.Invoke();
		animator.SetBool("IsOpen", false);
	}

}
