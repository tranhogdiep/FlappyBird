using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    Rigidbody2D rigi;
    float force = 5f;
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        LockMove(true);
    }

    void Update()
    {

    }
    void LockMove(bool isLock)
    {
        if(isLock)
        {
            rigi.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rigi.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.Current_state == GameManager.GAMESTATE.PLAYING)
            Movement();
        else
        {
            WaitForStartGame();
        }
    }

    private void WaitForStartGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("StartGame");
            LockMove(false);
            rigi.velocity = new Vector2(0, force);
            GameManager.Instance.Current_state = GameManager.GAMESTATE.PLAYING;
        }
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
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0,60,rigi.velocity.y/2));
        }
        else if (rigi.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, -60, -rigi.velocity.y / 2));
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
