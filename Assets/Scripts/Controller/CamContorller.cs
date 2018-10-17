using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamContorller : MonoBehaviour {
    public float Speed { get; } = 1.0f;
    public float ZoomSpeed { get; } = 1.0f;
    public float OrthographicSize
    {
        get => Camera.main.orthographicSize;
        set
        {
            if (value > 20.0f) Camera.main.orthographicSize = 20.0f;
            else if (value < 8.0f) Camera.main.orthographicSize = 8.0f;
            else Camera.main.orthographicSize = value;
        }
    }

    [SerializeField]
    private float _speed;

    private Vector3 m_startTransformPosition;
    private Vector3 m_currentTransformPosition;
    private Vector3 m_movementDirection;

    private float m_distanceBetweenTwoTouches = 0;

    private int _clickCount;
	// Use this for initialization
	void Start () {
        Debug.Log("CamController init.");
        Debug.Log(name);
	}
	
	// Update is called once per frame
	void Update () {
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
                    Debug.Log(m_movementDirection);
                    transform.localPosition += m_movementDirection * Speed;
                    break;
                //case TouchPhase.Stationary:
                //    m_movementDirection = Vector3.zero;
                //    break;
            }
        }

        if (Input.touchCount == 2)
        {
            var fTouch = Input.GetTouch(0);
            var sTouch = Input.GetTouch(1);
            var fStartPos = Vector3.zero;
            var sStartPos = Vector3.zero;

            if (fTouch.phase == TouchPhase.Began && sTouch.phase == TouchPhase.Began)
            {
                m_distanceBetweenTwoTouches = Vector2.Distance(fTouch.position, sTouch.position);
            }

            if (fTouch.phase == TouchPhase.Moved || sTouch.phase == TouchPhase.Moved)
            {
                var curDistance = Vector2.Distance(fTouch.position, sTouch.position);
                if (m_distanceBetweenTwoTouches > curDistance)
                {
                    OrthographicSize += ZoomSpeed;
                }
                else if (m_distanceBetweenTwoTouches < curDistance)
                {
                    OrthographicSize -= ZoomSpeed;
                }

                m_distanceBetweenTwoTouches = curDistance;
            }

            Debug.Log(Input.touchCount);
        }
    }
}
