using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text name;
    public Text dialog;
    private Queue<string> sentences;

    public void StartDialog(Dialog dialog){
        name.text = dialog.name;

        sentences.Clear();
        foreach (string sentence in dialog.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialog.text = sentence;
    }

    void EndDialog() {
        Debug.Log("No more sentences!"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
}
