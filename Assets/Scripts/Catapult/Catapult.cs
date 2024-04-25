using UnityEngine;

[RequireComponent(typeof(CannonBallsPool))]
[RequireComponent (typeof(Thrower))]

public class Catapult : MonoBehaviour
{
    [SerializeField] private Damper _damper;
    
    private Thrower _thrower;
    private CannonBallsPool _cannonBallsPool;

    private float _defaultEulerAngleX;

    private void Awake()
    {
        _thrower = GetComponent<Thrower>();
        _cannonBallsPool = GetComponent<CannonBallsPool>();

        _defaultEulerAngleX = transform.eulerAngles.x;
    }

    private void OnEnable()
    {
        _damper.HittedBlock += Recharge;
    }

    private void OnDisable()
    {
        _damper.HittedBlock -= Recharge;        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    private void Attack()
    {
        float degreesEpsilon = 2f;

        if (transform.eulerAngles.x - _defaultEulerAngleX > degreesEpsilon)
            return;

        if (_cannonBallsPool.TryGetCannonBall(out CannonBall cannonBall))
            _thrower.ThrowBall();
    }

    private void Recharge()
    {
        _thrower.RemoveBasket();
    }
}
