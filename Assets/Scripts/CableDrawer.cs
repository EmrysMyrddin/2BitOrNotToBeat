using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDrawer : MonoBehaviour {
	private static int COLS = 20, ROWS = 10;
	public GameObject g;
	public GameObject CasePrefab;

	private Plane plane = new Plane(Vector3.back, Vector3.zero);
	private Case[,] grid = new Case[COLS,ROWS];
	private Vector2Int currentPos, previousPos;

	// Use this for initialization
	void Start () {
		for(int x = 0 ; x < COLS ; x++) {
			for(int y = 0 ; y < ROWS ; y++) {
				GameObject newCase = Instantiate(CasePrefab, new Vector3((float)x, (float)y, 0f), Quaternion.identity);
				grid[x, y] = newCase.GetComponent<Case>();
			}
		}
	}

	void OnMouseDown() {
		Vector2Int mousePos = MousePosition();
		previousPos = mousePos;
		grid[mousePos.x, mousePos.y].SetIsCable(true);
	}

	void OnMouseDrag() {
		Vector2Int mousePos = MousePosition();
		if(mousePos.x >= COLS || mousePos.y >= ROWS || mousePos.x < 0 || mousePos.y < 0) return;
		float dx = Math.Abs(mousePos.x - previousPos.x);
		float dy = Math.Abs(mousePos.y - previousPos.y);
		Debug.Log("dx="+dx+"|dy="+dy+"|"+(dx == 1 ^ dy == 1));
		if( dx + dy == 1) {
			grid[mousePos.x, mousePos.y].SetIsCable(true);
			grid[previousPos.x, previousPos.y].SetIsPrevious(false);
			grid[mousePos.x, mousePos.y].SetIsPrevious(true);
			previousPos = mousePos;
		}
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
