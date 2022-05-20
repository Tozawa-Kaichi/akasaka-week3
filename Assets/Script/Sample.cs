using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField]
    private int _count = 5;

    private GameObject[] _cells;
    private int _selectedIndex;

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
        OnSelectedChanged();
    }

    private void Update()
    {
        var V =
            (Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 0) +
            (Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0 );
        if ( V != 0 ) // 左キーを押した
        {
            _selectedIndex += V;
            OnSelectedChanged();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cell = _cells[_selectedIndex];
            Destroy(cell);
            OnSelectedChanged();
        }
        Normalized();
    }

    private void OnSelectedChanged()
    {
        for (var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i];
            if (!cell) { continue; }
            var image = cell.GetComponent<Image>();
            if (i == _selectedIndex)
            { 
                image.color = Color.red;
            }
            else
            { 
                image.color = Color.white;
            }
        }
    }
    void Normalized()
    {
        if (_selectedIndex < 0)
            _selectedIndex = 0;
        if (_selectedIndex > _cells.Length - 1)
            _selectedIndex = _cells.Length - 1;
        OnSelectedChanged();
    }
}