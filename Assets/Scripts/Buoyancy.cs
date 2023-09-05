using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Buoyancy : MonoBehaviour
{
    public Transform[] floaters;
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 6f;
    public Rigidbody2D rigidbody;
    public bool underwater;
    public int floatersUnderWater;
    public GameObject target;
    //public Health health;
    public int _damage;
    public Animator anim;

    private void Start()
    {
       
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        floatersUnderWater = 0;
        for (int i = 0; i < floaters.Length; i++)
        {

            float difference = floaters[i].position.y - waterHeight;

            if (difference < 0)
            {

                rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference),
                    floaters[i].position, ForceMode2D.Force);
                floatersUnderWater += 1;
                if (!underwater)
                {

                    underwater = true;
                    SwitchState(true);
                }
            }
        }
        if (underwater && floatersUnderWater == 0)
        {

            underwater = false;
            SwitchState(false);
        }


    }
    private void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            Debug.Log("playeranim6");
            rigidbody.drag = underWaterDrag;
            rigidbody.angularDrag = underWaterAngularDrag;

        }
        else
        {
            Debug.Log("playeranim7");
            rigidbody.drag = airDrag;
            rigidbody.angularDrag = airAngularDrag;
        }

    }
    
}