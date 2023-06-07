using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : AbsPellPower
{
    public int points = 10;

    public override void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }





}
