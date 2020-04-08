using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    Rigidbody2D rigi;
    float force = 7f;
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Touch");
            //rigi.AddForce(transform.up, ForceMode2D.Force);
            rigi.velocity = new Vector2(0, force);
        }
        if(rigi.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0,80,rigi.velocity.y/10));
        }
        else if (rigi.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, -80, -rigi.velocity.y / 10));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameObjectTag.LINE)
        {
            Debug.Log("gameOver");
        }
    }
}
