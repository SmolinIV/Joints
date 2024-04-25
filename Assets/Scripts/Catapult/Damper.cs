using System;
using UnityEngine;

public class Damper : MonoBehaviour
{
    public event Action HittedBlock;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Block block))
            HittedBlock?.Invoke();
    }
}
