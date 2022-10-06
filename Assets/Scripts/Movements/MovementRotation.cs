using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed);
    }
}
