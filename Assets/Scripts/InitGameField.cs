using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameField : ScriptableObject {
    public GameObject[,] GameField { get; }
    private GameObject cell = GameObject.FindGameObjectWithTag("Cell");
    public InitGameField(int row_num, int col_num, Transform cellField)
    {
        GameField = new GameObject[row_num, col_num];
        for (int x = 0; x < row_num; x++)
            for (int z = 0; z < col_num; z++)
            {
                GameField[x, z] = Instantiate(cell, new Vector3(x, cellField.position.y + 0.3f, z), Quaternion.identity, cellField);
            }
    }
}
