using System.Collections.Generic;
using UnityEngine;

// 규칙
public class Single_BoardTicTacToe : MonoBehaviour
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;

    public int player;

    public Single_BoardTicTacToe()
    {
        player = 1;
        board = new int[ROWS, COLS];
    }

    // 갈 수 있는 칸 확인
    public List<Single_Move> GetMoves()
    {
        var moves = new List<Single_Move>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (board[i, j] == 0) // 빈 칸
                {
                    moves.Add(new Single_Move(i, j, player));
                }
            }
        }

        return moves;
    }

    // 해당 구간으로 이동
    public void MakeMove(Single_Move move)
    {
        if (board[move.y, move.x] != 0) // 칸이 찬 상태
            return;

        board[move.y, move.x] = move.player;

        this.player = (move.player) == 1 ? 2 : 1; // 현재 이동한 player가 1이라면 그 다음 플레이어는 2
    }

    // 0: 진행 중, 1: Player1 승리, 2: Player2 승리, 3: 무승부
    public int CheckWinner()
    {
        // 가로 확인
        for (int i = 0; i < ROWS; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }

        // 세로 확인
        for (int j = 0; j < COLS; j++)
        {
            if (board[0, j] != 0 && board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return board[0, j];
            }
        }

        // 대각선 확인 ( / )
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        // 대각선 확인 ( \ )
        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        // 무승부
        if (GetMoves().Count == 0)
            return 3;

        // 진행 중
        return 0;
    }

    public bool IsGameOver()
    {
        return CheckWinner() != 0;
    }

}
