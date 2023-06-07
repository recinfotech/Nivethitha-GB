using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        /*if (currentHealth > 0)

        {
            Invunerability();
        }
        //else
        {
            if (!dead)
            {
                GetComponent<Pacman>().enabled = false;
                dead = true;
            }
        }*/
    }



    private void Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }



}