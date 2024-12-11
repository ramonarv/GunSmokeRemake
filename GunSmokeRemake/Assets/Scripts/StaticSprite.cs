using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSprite : MonoBehaviour
{
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}
