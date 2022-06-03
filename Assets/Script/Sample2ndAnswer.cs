using UnityEngine;
using UnityEngine.UI;

public class Sample2ndAnswer : MonoBehaviour
{
    GameObject[,] _cells;//多次元配列
    int _selectedCollum;//行
    int _selectedRow;//列
    private void Start()
    {
        _cells = new GameObject[5,5];
        for (var r = 0; r < 5; r++)
        {
            for (var c = 0; c < 5; c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;

                var image = obj.AddComponent<Image>();
                if (r == 0 && c == 0) 
                { 
                    image.color = Color.red;
                }
                else 
                { 
                    image.color = Color.white;
                }
                _cells[r, c] = obj;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            _selectedCollum++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            _selectedCollum--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // 上キーを押した
        {
            _selectedRow++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) // 下キーを押した
        {
            _selectedRow--;
        }
        OnSelectedChanges();
    }
    void OnSelectedChanges()
    {
        for (var r = 0; r < 5; r++)
        {
            for (var c = 0; c < 5; c++)
            {
                var cell = _cells[r, c];
                var image = cell.GetComponent<Image>();
                if (r == _selectedRow && c == _selectedCollum)
                {
                    image.color = Color.red;
                }
                else 
                { 
                    image.color = Color.white; 
                }
            }
        }
    }
}