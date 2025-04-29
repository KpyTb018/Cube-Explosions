using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode
        (float explosionForce, Vector3 explosionPosition,
        float explosionRadius, List<Rigidbody> explorableObjects)
    {
        foreach (Rigidbody explorableObject in explorableObjects)
            explorableObject.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
    }
}
