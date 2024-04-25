using System.Collections.Generic;
using UnityEngine;

public class CannonBallsPool : MonoBehaviour
{
    [SerializeField] private CannonBall _cannonBallPrefab;
    [SerializeField] private Transform _cannonBallSpawnPoint;
    [SerializeField] private int _cannonBallCount = 5;

    private List<CannonBall> _cannonBalls;

    private void Awake()
    {
        _cannonBalls = new List<CannonBall>();

        for (int i = 0; i < _cannonBallCount; i++)
        {
            _cannonBalls.Add(Instantiate(_cannonBallPrefab));
            _cannonBalls[i].gameObject.SetActive(false);
        }
    }

    public bool TryGetCannonBall(out CannonBall spawnedCannonBall)
    {
        spawnedCannonBall = null;

        foreach (CannonBall cannonBall in _cannonBalls)
        {
            if (cannonBall.gameObject.activeSelf == false)
            {
                spawnedCannonBall = cannonBall;
                spawnedCannonBall.transform.position = _cannonBallSpawnPoint.transform.position;
                spawnedCannonBall.gameObject.SetActive(true);

                return true;
            }
        }

        return false;
    }
}