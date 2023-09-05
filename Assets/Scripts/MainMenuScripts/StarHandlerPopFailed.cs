using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandlerPopFailed : MonoBehaviour
{
    public GameObject[] Stars;
    private int coinsCount;

    public void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;
        Debug.Log("star");
    }

    public void starsAchieved()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("coin").Length;
        int coinsCollected = coinsCount - coinsLeft;

        float Percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;
        if (Percentage >= 33f && Percentage < 66)
        {
            Stars[0].SetActive(true);
        }
        else if (Percentage >= 66 && Percentage < 90)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
        }
        else if (Percentage < 30)
        {
            Stars[0].SetActive(false);
            Stars[1].SetActive(false);
            Stars[2].SetActive(false);
        }
        else
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
            Stars[2].SetActive(true);
        }
    }
}
