using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropGrid : MonoBehaviour
{
    [Header("Grid Custom")]
    [SerializeField] Vector2Int gridSize;
    [SerializeField] Vector2 cellSize;

    [Header("Cell Custom")]
    [SerializeField] GameObject cell;
    [SerializeField] Transform Holder;
    // Another value
    Vector2 originPosition;
    Camera cam;

    #region  ReferenceObject
    void Awake()
    {
        cam = Camera.main;
    }
    #endregion

    #region  InitializeData
    void Start()
    {
        if (gridSize.x < 0 || gridSize.y < 0 || cellSize.x == 0 || cellSize.y == 0)
        {
            Debug.LogError("Grid khong hop le");
            return;
        }
        InitValue();
        InitGrid(gridSize.x, gridSize.y);
    }

    void InitValue()
    {
        Vector2 offSet = new Vector2(-0.5f * cellSize.x * (gridSize.x - 1), -0.5f * cellSize.y * (gridSize.y - 1));
        originPosition = (Vector2)cam.transform.position + offSet;
    }

    void InitGrid(int xGridLength, int yGridLength)
    {
        for (int x = 0; x < xGridLength; x++)
            for (int y = 0; y < yGridLength; y++)
            {
                Vector2 center = new Vector2(x, y) * cellSize + originPosition;
                InitCell(center);
            }
    }

    void InitCell(Vector2 position)
    {
        GameObject obj = Instantiate(cell, position, Quaternion.identity, Holder);
        obj.transform.localScale = new Vector3(Mathf.Abs(cellSize.x), Mathf.Abs(cellSize.y), 1);
    }

    #endregion
    
    #region DrawGrid
    void OnDrawGizmos()
    {
        if (gridSize.x < 0 || gridSize.y < 0) return;
        int xGridLength = gridSize.x;
        int yGridLength = gridSize.y;

        Vector2 offSet = new Vector2(-0.5f * cellSize.x * (gridSize.x - 1), -0.5f * cellSize.y * (gridSize.y - 1));
        originPosition = (Vector2)Camera.main.transform.position + offSet;

        for (int x = 0; x < xGridLength; x++)
            for (int y = 0; y < yGridLength; y++)
            {
                Vector2 center = new Vector2(x, y) * cellSize + originPosition;
                Gizmos.DrawWireCube(center, cellSize);
            }
    }
    #endregion

}
