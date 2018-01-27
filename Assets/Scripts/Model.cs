using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    public GameObject CellPrefab;
    public static int COLS = 20, ROWS = 10;
	public Cell[,] grid = new Cell[COLS,ROWS];

	void Start () {
		for (int x = 0; x < COLS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                GameObject newCell = Instantiate(CellPrefab, new Vector3((float)x, (float)y, 0f), Quaternion.identity);
                grid[x, y] = newCell.GetComponent<Cell>();
            }
        }
	}
	
	public Cell GetCell(Vector2Int pos) {
		return grid[pos.x, pos.y];
	}
}
