using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.position += -transform.right * (speed * Time.deltaTime);
    }
}
