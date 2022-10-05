using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class CointPositionManager : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private Collider coinSpawnConstraints;
    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(coinSpawnConstraints.bounds.min.x, coinSpawnConstraints.bounds.max.x),
            Random.Range(coinSpawnConstraints.bounds.min.y, coinSpawnConstraints.bounds.max.y),
            1);
        GameObject.Instantiate(coin, pos, Quaternion.Euler(90, 0, 90));
    }
}
