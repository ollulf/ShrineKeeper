using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InEditorLayerer : MonoBehaviour
{
    public enum Layer { Undefined, Background, Midground, Foreground };

    public Layer myLayer = Layer.Undefined;

    private void OnDrawGizmosSelected()
    {
        switch (myLayer)
        {
            case Layer.Undefined:
                Debug.LogError("Layer type undefined");
                break;
            case Layer.Foreground:
                UpdateLayering(-10);
                break;
            case Layer.Midground:
                UpdateLayering(0);
                break;
            case Layer.Background:
                UpdateLayering(10);
                break;
        }
    }

    public void UpdateLayering(int offset = 0)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y + offset);
    }

    void Start()
    {
        Destroy(this);
    }
}
