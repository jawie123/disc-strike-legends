using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Score Display")]
    public Text playerScoreText;
    public Text aiScoreText;

    private int playerScore = 0;
    private int aiScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int points, CarromPuck.PuckType type)
    {
        playerScore += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (playerScoreText != null) playerScoreText.text = "You: " + playerScore;
        if (aiScoreText != null) aiScoreText.text = "AI: " + aiScore;
    }
}
