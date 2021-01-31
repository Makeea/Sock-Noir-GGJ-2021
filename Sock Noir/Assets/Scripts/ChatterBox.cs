using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatterBox : Interactable
{
    void Update()
    {
        if (interact && Input.GetButton("Fire1"))
        {
            var dialog = new Dialog();
            dialog.name = "Dave";
            dialog.sentences = new string[] {
                "Oof!",
                "Watch where you're colliding, sir!"
            };
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }
}
