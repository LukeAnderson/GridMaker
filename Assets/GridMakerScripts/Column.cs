using UnityEngine;

public class Column : MonoBehaviour {

    private float currentMin;
    private float currentMax;
    private float increment;

    public void CreateColumn(Cell cell, int numberOfRows, float paddingCellWidth, float paddingCellHeight,bool letteredRows) {
        currentMin = 0.0f;
        currentMax = 1.0f / numberOfRows;
        increment = currentMax;

        int i;
        for (i = 0; i < numberOfRows; i++) {
            InstantiateCell(i,cell,paddingCellWidth,paddingCellHeight, letteredRows);
            currentMin += increment;
            currentMax += increment;
        }
    }


    void InstantiateCell(int i,Cell cell,float paddingCellWidth,float paddingCellHeight, bool letteredRows) {
        Cell newCell = Instantiate(cell, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        RectTransform newCellRectTransform = newCell.gameObject.GetComponent<RectTransform>();
        newCell.name = letteredRows ? gameObject.GetComponentInParent<Board>().NumToChar(i) : i.ToString();

        //set rectransform to zero
        newCellRectTransform.offsetMax = new Vector2(0, 0);
        newCellRectTransform.offsetMin = new Vector2(0, 0);

        //set anchors
        float paddingWidthValue = (1 - paddingCellWidth) /2;

        float incrementPercent = increment * paddingCellHeight;
        float paddingHeightValue = (increment - incrementPercent) / 2;
        newCellRectTransform.anchorMin = new Vector2(0 + paddingWidthValue, currentMin + paddingHeightValue);
        newCellRectTransform.anchorMax = new Vector2(1 - paddingWidthValue, currentMax - paddingHeightValue);
    }
}
