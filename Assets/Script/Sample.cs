﻿using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    private GameObject[] _cells;
    private int _selectedIndex = 0;
    [SerializeField] uint _count = 0;
    private void Start()
    {
        _cells = new GameObject[_count];
        for (var i = 0; i < _cells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;
            obj.AddComponent<Image>();
            _cells[i] = obj;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {

            _selectedIndex--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            _selectedIndex++;
        }
        if (Input.GetButtonDown("Jump"))
        {
            var cell = _cells[_selectedIndex];
            Destroy(cell);
            //_cells[_selectedIndex].SetActive(false);
        }

        OnselectedChanged();
    }

    private void OnselectedChanged()
    {
        for (var i = 0; i < _count; i++)
        {
            var cell = _cells[i]; ;
            if (!cell) { continue; }

            var image = cell.GetComponent<Image>();

            if (i == _selectedIndex) { image.color = Color.red; }
            else { image.color = Color.white; }
        }
        if (_selectedIndex > _cells.Length - 1)
        {
            _selectedIndex = _cells.Length - 1;
        }
        else if (_selectedIndex < 0)
        {
            _selectedIndex = 0;
        }
    }
}