using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
 public Text scoreText;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private AudioSource _music;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _exitButton;
    private int _sceneIndex;
    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _nextLevelButton.onClick.AddListener(NextLevel);
        _exitButton.onClick.AddListener(ExitGame);
    }
    private void OnEnable()
    {
        _player.EndGame += ShowFinishWindow;
    }
    private void OnDisable()
    {
        _player.EndGame -= ShowFinishWindow; 
    }
    private void ShowFinishWindow(bool endGame)
    {
        _finishWindow.SetActive(endGame);
 
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
        _music.volume = 0f;
        _pausePanel.SetActive(true);
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _music.volume = 0.5f;
        _pausePanel.SetActive(false);
    }
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneIndex);

    }
    private void NextLevel()
    {
        if(_sceneIndex<3)
        { 
        SceneManager.LoadScene(_sceneIndex + 1);
        }
        else SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
