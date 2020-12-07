using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerMock
{
    public Text nameText;
    public Text dialogueText;

    //public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    public void Startd()
    {
        this.sentences = new Queue<string>();
    }
    public void StartDialogue(string dialogue)
    {
        //animator.SetBool("IsOpen", true);
        Debug.Log("Starting conversation with" + dialogue);

        //nameText.text = dialogue;

        sentences.Clear();
        string[] Dsentences = { "s1 s1", "s1 s2", "s1 s3" };
        foreach (string sentence in Dsentences)
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
        Debug.Log(sentence);
        //dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
