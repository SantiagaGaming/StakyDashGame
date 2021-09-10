using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState { 
    movingLeft,
    movingRight,
    movingDown,
    movingUp,
    stand
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    public bool canMove;
    public Rigidbody _rb;

    [SerializeField] private GameObject _dashesParent;
    [SerializeField] private GameObject _currentDash;

    [HideInInspector] public float speed = 100f;
    [HideInInspector]public bool canMoveUp;
    [HideInInspector] public bool canMoveDown;
    [HideInInspector] public bool canMoveLeft;
    [HideInInspector] public bool canMoveRight;

    private Stack <GameObject>_dashesStack;

    private void Awake()
    {
        _dashesStack = new Stack<GameObject>();
        _dashesStack.Push(_currentDash);
        canMove = true;
        currentState = PlayerState.stand;
        
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        if (canMove)
        {
            if(currentState == PlayerState.stand)
            {
                _rb.velocity = Vector3.zero;
            }
            if (currentState == PlayerState.movingUp)
            {
                if (canMoveUp) {
                _rb.velocity = Vector3.forward * speed * Time.deltaTime/2;
                }
                if(!canMoveUp)
                {
                    currentState = PlayerState.stand;
                }
            }
            if (currentState == PlayerState.movingDown)
            {
                if (canMoveDown) {
                _rb.velocity = -Vector3.forward * speed * Time.deltaTime/2;
                }
                if(!canMoveDown)
                {
                    currentState = PlayerState.stand;
                }
            }
            if (currentState == PlayerState.movingLeft)
            {
                if (canMoveLeft) {
                _rb.velocity = Vector3.left * speed * Time.deltaTime/2;
                }
                if(!canMoveLeft)
                {
                    currentState = PlayerState.stand;
                }
            }
            if (currentState == PlayerState.movingRight )
            {
                if (canMoveRight) { 
                _rb.velocity = Vector3.right * speed * Time.deltaTime/2;
                }
                if(!canMoveRight)
                { currentState = PlayerState.stand; }
            }
        }
    }


    public void PushDashes(GameObject dash)
    {
        _dashesStack.Push(dash);
        dash.transform.SetParent(_dashesParent.transform);
        Vector3 pos = _currentDash.transform.localPosition;
        pos.y -= 0.06f;
        dash.transform.localPosition = pos;
        Vector3 playerPos = transform.localPosition;
        playerPos.y += 0.06f;
        transform.localPosition = playerPos;
        _currentDash.AddComponent<StackScript>();
        _currentDash = dash;
        _currentDash.GetComponent<BoxCollider>().isTrigger = false;
    }
    public void PopDashes()
    {
        if(_dashesStack.Count>1)
        {
        Vector3 pos = _dashesStack.Peek().transform.localPosition;
        pos.y += 0.06f;
        _dashesStack.Peek().transform.localPosition = pos;
        Vector3 playerPos = transform.localPosition;
        playerPos.y -= 0.06f;
        transform.localPosition = playerPos;
        Destroy(_dashesStack.Pop());
        _currentDash = _dashesStack.Peek();
        }
    }
}
