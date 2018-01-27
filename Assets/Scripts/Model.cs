using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
	public bool pause = true;
    public float tickDuration = 1f;
    public GameObject CellPrefab;
    public static int COLS = 20, ROWS = 10;
    public Cell[,] grid = new Cell[COLS, ROWS];
    public float nextTick = 0f;
	private float tickProgression = 0f;
    public int tick = 0;

    void Start()
    {
        for (int x = 0; x < COLS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                GameObject newCell = Instantiate(CellPrefab, new Vector3((float)x, (float)y, 0f), Quaternion.identity);
                grid[x, y] = newCell.GetComponent<Cell>();
            }
        }
    }

    public Cell GetCell(Vector2Int pos)
    {
        return grid[pos.x, pos.y];
    }

    void Update()
    {
        if (Time.time - nextTick > tickDuration)
        {
            nextTick = Time.time;
            tick++;
			tickProgression = 0f;
        }

		if(pause) {
			nextTick += Time.deltaTime;
		} else {
			tickProgression = (Time.time - nextTick) / tickDuration;
		}
    }

    public float TickProgression()
    {
        return tickProgression;
    }
}
