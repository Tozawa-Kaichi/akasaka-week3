using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    private GameObject[] _cells;
    private int _selectedIndex = 0;

    private void Start()
    {
        _cells = new GameObject[5];
        for (var i = 0; i < 5; i++)
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

        for (var i = 0; i < 5; i++)
        {
            var cell = _cells[i]; ;
            var image = cell.GetComponent<Image>();

            if (i == _selectedIndex) { image.color = Color.red; }
            else { image.color = Color.white; }
        }
        if(_selectedIndex>4)
        {
            _selectedIndex = 4;
        }
        else if(_selectedIndex<0)
        {
            _selectedIndex = 0;
        }
    }
}