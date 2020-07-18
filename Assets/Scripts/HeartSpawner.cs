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

    [SerializeField] private List<Transform> lanes = new List<Transform>();

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
            SpawnHeart(UnityEngine.Random.Range(0, 4));
        }
    }

    public void SpawnHeart(int laneIndex)
    {
        if(heartPool.Count <= 0)
            PreSpawn();

        Heart heart = heartPool.Dequeue();
        heart.gameObject.SetActive(true);
        heart.Fly(lanes[laneIndex].position.y, heartSpeed);
    }
}