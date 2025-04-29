using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void CreateCubes(Cube cube)
    {
        if (cube.TryDivide())
        {
            int minObjects = 2;
            int maxObjects = 7;
            int numberNewObjects = Random.Range(minObjects, maxObjects);

            List<Rigidbody> ExplorableObjects = new();

            cube.UpdateParameters();

            for (int i = 0; i < numberNewObjects; i++)
            {
                Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
                ExplorableObjects.Add(newCube.GetComponent<Rigidbody>());
            }

            foreach (Rigidbody explorableObject in ExplorableObjects)
                explorableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(cube.gameObject);
    }
}
