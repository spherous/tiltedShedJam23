using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;
    private float destroyAtTime;

    private void Awake() =>
        destroyAtTime = Time.timeSinceLevelLoad + timeToDestroy;

    private void Update() {
        if(Time.timeSinceLevelLoad >= destroyAtTime)
            Destroy(gameObject);
    }
}
