using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetector : MonoBehaviour
{
    private BlueB bird;
        void Start()
    { 
        bird = GameObject.Find("Bird").GetComponent<BlueB>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D Other)
    {
        if(Other.gameObject.tag =="Player")
        {
            bird.UpdateScore();
        }
    }


}
