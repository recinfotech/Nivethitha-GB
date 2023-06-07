using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    public Health health;
    public Healthbar healthbar;
    public Ghost[] ghosts;// create a fieldwith array  to access  Ghost class
    public Pacman pacman; // create a field to access from Pacman class
    public Transform pellets;// create a field to access position of pellets in Inspector window.
    public int ghostMultiplier { get; private set; } = 1;//create a field for getset property
    public int score { get; private set; } //create a field for getset property
    public int lives { get; private set; } //create a field for getset property

    public string SceneName;


    private void Start() // inorder to start a game 
    {
        NewGame();
    }

    private void Update()
    {
        /* if (this.lives <= 0 && Input.anyKeyDown) // setting condition  to start a new game
         {
             NewGame();
         }*/

        if (HasRemainingPellets() && (lives < 1))
        {
            Invoke(nameof(NewGame), 3f);

        }
       
       }

    private void NewGame() // calling the above fuction
    {
        SetScore(0); // setting initial parameters to start a new game
        SetLives(3);
        NewRound();
        
    }


    private void NewRound() // calling the above fuction
    {
        
        foreach (Transform pellet in this.pellets)// it indicates the position of each pellet(every pellet object) 
        {
            pellet.gameObject.SetActive(true); /*if all the pellets are eaten by pacman & when each & very pellet sets inactive after being eaten
                                               it resets the pellets back for a new round. */
        }
        ResetState();

    }

    private void ResetState()
    {
        ResetGhostMultiplier(); //like pellet ghost also gets reset  for a new round.

        for (int i = 0; i < this.ghosts.Length; i++) 
        {
            this.ghosts[i].ResetState(); // only we want  pacman & ghost to go for a reset state immediately when pacman dies & not the pellets
            this.pacman.ResetState();
        }
    }
        private void GameOver() //at this state all the gameobjects should be turned off.

            //if pacman is eaten & utilised all the 3lives then gameover to be called. refer pacman eaten & ghost eaten for gameover
        {
            for (int i = 0; i < this.ghosts.Length; i++)//use same code as used in reset state instead setactive true use setactive false.
            {
                this.ghosts[i].gameObject.SetActive(false);
            }
            this.pacman.gameObject.SetActive(false);
                
        }
        private void SetScore(int score)
        {
            this.score = score;
        }

        private void SetLives(int lives)
        {
            this.lives = lives;
        }

        public void GhostEaten(Ghost ghost) //this will be public functions as it will be triggered in other scripts.
        {
            int points = ghost.points * this.ghostMultiplier;
            SetScore(this.score + points);
            this.ghostMultiplier++; //if ghost is eaten by pacman the score gets increased & ghost gets multipied.
        }

        public void PacmanEaten() //this will be public functions as it will be triggered in other scripts.
        {
            this.pacman.gameObject.SetActive(false);// if pac man is eaten by ghost each life will be reduced by (-1).

            SetLives(this.lives -1);

            if (this.lives >= 0)// if pacman has morethan 0 lives reset state will be called
            {
                health.TakeDamage(1f);
                Invoke(nameof(ResetState), 3.0f); // he wants sometime to be fixed btwn pacman eaten & resetstate.
                                                  // hence calling Invoke in refering Resetstate & fixing timing.

            }
            else     // if no lives, call gameover
        {
                GameOver();
            }
        }

        public void PelletEaten(Pellet pellet)
        {
            pellet.gameObject.SetActive(false);//if pellet is eaten by pacman the eaten pellet becomes inactive and scores will be
                                               //generated for the same.
            SetScore(this.score + pellet.points);

            if (!HasRemainingPellets()) // if there is no remaining pellets
            {
                this.pacman.gameObject.SetActive(false); // if pacman eaten all the pellets ,it goes to new round.
                                                         //Invoke(nameof(NewRound), 3.0f);
             SceneManager.LoadScene(SceneName);

            }
        }

        public void PowerPelletEaten(PowerPellet pellet)
        {

            //To Do : Changing Ghost State
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                this.ghosts[i].frightened.Enable(pellet.duration);
            }
            PelletEaten(pellet);// after the powerpellet is eaten, ghost frightened will be enabled.
            CancelInvoke();
            Invoke(nameof(ResetGhostMultiplier), pellet.duration); //reset ghostmultiplier will be disabled during powerpellet eaten.

        }

        private bool HasRemainingPellets()
        {
            foreach (Transform pellet in this.pellets)// if the pellets are  active consider remaining pellets, (refer pellet eaten)
            {
                if (pellet.gameObject.activeSelf)
                {
                    return true;
                }
            }
            return false;
        }

        private void ResetGhostMultiplier()// refer resetstate & cancel invoke in powerpellet
        {
            this.ghostMultiplier = 1;
        }

}

 






     




 






      
            










    
     
   








    
   

        



