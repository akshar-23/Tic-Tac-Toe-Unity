using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class view : MonoBehaviour
{
    public GameObject squarePrefab;
    public Transform boardParent;
    public GridLayoutGroup gridLayoutGroup;
    private GameObject[,] squares = new GameObject[3, 3];
    private GameObject square;

    private int row;
    private int col;


    public model model;

    public TextMeshProUGUI winText;

    public TextMeshProUGUI drawText;

    public Button restartButton;
    public GameObject restartButtonHolder;

    public void Initialize()
    {
        model = new model();

        winText.text = "";
        drawText.text = "";
        restartButtonHolder.SetActive(false);



        for (row = 0; row < 3; row++)
        {
            for (col = 0; col < 3; col++)
            {
                square = Instantiate(squarePrefab, boardParent);
                // Set the position of the square based on the row and column
                square.transform.localPosition = new Vector3(col * gridLayoutGroup.cellSize.x, -row * gridLayoutGroup.cellSize.y, 0f);
                squares[row, col] = square;

                // Add button click listener
                Button button = square.GetComponent<Button>();
                int _x = row;
                int _y = col;
                button.onClick.AddListener(() => OnButtonClick(_x, _y));

            }
        }
    }

    private void OnButtonClick(int x, int y)
    {
        if (!model.IsGameOver())
        {
            model.MakeMove(x, y);
            UpdateBoard();
        }
    }

    private void UpdateBoard()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                int player = model.GetSquareValue(x, y);
                TextMeshProUGUI text = squares[x, y].GetComponentInChildren<TextMeshProUGUI>();
                if (player == 1)
                {
                    text.text = "X";
                }
                else if (player == 2)
                {
                    text.text = "O";
                }
                else
                {
                    text.text = "";
                }
            }
        }
    }

    

}
