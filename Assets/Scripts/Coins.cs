using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coins : MonoBehaviour
{
    public int points = 1;

    public  void Eat()
    {
        FindObjectOfType<UIManager>().CoinCollectible(this);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            
            
            Eat();
            

        }


    }
}
