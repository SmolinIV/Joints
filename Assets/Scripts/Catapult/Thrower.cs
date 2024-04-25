using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Thrower : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _maxSpringForce = 40f;
    [SerializeField] private float _maxDamperForce = 5f;

    private Rigidbody _rigidbody;

    private float _minSpringForce = 0;

    private float _minDamperForce = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void RemoveBasket()
    {
        _springJoint.spring = _minSpringForce;
        _springJoint.damper = _minDamperForce;
        _rigidbody.AddForce(-transform.forward, ForceMode.Impulse);
    }

    internal void ThrowBall()
    {
        _springJoint.damper = _maxDamperForce;
        _springJoint.spring = _maxSpringForce;
    }
}
