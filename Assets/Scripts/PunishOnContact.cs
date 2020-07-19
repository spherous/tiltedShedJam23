using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunishOnContact : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}