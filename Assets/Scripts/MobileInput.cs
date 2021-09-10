using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get;}

    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    private Vector2 _swipeDelta, _startTouch;
    private const float _deadZone = 100;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;
       
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _startTouch = _swipeDelta = Vector2.zero;
        }
        if (Input.touches.Length!=0)
        {
            if (Input.touches[0].phase==TouchPhase.Began)
            {
                tap = true;
                _startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _startTouch = _swipeDelta = Vector2.zero;
            }
        }
        _swipeDelta = Vector2.zero;
        if (_startTouch!=Vector2.zero)
        {
            if (Input.touches.Length!=0)
            {
                _swipeDelta = Input.touches[0].position - _startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
            }
        }

        if (_swipeDelta.magnitude>_deadZone)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;

            if (Mathf.Abs(x)>Mathf.Abs(y))
            {
                if (x<0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
            _startTouch = _swipeDelta = Vector2.zero;
        }
    }
}
