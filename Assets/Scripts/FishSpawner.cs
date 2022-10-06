using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private Collider spawnArea;
    [SerializeField] private float fishNumber;
    [SerializeField] private GameObject[] fish;

    void Start()
    {
        for (int i = 0; i < fishNumber; ++i)
        {
            Vector3 position = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                1);

            var fishToSpawn = fish[Random.Range(0, fish.Length)];

            var spawned = Instantiate(fishToSpawn, position, Quaternion.identity, gameObject.transform);
        }
    }
}
