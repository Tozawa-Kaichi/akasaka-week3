using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LightsOut : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int _row = 5;//行
    [SerializeField]
    int _column = 5;//列
    GameObject[,] _cells;

    private int _selectedRow; // 選択行
    private int _selectedColumn; // 選択列
    private void Start()
    {
        _cells = new GameObject[_row, _column];
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = _column;


        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                _cells[r, c] = cell;
            }
        }
    }

    private void Update()
    {
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = _cells[r, c];
                var image = cell.GetComponent<Image>();
                
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var cell = eventData.pointerCurrentRaycast.gameObject;
        var image = cell.GetComponent<Image>();
        _selectedRow = int.Parse(cell.name);
        Debug.Log(_selectedRow);
        if(image.color == Color.black)//課題１：クリックしたセルの色を反転
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }
        //AroundChange();
    }
    public void AroundChange(int num)
    {

    }
}