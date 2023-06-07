using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Movement))]

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }


    float horizontalInput;
    float verticalInput;
    public Joystick joystick;






    // Update is called once per frame

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        /*horizontalInput = Input.GetAxisRaw("Horizontal");

        // horizontalInput = joystick.Horizontal;

        if ((horizontalInput > 0.01f) || (joystick.Horizontal >= 0.2f))
        {
            this.movement.SetDirection(new Vector3(1, 0, 0));
        }
        else if ((horizontalInput < -0.01f) || (joystick.Horizontal <= -0.2f))
        {
            this.movement.SetDirection(new Vector3(-1, 0, 0));
        }

        verticalInput = Input.GetAxisRaw("Vertical");
        // verticalInput = joystick.Vertical;

        if ((verticalInput > 0.01f) || (joystick.Vertical >= 0.2f))
        {
            this.movement.SetDirection(new Vector3(0, 1, 0));
        }
        else if ((verticalInput < -0.01f) || (joystick.Vertical <= -0.2f))
        {
            this.movement.SetDirection(new Vector3(0, -1, 0));
        }*/

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
        }
    
/*#elif UNITY_ANDROID || UNITY_IOS

                        if(Input.touches.Length>0)
                        {
                            Touch touch = Input.GetTouch(0);
                            switch (touch.phase)
                            {
                                case TouchPhase.Began:
                                    break;
                                case TouchPhase.Moved:
                                    if (touch.position.x > Screen.width / 2)
                                    {
                                        movement.SetDirection(Vector2.left);
                                    }
                                    else
                                    {
                                        movement.SetDirection(Vector2.right);
                                    }

                                    break;
                                case TouchPhase.Stationary: 
                                    break;
                                case TouchPhase.Ended:
                                    break;
                                case TouchPhase.Canceled:
                                    break;
                                default:
                                    break;


                            }

                        }*/


                #endif
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }
    


}
