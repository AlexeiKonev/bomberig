using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed=5;
    public Rigidbody2D rb;
  [SerializeField]  private FloatingJoystick joystick;
    private void Awake()
    {
        Scores.LifePlayer = 3;
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
         
            rb.velocity = new Vector2(moveSpeed * joystick.Horizontal, moveSpeed * joystick.Vertical);
        Flip();

    }
    void Flip()
    {
        if(  joystick.Horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(  joystick.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0,-180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Scores.LifePlayer--;
        }
    }
}
