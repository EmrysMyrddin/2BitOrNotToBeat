using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour {
	public Sprite CableSprite;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetIsCable(bool isCable) {
		spriteRenderer.sprite = isCable ? CableSprite : null;
	}

	public void SetIsPrevious(bool isPrevious) {
		spriteRenderer.material.color = isPrevious ? Color.blue : Color.white;
	}
}
