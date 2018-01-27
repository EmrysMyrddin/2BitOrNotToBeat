using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPacket : MonoBehaviour {
	public float speed = 1f;
	private Model model;

	// Use this for initialization
	void Start () {
		model = GameObject.Find("Game").GetComponent<Model>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
