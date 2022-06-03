using UnityEngine;
using UnityEngine.UI;

public class SecondSample : MonoBehaviour
{
    private GameObject[,] _cells;
    private int _selectedIndex;
    [SerializeField] private int _count = 5;
    private void Start()
    {
        for (var r = 0; r < 5; r++)
        {
            for (var c = 0; c < 5; c++)
            {
                _cells = new GameObject[_count,_count];
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;
                var image = obj.AddComponent<Image>();
                if (r == 0 && c == 0) { image.color = Color.red; }
                else { image.color = Color.white; }
                _cells[c,r] = obj;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            _selectedIndex -= 1;
            OnSelectedChanged();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            _selectedIndex += 1;
            OnSelectedChanged();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // 上キーを押した
        {
            _selectedIndex -= 5;
            OnSelectedChanged();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) // 下キーを押した
        {
            _selectedIndex += 5;
            OnSelectedChanged();
        }
        Normalized();
    }
    private void OnSelectedChanged()
    {
        for (var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i,i];
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