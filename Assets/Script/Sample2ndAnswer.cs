﻿using UnityEngine;
using UnityEngine.UI;

public class Sample2ndAnswer : MonoBehaviour
{
    [SerializeField]
    private int _rows = 5;

    [SerializeField]
    private int _columns = 5;

    private GameObject[,] _cells;
    private int _selectedRow; // 選択行
    private int _selectedColumn; // 選択列

    private void Start()
    {
        _cells = new GameObject[_rows, _columns];

        var layout = GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = _columns;

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;
                obj.AddComponent<Image>();
                _cells[r, c] = obj;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            if (_selectedColumn - 1 >= 0)
                _selectedColumn--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            if (_selectedColumn + 1 < _cells.GetLength(1))
                _selectedColumn++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // 上キーを押した
        {
            if (_selectedRow - 1 >= 0)
                _selectedRow--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) // 下キーを押した
        {
            if (_selectedRow + 1 < _cells.GetLength(0))
                _selectedRow++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cell = _cells[_selectedRow, _selectedColumn];
            var image = cell.GetComponent<Image>();
            // image.color = Color.clear; // 画像の色を透明に
            image.enabled = false; // Image コンポーネントを無効
        }

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = _cells[r, c];
                var image = cell.GetComponent<Image>();
                if (r == _selectedRow && c == _selectedColumn)
                {
                    image.color = Color.red;
                }
                else { image.color = Color.white; }
            }
        }
    }
}