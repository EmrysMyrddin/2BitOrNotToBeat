using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public Sprite CableSprite;
	public bool isCable = false;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetIsCable(bool isCable) {
		spriteRenderer.sprite = isCable ? CableSprite : null;
		this.isCable = isCable;
	}

	public void SetIsCurrent(bool isPrevious) {
		spriteRenderer.material.color = isPrevious ? Color.blue : Color.white;
	}
}
