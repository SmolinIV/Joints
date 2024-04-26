using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float _affectedZoneRadius = 15f;
    [SerializeField] private float _explodeRadius = 5f;
    [SerializeField] private float _explosionForce = 10f;

    private string _ignoringLayerName = "Catapult";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(_ignoringLayerName))
        {
            List<Rigidbody> nearbyObjects = GetExplodeHittedCubes();

            if (nearbyObjects.Count == 0)
                return;

            foreach (Rigidbody objectRigidbody in nearbyObjects)
                objectRigidbody.AddExplosionForce(_explosionForce, transform.position, _explodeRadius);

            gameObject.SetActive(false);
       }
    }

    private List<Rigidbody> GetExplodeHittedCubes()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _affectedZoneRadius);

        List<Rigidbody> objects = new List<Rigidbody>();

        foreach (Collider hit in hits)
           if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}
