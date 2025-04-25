using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarCanvasDestroyer : MonoBehaviour
{

    void FixedUpdate()
    {
        if (transform.childCount <= 0)
            Destroy(gameObject);
    }
}
