using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayerer : MonoBehaviour
{
    void Awake()
    {
        InEditorLayerer myIEL = GetComponent<InEditorLayerer>();

        switch (myIEL.myLayer)
        {
            case InEditorLayerer.Layer.Undefined:
                Debug.LogError("Layer type undefined");
                break;
            case InEditorLayerer.Layer.Foreground:
                Destroy(this);
                break;
            case InEditorLayerer.Layer.Midground:
                break;
            case InEditorLayerer.Layer.Background:
                Destroy(this);
                break;
        }
    }

    public void UpdateLayering()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
