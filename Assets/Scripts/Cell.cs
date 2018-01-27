using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Sprite Cable, CableUp, CableDown, CableRight, CableLeft;
    public Dictionary<string, Sprite> CableSprites = new Dictionary<string, Sprite>();
    public bool isCable = false;
    public Vector2Int direction;

    private SpriteRenderer spriteRenderer;
	private string[] directions = new string[]{
		"Right",
		"Left",
		"Up",
		"Down",
		"UpRight",
		"UpLeft",
		"DownRight",
		"DownLeft",
	};

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetIsCable(bool isCable)
    {
        this.isCable = isCable;
        if (isCable)
        {
            spriteRenderer.sprite = Cable;
        }
        else
        {
            direction = Vector2Int.zero;
            spriteRenderer.sprite = null;
        }
    }

    public void SetIsCurrent(bool isPrevious)
    {
        spriteRenderer.material.color = isPrevious ? Color.grey : Color.white;
    }

    public void SetDirection(Vector2Int direction)
    {
        this.direction = direction;
        if (direction.x > 0) spriteRenderer.sprite = CableRight;
        if (direction.x < 0) spriteRenderer.sprite = CableLeft;
        if (direction.y > 0) spriteRenderer.sprite = CableUp;
        if (direction.y < 0) spriteRenderer.sprite = CableDown;
    }
}
