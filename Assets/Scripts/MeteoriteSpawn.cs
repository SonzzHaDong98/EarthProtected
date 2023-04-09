using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawn : MonoBehaviour
{
    public Meteorite meteoritePrefab;
    public float spawnRate;
    public float trajectoryVariance;
    public int spawnAmount;
    public float spawnDistance;
    GameManager gm;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Meteorite meteorite = Instantiate(meteoritePrefab, spawnPoint, rotation);
            meteorite.SetTrajectory(rotation * -spawnDirection);
        }
    }  
}
