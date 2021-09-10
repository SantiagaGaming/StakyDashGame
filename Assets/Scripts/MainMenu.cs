using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    private int _sceneIndex;
    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(_sceneIndex + 1);
    }
}
