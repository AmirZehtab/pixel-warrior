using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    private Queue<string> sentences;
    private moveplayer move; 
    
    void Start()
    {
        sentences = new Queue<string>();
        move = FindObjectOfType<moveplayer>(); 
    }

    public void StartDialogue(Dialogue dialouge)
    {
        dialoguePanel.SetActive(true);
        move.canMove = false; 

        sentences.Clear();
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        move.canMove = true;
    }
}

