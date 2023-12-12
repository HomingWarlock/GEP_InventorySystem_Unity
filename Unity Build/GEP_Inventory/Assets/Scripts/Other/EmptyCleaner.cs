using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmptyCleaner : MonoBehaviour
{
    void Update ()
    {
        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
