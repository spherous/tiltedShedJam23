using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    private Queue<Beer> beerPool = new Queue<Beer>();
    [SerializeField] private GameObject beerPrefab;
    [SerializeField] private float preSpawnAmount;
    
    public float beerSpeed;
    public float amountPerMinute;
    private float nextSpawnAtTime;

    [SerializeField] private List<Lane> lanes = new List<Lane>();

    private void Awake()
    {
        PreSpawn();
    }
    private void PreSpawn()
    {
        for (int i = 0; i < preSpawnAmount; i++)
        {
            GameObject newGO = Instantiate(beerPrefab);
            Beer newBeer = newGO.GetComponent<Beer>();
            beerPool.Enqueue(newBeer);
            newBeer.Spawned(this);
            newGO.SetActive(false);
        }
    }
    public void Return(Beer beer)
    {
        beerPool.Enqueue(beer);
        beer.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= nextSpawnAtTime)
        {
            nextSpawnAtTime = Time.timeSinceLevelLoad + (60f / amountPerMinute);
            SpawnBeer(UnityEngine.Random.Range(0, 4));
        }
    }

    public void SpawnBeer(int laneIndex)
    {
        if(beerPool.Count <= 0)
            PreSpawn();

        Beer beer = beerPool.Dequeue();
        beer.gameObject.SetActive(true);
        beer.Fly(lanes[laneIndex].transform.position.y, beerSpeed, laneIndex);
    }
}
