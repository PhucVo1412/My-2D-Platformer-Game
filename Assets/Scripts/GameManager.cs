using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;

    private bool isGameOver = false;
    private bool isGameWin = false;
    void Start()
    {
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            updateScore();
        }

    }
    public void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        updateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
