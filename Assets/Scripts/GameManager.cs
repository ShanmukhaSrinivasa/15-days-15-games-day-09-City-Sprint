using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score UI")]
    private int score = 0;
    private int highScore = 0;
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI highScoreCount;
    [SerializeField] private TextMeshProUGUI go_scoreCount;
    [SerializeField] private TextMeshProUGUI go_highScoreCount;

    [Header("CanvasGroups")]
    public CanvasGroup startGameCG;
    public CanvasGroup gameCG;
    public CanvasGroup gameOverCG;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 0;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreCount.text = highScore.ToString();
    }

    
    void Update()
    {
        
    }

    public void GameStart()
    {
        ShowCG(gameCG);
        HideCG(gameOverCG);
        HideCG(startGameCG);
        Time.timeScale = 1;
        PlayerController.instance.gameOver = false;
        InvokeRepeating("IncrementScore", 2f, 1f);
    }

    public void GameOver()
    {
        ShowCG(gameOverCG);
        HideCG(startGameCG);
        HideCG(gameCG);

        go_scoreCount.text = score.ToString();
        go_highScoreCount.text = highScore.ToString();
    }

    private void IncrementScore()
    {
        score++;
        scoreCount.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    public void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void PlayAgainButtonCallBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
