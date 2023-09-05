using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;
    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;
    }

    // Update is called once per frame
    public void StarsAchieved()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("coin").Length;
        int coinsCollected = coinsCount - coinsLeft;

        // float percentage = coinsCollected / coinsCount * 100f; 
        //percentage = Mathf.Round(percentage);
        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;
        Debug.Log(percentage + "%%");
        // print(percentage + "%");
        if (percentage >= 33 && percentage < 66)
        {
            //One Star
            stars[0].SetActive(true);
        }
        else if (percentage >= 66 && percentage < 70)
        {
            //two Stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (percentage < 30)
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
        else
        {
            //three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);

        }

    }

}
