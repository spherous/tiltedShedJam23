using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeartColorOnTrigger : MonoBehaviour
{
    [SerializeField] private Color lightUpColor;
    [SerializeField] private GameObject particlePrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Heart heart = other.gameObject.GetComponent<Heart>();
        if(heart != null)    
        {
            heart.targetColor = lightUpColor;
            Instantiate(particlePrefab, other.transform.position, Quaternion.identity);
            // heart.GetComponent<SpriteRenderer>().color = lightUpColor;
        }
    }
}