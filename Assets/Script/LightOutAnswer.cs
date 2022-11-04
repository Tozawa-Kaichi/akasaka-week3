
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LightOutAnswer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int _row = 5;//行
    [SerializeField]
    int _column = 5;//列
    GameObject[,] _cells;
    int _clearCount = 0;
    int clearcheck = 0;
    private void Start()
    {
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = _column;
        clearcheck = _row * _column;
        _cells = new GameObject[_row, _column];
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                var image = cell.AddComponent<Image>();
                _cells[r, c] = cell;
                //image.color = Color.black;
            }
        }
    }
    

    void ClearCheck()
    {
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                if(_cells[r,c].GetComponent<Image>().color == Color.black)
                _clearCount++;
            }
        }
        if(_clearCount >= clearcheck)
        {
            Debug.Log("Clear");
        }
        _clearCount = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var cell = eventData.pointerCurrentRaycast.gameObject;
        ToggleColor(cell);

        // クリックされたセルが二次元配列上のどのセルなのか
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                if (cell == _cells[r, c])
                {
                    Debug.Log($"Clicked: {r},{c}");

                    if (r - 1 >= 0) { ToggleColor(_cells[r - 1, c]); }
                    if (r + 1 < _cells.GetLength(0)) { ToggleColor(_cells[r + 1, c]); }
                    if (c - 1 >= 0) { ToggleColor(_cells[r, c - 1]); }
                    if (c + 1 < _cells.GetLength(1)) { ToggleColor(_cells[r, c + 1]); }
                    break;
                }
            }
        }
        ClearCheck();
    }

    // 指定したセルの色を反転するメソッド
    private static void ToggleColor(GameObject cell)
    {
        var image = cell.GetComponent<Image>();
        // ベタに if-else で切り替え
        if (image.color == Color.white)
        {
            image.color = Color.black;
        }
        else { image.color = Color.white; }

        // 条件演算子（三項演算子）のパターン
        // image.color = (image.color == Color.white ? Color.black : Color.white);
    }
}