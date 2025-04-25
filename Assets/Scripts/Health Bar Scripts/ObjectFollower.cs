using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform objectToBeFollowed;

    // Update is called once per frame
    void Update()
    {
        if (objectToBeFollowed != null)
            transform.position = new Vector2(objectToBeFollowed.position.x, objectToBeFollowed.position.y +0.7f);
        else
            Destroy(gameObject);
    }
}
