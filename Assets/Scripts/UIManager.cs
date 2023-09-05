using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    public Text coinText;

    public int coinValue { get; private set; }

        
    public void SetCoins(int coins)
    {
        this.coinValue = coins;
        // scoreText.text = score.ToString().PadLeft(2, '0');
        coinText.text = coins.ToString().PadLeft(2, '0');
    }

    public void CoinCollectible(Coins coinCapture)
    {

        coinCapture.gameObject.SetActive(false);
        SetCoins(this.coinValue + coinCapture.points);
        // SoundManager.instance.PlaySound(coinCollectibleSound);

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PreviewScreen()
    {
        SceneManager.LoadScene(4);
    }


}
