using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMpro;
public class GameManager : MonoBehaviour
{
    public Ball ball;
    //public Ball ball;
    // private Ball ball;
    public Paddle playerPaddle;
    //private Paddle playerPaddle;
    public Paddle ComputerPaddle;
    public Text playerScoreText;
    public Text computerScoreText;
    private int _playerScore;
    private int _ComputerScore;

    public void PlayerScores()
    {
        _playerScore++;
        //TextMeshProUGUI playerScoreText = this.playerScoreText.GetComponent<TextMeshProUGUI>();
        this.playerScoreText.text = _playerScore.ToString();
        //PlayerScoreText.text = this._playerScore.ToString();
        ResetRound();
    }

    public void ComputerScores()
    {
        _ComputerScore++;
        //TextMeshProUGUI computerScoreText = this.computerScoreText.GetComponent<TextMeshProUGUI>();
        this.computerScoreText.text = _ComputerScore.ToString();
        //ComputerScoreText.text = this._computerScore.ToString();
        ResetRound();
    }
    
    private void ResetRound()
    {
        this.playerPaddle.ResetPosition();
        this.ComputerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }








}
