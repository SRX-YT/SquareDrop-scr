using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] ColorManager colorManager;
    [SerializeField] SoundManager soundManager;

    [SerializeField] GameObject level;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject enemyManager;

    private GameObject player;
    private int flipMod = 1;
    private int score = 0;
    private int scoreRecord = 0;
    private int scoreForColor = 0;
    private float speed = 3.6f;

    [SerializeField] bool isRestartScene;

    private void Start()
    {
        player = GameObject.Find("Player");
        Init();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Init()
    {
        scoreRecord = PlayerPrefs.GetInt("scoreRecord");
        Application.targetFrameRate = -1;
        uiManager.SetScore(score, scoreRecord);
        if (isRestartScene)
        {
            level.transform.DOScale(Vector3.one, 0.5f);
        } else if (!isRestartScene || menuPanel != null)
        {
            menuPanel.transform.DOScale(Vector3.one, 0.5f);
        }
    }

    private void Move()
    {
        if (player != null)
        {
            player.transform.position += new Vector3(flipMod * speed * Time.fixedDeltaTime, 0);
        }
    }

    public void Flip()
    {
        flipMod *= -1;
    }

    public void GetPoint()
    {
        score += 1;
        if (scoreRecord < score)
        {
            scoreRecord = score;
            PlayerPrefs.SetInt("scoreRecord", scoreRecord);
        }
        uiManager.SetScore(score, scoreRecord);
        WaitForChangeColor(1);
        soundManager.PlayPick();
    }

    public void GameOver()
    {
        soundManager.PlayDestroy();
        level.transform.DOScale(Vector3.zero, 0.5f);
        restartPanel.SetActive(true);
        enemyManager.SetActive(false);
    }

    private void WaitForChangeColor(int value)
    {
        scoreForColor += value;
        if (scoreForColor >= 5)
        {
            colorManager.NextColor();
            soundManager.PlayChanged();
            scoreForColor = 0;
        }
    }
}
