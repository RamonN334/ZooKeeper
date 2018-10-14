using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour {
    private InitGameField _initializator;
    public int Width { get; set; } = 50;
    public int Height { get; set; } = 50;
	// Use this for initialization
	void Start () {
        _initializator = new InitGameField(Width, Height, transform);
        transform.position = new Vector3(-1.0f * Width / 2, 0, -1.0f * Height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
