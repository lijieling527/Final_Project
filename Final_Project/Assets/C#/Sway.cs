using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{

    private float swayAmount = 10.0f;

    private float swaySpeed = 2.0f;

    private float initialRotationZ;

    void Start()
    {
        initialRotationZ = transform.rotation.z;
    }

    void Update()
    {
    
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotationZ + sway);
    }
}