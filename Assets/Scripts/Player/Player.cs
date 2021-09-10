using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<bool> EndGame;
    [SerializeField] private SoundEffector _soundEffector;
    [SerializeField] private GameController _gameController;
    [SerializeField] private AudioSource _music;
    private PlayerController _playerController;
    private int _score;
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    public void UpdateScore(int getScore)
    {
        _score += getScore;
        _soundEffector.PlayDashSound();
        _gameController.scoreText.text = _score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    { if(other.tag == "Finish")
        {
            _playerController.canMove = false;
            _soundEffector.PlayWinSound();
            _music.volume = 0;
            EndGame?.Invoke(true);
        }
    }
    public int GetScore()
    {
        return _score;
    }
}
