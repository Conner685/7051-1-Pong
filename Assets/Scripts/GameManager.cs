using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI p1ScoreText;
    [SerializeField] private TextMeshProUGUI p2ScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    [SerializeField] private PaddleController paddleController;
    [SerializeField] private AIController aiController;

    [SerializeField] private int winningScore;

    private int p1Score;
    private int p2Score;
    private bool isGameOver;

    void Start()
    {
        bool playAgainstAI = PlayerPrefs.GetInt("PlayAgainstAI") == 1;

        Debug.Log(playAgainstAI);
        
        if (playAgainstAI)
        {
            paddleController.enabled = false;
            aiController.enabled = true;
        }
        else
        {
            paddleController.enabled = true;
            aiController.enabled = false;
        }
        
        UpdateScoreUI();
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        
        Time.timeScale = 1f;
    }

    void UpdateScoreUI()
    {
        if (p1ScoreText != null)
        {
            p1ScoreText.text = "P1: " + p1Score;
        }

        if (p2ScoreText != null)
        {
            p2ScoreText.text = "P2: " + p2Score;
        }
    }

    public void Player1Scored()
    {
        if (isGameOver) return;
        p1Score++;
        UpdateScoreUI();
        CheckWinCondition();
    }
    public void Player2Scored()
    {
        if (isGameOver) return;
        p2Score++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (p1Score >= winningScore)
        {
            EndGame("Player 1 Wins!");
        }
        else if (p2Score >= winningScore)
        {
            EndGame("Player 2 Wins!");
        }
    }

    private void EndGame(string winMessage)
    {
        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.text = winMessage;
            gameOverText.gameObject.SetActive(true);
        }
        
        Time.timeScale = 0f;
    }

}
