using System;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Pendulum _pendulum;
    [SerializeField] private float _swinningForce = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            SwingSeat();
    }

    public void SwingSeat() =>
        _pendulum.PushSeat(_swinningForce);
}
