using UnityEngine;

public class Board : MonoBehaviour {
    public bool createBoard;

    public bool letteredColums;
    public bool letteredRows;

    public Column column;
    public Cell cell;

    public int numberOfColumns;
    public int numberOfRows;

    private float currentMin;
    private float currentMax;

    [Range(0.0f, 1.0f)]
    public float cellWidth;
    [Range(0.0f, 1.0f)]
    public float cellHeight;

    private float increment;
    void Start () {
        if (!createBoard) return;
        currentMin = 0.0f;
        currentMax = 1.0f / numberOfColumns;
        increment = currentMax;

        int i;
        for (i = 0; i < numberOfColumns; i++) {
            InstatiateColumn(i);
            currentMin += increment;
            currentMax += increment;
        }
    }

    void InstatiateColumn(int i) {
        Column newColum = Instantiate(column, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        RectTransform newCellRectTransform = newColum.gameObject.GetComponent<RectTransform>();
        //newColum.name = i.ToString();


        //set rectransform to zero
        newCellRectTransform.offsetMax = new Vector2(0, 0);
        newCellRectTransform.offsetMin = new Vector2(0, 0);

        //set anchors
        newCellRectTransform.anchorMin = new Vector2(currentMin, 0 );
        newCellRectTransform.anchorMax = new Vector2(currentMax , 1 );

        newColum.CreateColumn(cell, numberOfRows, cellWidth, cellHeight,letteredRows);
        newColum.name = letteredColums ? NumToChar(i) : ""+i;
    }


    public string NumToChar(int num) {
        string str = "";
        int originalNum = num;
        while (num / 26 != 0) {
            str += (char)((num / 26) + 64);
            num /= 26;
        }
        str += (char)((originalNum % 26) + 65);
        return str;
    }
}
