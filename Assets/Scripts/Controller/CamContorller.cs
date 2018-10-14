using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamContorller : MonoBehaviour {
    public float Speed { get; } = 1.0f;
    [SerializeField]
    private float _speed;
    private Vector3 _startPos;
    private Vector3 _direction;
    private Vector3 _startTransformPos;
    private Vector3 _endTransformPos;


    private Vector3 m_startTransformPosition;
    private Vector3 m_currentTransformPosition;
    private Vector3 m_movementDirection;

    private int _clickCount;
	// Use this for initialization
	void Start () {
        Debug.Log("CamController init.");
        Debug.Log(name);
        _clickCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _startPos = Input.mousePosition;
        //    _startTransformPos = Camera.main.ScreenPointToRay(_startPos).origin;
        //    Debug.Log(String.Format("Start position: {0}", _startPos));

        //}

        //if (Input.GetMouseButton(0))
        //{
        //    var currPos = Input.mousePosition;
        //    var currTransformPos = Camera.main.ScreenPointToRay(currPos).origin;
        //    _direction = _startPos - currPos;
        //    var inverseCurPos = _startPos + _direction; 
        //    if (!_direction.Equals(Vector3.zero))
        //    {
        //        var directionWorldSpace = _startTransformPos - currTransformPos;
        //        Debug.Log(String.Format("Direction: {0}", _direction.normalized));
        //        transform.localPosition += directionWorldSpace * Speed;
        //        _startPos = currPos;
        //    }
        //}
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    m_startTransformPosition = Camera.main.ScreenPointToRay(touch.position).origin;
                    break;
                case TouchPhase.Moved:
                    m_currentTransformPosition = Camera.main.ScreenPointToRay(touch.position).origin;
                    m_movementDirection = m_startTransformPosition - m_currentTransformPosition;
                    transform.localPosition += m_movementDirection * Speed;
                    break;
            }
        }

        if (Input.touchCount == 2)
        {
            var firstTouch = Input.GetTouch(0);
            var secondTouch = Input.GetTouch(1);

            Debug.Log(Input.touchCount);
        }
    }
}
