using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[13];
    public Dictionary<string, Sprite> cableSprites = new Dictionary<string, Sprite>();
    public bool isCable = false;
    public Vector2Int direction;

    private SpriteRenderer spriteRenderer;
	private string[] directions = new string[]{
		"None",
		"RightRight",
		"LeftLeft",
		"UpUp",
		"DownDown",
		"RightUp",
		"RightDown",
		"LeftUp",
		"LeftDown",
		"UpRight",
		"UpLeft",
		"DownRight",
		"DownLeft",
	};

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
		for(int i = 0; i < directions.Length ; i++) {
			cableSprites[directions[i]] = sprites[i];
		}
    }

    public void SetIsCable(bool isCable)
    {
        this.isCable = isCable;
        if (isCable)
        {
            spriteRenderer.sprite = cableSprites["None"];
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
        if (direction.x > 0) spriteRenderer.sprite = cableSprites["RightRight"];
        if (direction.x < 0) spriteRenderer.sprite = cableSprites["LeftLeft"];
        if (direction.y > 0) spriteRenderer.sprite = cableSprites["UpUp"];
        if (direction.y < 0) spriteRenderer.sprite = cableSprites["DownDown"];
    }

	public void UpdateDirection(Vector2Int nextDirection) {
		string spriteName = "";
		if (direction.x > 0) spriteName = "Right";
        else if (direction.x < 0) spriteName = "Left";
        else if (direction.y > 0) spriteName = "Up";
        else if (direction.y < 0) spriteName = "Down";

		if (nextDirection.x > 0) spriteName += "Right";
        else if (nextDirection.x < 0) spriteName += "Left";
        else if (nextDirection.y > 0) spriteName += "Up";
        else if (nextDirection.y < 0) spriteName += "Down";

		if(direction == Vector2Int.zero) spriteName += spriteName;

		Debug.Log(spriteName);

		spriteRenderer.sprite = cableSprites[spriteName];
	}
}
