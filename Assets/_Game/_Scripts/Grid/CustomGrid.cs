using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] Vector2 cellSize;
    [SerializeField] Vector2 originPosition;
    Vector2 mousePos;
    int[,] grid;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetMousePos(mousePos);
        }
    }

    void OnDrawGizmos()
    {
        if (gridSize.x <= 0 || gridSize.y <= 0) return;
        grid = new int[gridSize.x, gridSize.y];

        int xGridLength = gridSize.x;
        int yGridLength = gridSize.y;

        Vector2 offSet = new Vector2(-gridSize.x * 0.5f, -yGridLength * 0.5f);
        originPosition = (Vector2)Camera.main.transform.position + offSet;

        for (int x = 0; x < xGridLength; x++)
            for (int y = 0; y < yGridLength; y++)
            {
                Vector2 startPoint = new Vector2(x, y) * cellSize + originPosition;
                Vector2 endPoint = new Vector2(x, y + 1) * cellSize + originPosition;
                Vector2 endPoint2 = new Vector2(x + 1, y) * cellSize + originPosition;
                Gizmos.DrawLine(startPoint, endPoint);
                Gizmos.DrawLine(startPoint, endPoint2);
            }
        Gizmos.DrawLine(new Vector2(0, yGridLength) * cellSize + originPosition, new Vector2(xGridLength, yGridLength) * cellSize + originPosition);
        Gizmos.DrawLine(new Vector2(xGridLength, yGridLength) * cellSize + originPosition, new Vector2(xGridLength, 0) * cellSize + originPosition);
    }

    void PrintCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= gridSize.x || y >= gridSize.y) return;
        Debug.Log(x + " " + y);
    }

    void GetXYInScreen(Vector2 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPos - originPosition).x / cellSize.x);
        y = Mathf.FloorToInt((worldPos - originPosition).y / cellSize.y);
    }

    void GetMousePos(Vector2 worldPos)
    {
        int x, y;
        GetXYInScreen(worldPos, out x, out y);
        PrintCell(x, y);
    }
}


