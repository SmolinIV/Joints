using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Seat _seat;
    [SerializeField] private float _swinningForce = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _seat.Push(_swinningForce);
    }
}
