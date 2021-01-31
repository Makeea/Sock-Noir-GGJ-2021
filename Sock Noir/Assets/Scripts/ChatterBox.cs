using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatterBox : Interactable
{
    [SerializeField]
    private string characterName;
    [SerializeField]
    private string[] sentences;

    void Update()
    {
        if (interact && Input.GetButton("Fire1"))
        {
            Debug.Log($"HERE");
            var dialog = new Dialog();
            // dialog.name = "Dave";
            // dialog.sentences = new string[] {
            //     "Oof!",
            //     "Watch where you're colliding, sir!"
            // };
            dialog.name = characterName;
            dialog.sentences = sentences;
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }
}
