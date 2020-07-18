using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    private Queue<Heart> heartPool = new Queue<Heart>();
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private float preSpawnAmount;
    
    public float heartSpeed;
    public float amountPerMinute;
    private float nextSpawnAtTime;

    private void Awake()
    {
        PreSpawn();
    }

    private void PreSpawn()
    {
        for (int i = 0; i < preSpawnAmount; i++)
        {
            GameObject newGO = Instantiate(heartPrefab);
            Heart newHeart = newGO.GetComponent<Heart>();
            heartPool.Enqueue(newHeart);
            newHeart.Spawned(this);
            newGO.SetActive(false);
        }
    }

    internal void Return(Heart heart)
    {
        heartPool.Enqueue(heart);
        heart.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad >= nextSpawnAtTime)
        {
            nextSpawnAtTime = Time.timeSinceLevelLoad + (60f / amountPerMinute);
            SpawnHeart(UnityEngine.Random.Range(-4f, 6f));
        }
    }

    public void SpawnHeart(float height)
    {
        if(heartPool.Count <= 0)
            PreSpawn();

        Heart heart = heartPool.Dequeue();
        heart.gameObject.SetActive(true);
        heart.Fly(height, heartSpeed);
    }
}