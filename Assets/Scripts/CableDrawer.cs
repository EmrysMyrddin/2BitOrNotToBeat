using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDrawer : MonoBehaviour {
	private static int COLS = 20, ROWS = 10;
	public GameObject g;

	private Plane plane = new Plane(Vector3.back, Vector3.zero);
	private Case[,] grid = new Case[COLS,ROWS];

	// Use this for initialization
	void Start () {
		for(int x = 0 ; x < COLS ; x++) {
			for(int y = 0 ; y < ROWS ; y++) {
				
			}
		}
	}

	void OnMouseDrag() {
		Vector3 mousPos = MousePosition();
		Debug.Log(mousPos);
		g.transform.position = RoundVector3(mousPos);
	}
	
	Vector3 RoundVector3(Vector3 vector) {
		return new Vector3(Mathf.Floor(vector.x), Mathf.Floor(vector.y), Mathf.Floor(vector.z));
	}

	Vector3 MousePosition() {
		Vector2 screenPos = Input.mousePosition;
		Ray ray=Camera.main.ScreenPointToRay(new Vector3(screenPos.x, screenPos.y, 1f));
		float distance;
		if(!plane.Raycast(ray, out distance)) throw new UnityException("did not hit plane");
		return ray.GetPoint(distance);
	}
}
