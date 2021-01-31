using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool interact = false;
    public void SetInteract(bool interact)
    {
        this.interact = interact;
    }
}
