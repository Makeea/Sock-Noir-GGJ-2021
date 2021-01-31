using UnityEngine;

public class ChatterBox : Interactable
{
    private Dialog dialog;
    void Update()
    {
        if (interact && Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
            interact = false;
        }
    }

    void Start() {
        // var dialogs = FindObjectOfType<DialogContainer>().dialogs;
        var dialogs = DialogContainer.dialogs;
        dialog = dialogs[Random.Range(0, dialogs.Count)];
    }
}
