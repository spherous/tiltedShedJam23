using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHeartsOnContact : MonoBehaviour
{
    [SerializeField] private HeartSpawner heartSpawner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Heart heart = other.gameObject.GetComponent<Heart>();
        if(heart != null)    
        {
            heartSpawner.Return(heart);
        }
    }
}
