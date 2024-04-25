using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(HingeJoint))]
public class Pendulum : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PushSeat(float force)
    {
        Vector3 direction = _rigidbody.velocity.z > 0 ? transform.forward : -transform.forward;

        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
