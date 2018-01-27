using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPacket : MonoBehaviour {
	private Model model;
	private int lastTick = 0;
	private Vector2Int currentPos;
	private Vector2Int nextPos;
	// Use this for initialization
	void Start () {
		model = GameObject.Find("Game").GetComponent<Model>();
		currentPos =  Vector2Int.FloorToInt(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(lastTick != model.tick) {
			lastTick = model.tick;
			currentPos = nextPos;
			nextPos = currentPos + model.GetCell(currentPos).exitDirection;
		}

		transform.position = Vector2.Lerp(currentPos, nextPos, model.TickProgression());
	}
}
