using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public enum Interactions
    {
        Inspect,
        Pickup,
        Use,
    }

    public void ShowInteractOptions();
}
