using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pacman", menuName = "ObjectPacman")]
public class PacManGame : ScriptableObject

{
    /*public new string Levelname;
    public Grid gridname;
    public GameObject pacmanprefab;
    

    public GameObject[] ghost;
    public GameManager gamemanager;
    public GameObject inside;
    public GameObject outside;




    void Start()
    {
     Debug.Log()
    }*/
    public List<LevelDetails> LevelData;

}

[System.Serializable] 
public class LevelDetails   
{
    public int LevelNo;
    public GameObject pacmanprefab;
    public Grid gridprefab;
    public List<GameObject> ghostbase;

    public void print()
    {
        Debug.Log(LevelNo + ".");
    }

}

