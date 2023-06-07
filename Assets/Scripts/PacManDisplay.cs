using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManDisplay : MonoBehaviour
{
    
    public PacManGame pacmanGame;
    public Text LevelNoText;
  
    


    public void Start()
    {
        //LevelNoText.text = pacmanGame.Levelname.ToString();
        Instantiate(pacmanGame.LevelData[1].gridprefab);
        Instantiate(pacmanGame.LevelData[1].pacmanprefab);

        for (int i = 0; i< pacmanGame.LevelData[1].ghostbase.Count; i++)

        {
            Instantiate(pacmanGame.LevelData[1].ghostbase[i]);
        }
       
        /*Instantiate(pacmanGame.pacmanprefab);
        Instantiate(pacmanGame.gridname);
        Instantiate(pacmanGame.ghost[0]);
        Instantiate(pacmanGame.ghost[1]);
        Instantiate(pacmanGame.ghost[2]);
        Instantiate(pacmanGame.ghost[3]);*/
        

        

    }
}