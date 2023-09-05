using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandlerSiva : MonoBehaviour
{
    public TextMeshProUGUI completedCoinTextPop;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI FailedCoinTextPop;

    //[Header("Game Over")]
    //[SerializeField] private GameObject gameOverScreen;
    //[SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    //[SerializeField] public GameObject completedPopUp;
    //[SerializeField] public GameObject failedPopUp;
    public int coinScore { get; private set; }

    public static UIManager Instance;

    private void Awake()
    {
      //  gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    public void SetCoinScore(int coinScore)
    {
        this.coinScore = coinScore;
        // scoreText.text = score.ToString().PadLeft(2, '0');
        completedCoinTextPop.text = coinScore.ToString().PadLeft(2, '0');
        FailedCoinTextPop.text = coinScore.ToString().PadLeft(2, '0');
        CoinText.text = coinScore.ToString().PadLeft(2, '0');
    }

    public void CoinCollectible(CoinCollectible coin)
    {

        coin.gameObject.SetActive(false);
        SetCoinScore(this.coinScore + coin.points);
        // SoundManager.instance.PlaySound(coinCollectibleSound);

    }

    //public void GameOver()
    //{
    //    gameOverScreen.SetActive(true);
    //    SoundManager.instance.PlaySound(gameOverSound);
    //}

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);//status == true - pause,status == false - Unpause

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    //public void ShowLevelCompletedDialog()
    //{
    //    GetComponent<StarHandler>().starsAchieved();
    //    completedPopUp.SetActive(true);
    //}

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
