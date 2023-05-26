using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundinmotion : MonoBehaviour
{
    public GameObject quad;
    private Renderer rend;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        rend = quad.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;
    }
}
