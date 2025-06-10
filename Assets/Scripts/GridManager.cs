using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [Header("Grid Setup")]
    public GameObject boxPrefab;
    public Transform gridParent;
    public Sprite coinSprite;
    public Sprite explosionSprite;

    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;
    public GameObject nextLevelPanel;
    public TMP_Text scoreText;
    public TMP_Text final_scoreText;

    private int level = 1;
    private int streak = 0;
    private int score = 0;
    private int bombsInGrid = 0;
    private int totalCoins = 0;
    private int foundCoins = 0;

    private bool isGamePaused = false;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        streak = 0;
        bombsInGrid = 0;
        totalCoins = 0;
        foundCoins = 0;
        isGameOver = false;

        //  box count formula
        int totalBoxes = Mathf.CeilToInt(5 * Mathf.Pow(level, 1.2f)); //  Used maths and general notation to have an expression about no of boxes 

        //  bomb probability
        float bombChance = Mathf.Min(0.3f + 0.05f * level, 0.6f); // no if wrong  button probability in an layer

        for (int i = 0; i < totalBoxes ;  i++)
        {
            GameObject boxObj = Instantiate(boxPrefab, gridParent);
            BoxController box = boxObj.GetComponent<BoxController>();

            bool isCoin = Random.value >= bombChance;
            if (!isCoin) bombsInGrid++; else totalCoins++;

            box.Setup(coinSprite, explosionSprite, isCoin);
            boxObj.GetComponent<Button>().onClick.AddListener(box.OnClick);
        }

        UpdateScoreUI();
    }

    public void OnBoxClicked(bool isCoin)
    {
        if (isGameOver) return;

        if (!isCoin)
        {
            isGameOver = true;
            StartCoroutine(DelayedGameOverUI());
            return;
        }

        streak++;
        foundCoins++;

        int gainedScore = CalculateScore(streak, level, bombsInGrid);
        score += gainedScore;

        UpdateScoreUI();

        if (foundCoins == totalCoins)
        {
            StartCoroutine(ShowWinAndNextLevel());
        }
    }

    int CalculateScore(int streak, int level, int bombs)
    {
        float difficultyScale = Mathf.Log(level + bombs + 2, 2); // log₂(level + bombs + 2) used this to have Normalization of the score 
        return Mathf.RoundToInt((streak * streak + 1) * difficultyScale);
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}\nLevel: {level}\nStreak: {streak}";
    }

    // UI CONTROL 
    public void PauseGame()
    {
        if (isGameOver) return;

        isGamePaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        level = 1;
        streak = 0;
        score = 0;
        gameOverPanel.SetActive(false);
        GenerateGrid();
    }

    void ShowGameOverUI()
    {
        Time.timeScale = 0f;
        final_scoreText.text = $"Score: {score}\nLevel: {level}\nStreak: {streak}";
        gameOverPanel.SetActive(true);
    }

    IEnumerator ShowWinAndNextLevel()
    {
        gameWonPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        gameWonPanel.SetActive(false);

        nextLevelPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        nextLevelPanel.SetActive(false);

        level++;
        GenerateGrid();
    }
    IEnumerator DelayedGameOverUI()
    {
        yield return new WaitForSecondsRealtime(2f);
        ShowGameOverUI();
    }
}
