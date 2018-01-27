using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[13];
    public Dictionary<string, Sprite> cableSprites = new Dictionary<string, Sprite>();
    public bool isCable = false;
    public Vector2Int direction;

	private string spriteName;

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
		string spriteName = StringDirection(direction);
		spriteRenderer.sprite = cableSprites[spriteName + spriteName];
    }

	public string StringDirection(Vector2Int direction) {
		if (direction.x > 0) return "Right";
        else if (direction.x < 0) return "Left";
        else if (direction.y > 0) return "Up";
        else if (direction.y < 0) return "Down";
		return "";
	}

	public void UpdateDirection(Vector2Int nextDirection) {
		string spriteName = StringDirection(direction) + StringDirection(nextDirection);
		if(direction == Vector2Int.zero) spriteName += spriteName;

		Debug.Log(spriteName);

		spriteRenderer.sprite = cableSprites[spriteName];
	}
}
