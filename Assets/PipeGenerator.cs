using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject Pipe;
    public Vector3 position;
    void Start()
    {
        StartCoroutine(GeneratePipes());
    }

  
    void Update()
    {
        
    }
    IEnumerator GeneratePipes()

    {
        while (true)
        {
            yield return new WaitforSeconds(4f);
            float randY = Random.Range(-3f, 1.5f);
            float randX = Random.Range(3f, 4f);
            position = new Vector3(3f, 1.5f, 0);
            Instantiate(Pipe, position, Quaternion.identity);
        }
        
    }


}

