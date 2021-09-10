using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow)  || MobileInput.Instance.swipeLeft )
        {
            _playerController.currentState = PlayerState.movingLeft;
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)  || MobileInput.Instance.swipeRight )
        {
            _playerController.currentState = PlayerState.movingRight;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)  || MobileInput.Instance.swipeUp)
        {
            _playerController.currentState = PlayerState.movingUp;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown )
        {
            _playerController.currentState = PlayerState.movingDown;
        }
    }
}
