﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDrawer : MonoBehaviour {
	private static int COLS = 20, ROWS = 10;
	public GameObject CellPrefab;

	private Plane plane = new Plane(Vector3.back, Vector3.zero);
	private Cell[,] grid = new Cell[COLS,ROWS];
	private Vector2Int currentPos;
	private Stack<Vector2Int> currentPath = new Stack<Vector2Int>();

	// Use this for initialization
	void Start () {
		for(int x = 0 ; x < COLS ; x++) {
			for(int y = 0 ; y < ROWS ; y++) {
				GameObject newCell = Instantiate(CellPrefab, new Vector3((float)x, (float)y, 0f), Quaternion.identity);
				grid[x, y] = newCell.GetComponent<Cell>();
			}
		}
	}

	void OnMouseDown() {
		Vector2Int mousePos = MousePosition();
		currentPos = mousePos;
		currentPath = new Stack<Vector2Int>();
		grid[mousePos.x, mousePos.y].SetIsCable(true);
	}

	void OnMouseDrag() {
		Vector2Int mousePos = MousePosition();
		if(mousePos.x >= COLS || mousePos.y >= ROWS || mousePos.x < 0 || mousePos.y < 0) return;

		// Calculate the distance from the current cell
		float dx = Math.Abs(mousePos.x - currentPos.x);
		float dy = Math.Abs(mousePos.y - currentPos.y);

		// If the mouse has mooved to a new cell
		if( dx + dy == 1) {
			if(currentPath.Count > 0 && mousePos == currentPath.Peek()) {
				GetCell(currentPos).SetIsCable(false);
				currentPath.Pop();
				grid[currentPos.x, currentPos.y].SetIsCurrent(false);
				grid[mousePos.x, mousePos.y].SetIsCurrent(true);
				currentPos = mousePos;
			} else if(!GetCell(mousePos).isCable) {
				GetCell(mousePos).SetIsCable(true);
				currentPath.Push(currentPos);
				grid[currentPos.x, currentPos.y].SetIsCurrent(false);
				grid[mousePos.x, mousePos.y].SetIsCurrent(true);
				currentPos = mousePos;
			}

			
		}
	}
	
	Cell GetCell(Vector2Int pos) {
		return grid[pos.x, pos.y];
	}

	Vector3 RoundVector3(Vector3 vector) {
		return new Vector3(Mathf.Floor(vector.x), Mathf.Floor(vector.y), Mathf.Floor(vector.z));
	}

	Vector2Int MousePosition() {
		Vector2 screenPos = Input.mousePosition;
		Ray ray=Camera.main.ScreenPointToRay(new Vector3(screenPos.x, screenPos.y, 1f));
		float distance;
		if(!plane.Raycast(ray, out distance)) throw new UnityException("did not hit plane");
		return Vector2Int.FloorToInt(RoundVector3(ray.GetPoint(distance)));
	}
}
