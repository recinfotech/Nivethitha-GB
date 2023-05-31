using UnityEngine;


public class PlayerPaddle : Paddle
{
    public Rigidbody2D ball;
    //public float speed = 200.0f;
    private Vector2 _direction;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
            //_rigidbody.AddForce(_direction * this.speed);
            //Debug.Log("hi");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
            // Debug.Log("hi1");
        }
        else
        {
            _direction = Vector2.zero;
            // Debug.Log("hi2");
            Debug.Log("SivaPriya");
        }
    }
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            //Debug.Log("hi3");
            _rigidbody.AddForce(_direction * this.speed);
        }
    }
}
