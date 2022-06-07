using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> senteces;
    public Text nameText;
    public Text dialogText;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        senteces = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation with" + dialog.name);
        nameText.text = dialog.name;

        senteces.Clear();

        foreach (string sentece in dialog.sentences)
        {
            senteces.Enqueue(sentece);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (senteces.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = senteces.Dequeue();
        dialogText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialog()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of the conversation");
    }

}
