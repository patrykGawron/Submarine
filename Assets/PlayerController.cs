using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    [SerializeField] private float horizontalForce = 5.0f;
    [SerializeField] private float verticalForce = 1.0f;
    [SerializeField] private float maxSpeed = 3.0f;

    private Rigidbody rg;

    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 desiredPosition = transform.position;
        float dx = joystick.Horizontal * horizontalForce;
        float dy = joystick.Vertical * verticalForce;

        if (rg.velocity.sqrMagnitude < maxSpeed)
        {
            Vector3 f = transform.forward * joystick.Direction.sqrMagnitude;
            rg.AddForce(f, ForceMode.Acceleration);
        }


        float angle = joystick.Vertical;
        float toCheck = transform.localEulerAngles.x;


        if (joystick.Horizontal > 0)
        {
            rg.MoveRotation(Quaternion.Euler(-joystick.Vertical * 30, 90, transform.localEulerAngles.z));
        }
        else if (joystick.Horizontal < 0)
        {
            rg.MoveRotation(Quaternion.Euler(-joystick.Vertical * 30, -90, transform.localEulerAngles.z));
        }
    }
}
