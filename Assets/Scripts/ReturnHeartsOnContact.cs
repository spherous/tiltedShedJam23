using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHeartsOnContact : MonoBehaviour
{
    [SerializeField] private HeartSpawner heartSpawner;
    [SerializeField] private BeerSpawner beerSpawner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Heart heart = other.gameObject.GetComponent<Heart>();
        if(heart != null)
            heartSpawner.Return(heart);
            
        Beer beer = other.gameObject.GetComponent<Beer>();
        if(beer != null)
            beerSpawner.Return(beer);
    }
}
