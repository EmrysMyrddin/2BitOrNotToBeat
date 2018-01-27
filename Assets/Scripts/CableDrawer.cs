using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDrawer : MonoBehaviour
{
    private Model model;
    private Plane plane = new Plane(Vector3.back, Vector3.zero);
    private Vector2Int currentPos;
    private Stack<Vector2Int> currentPath = new Stack<Vector2Int>();

    // Use this for initialization
    void Start()
    {
        model = GetComponent<Model>();
    }

    void OnMouseDown()
    {
        Vector2Int mousePos = MousePosition();
        currentPos = mousePos;
        currentPath = new Stack<Vector2Int>();
        model.GetCell(mousePos).SetIsCable(true).SetIsCurrent(true);
    }

    void OnMouseUp() {
        model.GetCell(currentPos).SetIsCurrent(false);
    }

    void OnMouseDrag()
    {
        Vector2Int mousePos = MousePosition();
        if (mousePos.x >= Model.COLS || mousePos.y >= Model.ROWS || mousePos.x < 0 || mousePos.y < 0) return;

        // Calculate the distance from the current cell
        Vector2Int distance = mousePos - currentPos;

        // If the mouse has mooved to a new cell
        if (distance.magnitude == 1)
        {
            // Detect if we havec moved backward
            if (currentPath.Count > 0 && mousePos == currentPath.Peek())
            {
                CancelLastCable(mousePos, distance);
            }
            else if (!model.GetCell(mousePos).isCable)
            {
                CreateNewCable(mousePos, distance);
            }
        }
    }

    void CancelLastCable(Vector2Int mousePos, Vector2Int direction)
    {
        model.GetCell(currentPos).SetIsCable(false).SetIsCurrent(false);
        model.GetCell(mousePos).SetIsCurrent(true).RemoveDirection(direction);

        currentPath.Pop();
        currentPos = mousePos;
    }

    void CreateNewCable(Vector2Int mousePos, Vector2Int direction)
    {
        model.GetCell(mousePos).SetIsCable(true).SetDirection(direction).SetIsCurrent(true);
        model.GetCell(currentPos).AddDirection(direction).SetExitDirection(direction).SetIsCurrent(false);

        currentPath.Push(currentPos);
        currentPos = mousePos;
    }

    Vector3 RoundVector3(Vector3 vector)
    {
        return new Vector3(Mathf.Floor(vector.x), Mathf.Floor(vector.y), Mathf.Floor(vector.z));
    }

    Vector2Int MousePosition()
    {
        Vector2 screenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenPos.x, screenPos.y, 1f));
        float distance;
        if (!plane.Raycast(ray, out distance)) throw new UnityException("did not hit plane");
        return Vector2Int.FloorToInt(RoundVector3(ray.GetPoint(distance)));
    }
}
