using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    [SerializeField]
    private view view;


    private model model;

    private void Start()
    {
        view.Initialize();
        view.restartButton.onClick.AddListener(RestartGame);
        model = view.model;
    }

    void Update()
    {
        if (model.IsGameOver())
        {
            Debug.Log("Game over!");
            UpdateWinText();
        }
    }

    public void UpdateWinText()
    {
        if ((model.numMoves == 9) && !(model.CheckForWin()))
        {
            view.drawText.text = "Draw!";
            view.winText.text = "";
        }

        else if (model.CheckForWin())
        {
            view.winText.text = "Player " + model.GetCurrentPlayer() + " Wins!";
        }

        view.restartButtonHolder.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
