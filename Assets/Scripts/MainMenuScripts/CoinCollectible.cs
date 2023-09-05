using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] private float CoinValue;
   
    public int points = 1;



    public void Collect()
    {
        FindObjectOfType<UiHandlerSiva>().CoinCollectible(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            Collect();
            FindObjectOfType<StarHandler>().starsAchieved();

        }
    }
}
