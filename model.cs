using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model
{
    private int[,] board;  // 2D array to represent the game board
    private int currentPlayer;  // 1 or 2 to represent the current player
    public int numMoves;  // number of moves made so far

    public model()
    {
        board = new int[3, 3];
        currentPlayer = 1;
        numMoves = 0;
    }

/*    public bool IsSquareOpen(int x, int y)
    {
        return board[x, y] == 0;
    }*/

    public bool MakeMove(int x, int y)
    {
        if (board[x, y] != 0)
        {
            return false;  // square is already occupied
        }

        board[x, y] = currentPlayer;
        numMoves++;

        // Check for a win
        bool hasWinner = CheckForWin();
        if (hasWinner)
        {
            Debug.Log("Player " + currentPlayer + " wins!");
        }

        // Switch to the next player
        else if (!hasWinner)
        {
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }

        return true;
    }

    public bool CheckForWin()
    {
        // Check rows and columns for a win
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                return true;  // row i is a win
            }
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;  // column i is a win
            }
        }

        // Check diagonals for a win
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;  // top-left to bottom-right diagonal is a win
        }
        if (board[2, 0] == currentPlayer && board[1, 1] == currentPlayer && board[0, 2] == currentPlayer)
        {
            return true;  // bottom-left to top-right diagonal is a win
        }

        // No win found
        return false;
    }

    public bool IsGameOver()
    {
        return numMoves == 9 || CheckForWin();
    }

    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public int GetSquareValue(int x, int y)
    {
        return board[x, y];
    }
}
