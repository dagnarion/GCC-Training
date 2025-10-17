using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class GridForFill : MonoBehaviour
{
    [Header("Grid Custom")]
    [SerializeField] Vector2Int gridSize;
    [SerializeField] Vector2 cellSize;

    [Header("Cell Custom")]
    [SerializeField] Transform cells;
    [SerializeField] Transform Holder;
    Dictionary<string, GameObject> cellType = new Dictionary<string, GameObject>();
    enum TypeOfCell
    {
        RedCell, YellowCell, GreenCell
    }
    TypeOfCell currentCell = TypeOfCell.RedCell;

    // Another value
    Dictionary<(int x, int y), Vector2> Grid;
    bool[,] Cell;
    Vector2 cellOffSet;
    Vector2 originPosition;
    Camera cam;

    #region  ReferenceObject
    void Awake()
    {
        cam = Camera.main;
        GetCell();
    }

    void GetCell()
    {
        for (int i = 0; i < cells.childCount; i++)
        {
            GameObject cell = cells.GetChild(i).gameObject;
            if (!cellType.ContainsKey(cell.name))
            {
                cellType[cell.name] = cell;
            }
        }
    }
    #endregion

    #region  InitializeData
    void Start()
    {
        if (gridSize.x < 0 || gridSize.y < 0)
        {
            Debug.LogError("Grid khong hop le");
            return;
        }
        InitValue();
        InitGrid(gridSize.x, gridSize.y);
    }

    void InitValue()
    {
        Grid = new Dictionary<(int x, int y), Vector2>();
        Cell = new bool[gridSize.x, gridSize.y];

        Vector2 offSet = new Vector2(-0.5f * cellSize.x * (gridSize.x - 1), -0.5f * cellSize.y * (gridSize.y - 1));
        originPosition = (Vector2)cam.transform.position + offSet;

        cellOffSet = 0.5f * cellSize;
    }

    void InitGrid(int xGridLength, int yGridLength)
    {
        for (int x = 0; x < xGridLength; x++)
            for (int y = 0; y < yGridLength; y++)
            {
                Vector2 center = new Vector2(x, y) * cellSize + originPosition;
                if (!Grid.ContainsKey((x, y)))
                {
                    Grid[(x, y)] = center;
                }
            }
    }

    #endregion

    #region  FillCell
    void Update()
    {
        SwitchCell();
        FillCell();
    }

    void SwitchCell()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentCell = TypeOfCell.RedCell;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentCell = TypeOfCell.YellowCell;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentCell = TypeOfCell.GreenCell;
    }

    void FillCell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            GetMousePos(mousePos);
        }
    }

    void GetMousePos(Vector2 worldPos)
    {
        int x, y;
        GetXYInScreen(worldPos, out x, out y);
        InitCell(x, y);
    }

    void GetXYInScreen(Vector2 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt(((worldPos - originPosition).x + cellOffSet.x) / cellSize.x);
        y = Mathf.FloorToInt(((worldPos - originPosition).y + cellOffSet.y) / cellSize.y);
    }

    void InitCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= gridSize.x || y >= gridSize.y || Cell[x, y]) return;
        Cell[x, y] = true;
        InitCell(cellType[currentCell.ToString()], Grid[(x, y)]);
    }

    void InitCell(GameObject prefab, Vector2 position)
    {
        GameObject tmp = Instantiate(prefab, position, Quaternion.identity, Holder);
        tmp.transform.localScale = new Vector3(cellSize.x, cellSize.y, 1);
        tmp.SetActive(true);
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
// code chưa tối ưu đoạn lấy nạp loại cell vào (dùng string khá nguy hiểm)
// đoạn vẽ và tạo grid đang vi phạm DRY
// Grid đang đảm nhận hơi nhiều việc
// Ấn phím 1 2 3 để đổi màu tô cell