using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private Button button;
    void Start() => button.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single));
}
