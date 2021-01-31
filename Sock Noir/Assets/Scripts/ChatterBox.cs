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
            var dialog = new Dialog{
                name = characterName,
                sentences = sentences
            };
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }
}
