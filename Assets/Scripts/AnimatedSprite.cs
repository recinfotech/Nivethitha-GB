using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]


public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; } // this field will also be accesed by other scripts , hence private set
    public Sprite[] sprites; // to add sprites in the inspector window
    public float animationTime = 0.25f;
    public int animationframe { get; private set; } 
    public bool loop = true; //pacman has to loop for the whole game

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime); // (method , 0.25 f, repeat time for loop(0.25)
    }

    private void Advance()
    {
        if (!this.spriteRenderer.enabled)
        {
            return;
        }
        this.animationframe++; /* the animation frame to be increamented but it should not exceed the spritelength,
                               if exceeds animation frame has to start from 0 & it has to loop*/
        if (this.animationframe >= this.sprites.Length && this.loop)
        {
            this.animationframe = 0;
        }
        if (this.animationframe >= 0 && this.animationframe < this.sprites.Length)
            // the animation frame should be btwn 0 and sprites length(its shold not exceed the sprites count)
         //if yes, the sprites from sprite renderer will be taken & animation frame will be set*/
        {
            this.spriteRenderer.sprite = this.sprites[this.animationframe];
        }
    }

    public void Restart()
    {
        this.animationframe = -1;
        Advance();
    }


}




            

 

     
    


 






