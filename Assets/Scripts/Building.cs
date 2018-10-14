using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public int Width => _width;
    public int Height => _height;
    public int Cost => _cost;

    [SerializeField]
    private int _width;
    [SerializeField]
    private int _height;
    [SerializeField]
    private int _cost;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
