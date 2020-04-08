using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoSingleton<MainPlayer>
{
    public Image imgCharacter;
    public Sprite redCha;
    public Sprite blueCha;
    public Sprite yellowCha;
    Rigidbody2D rigi;
    float force = 5f;

    bool movingBack = false;
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        LockMove(true);

        SetCharacter(StorageManager.GetBird());
    }

    public void LockMove(bool isLock)
    {
        if(isLock)
        {
            this.gameObject.transform.position = Vector3.zero;
            this.gameObject.transform.rotation = Quaternion.identity;
            if(rigi)
                rigi.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rigi.constraints = RigidbodyConstraints2D.FreezeRotation;// | RigidbodyConstraints2D.FreezePositionX;
        }
    }
    private void Update()
    {
        if (GameManager.Instance.Current_state == GameManager.GAMESTATE.PLAYING)
            Movement();
        else if (GameManager.Instance.Current_state == GameManager.GAMESTATE.END)
        {

        }
        else
        {
            //WaitForStartGame();
        }
    }

    public void WaitForStartGame()
    {
        Debug.Log("StartGame");
        LockMove(false);
        rigi.velocity = new Vector2(0, force);
        GameManager.Instance.Current_state = GameManager.GAMESTATE.PLAYING;
        movingBack = true;
    }

    internal void SetCharacter(StorageManager.BIRD character)
    {
        switch(character)
        {
            case StorageManager.BIRD.RED:
                imgCharacter.sprite = redCha;
                break;
            case StorageManager.BIRD.BLUE:
                imgCharacter.sprite = blueCha;
                break;
            case StorageManager.BIRD.YELLOW:
                imgCharacter.sprite = yellowCha;
                break;
        }
    }

    void Movement()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Touch");
            //rigi.AddForce(transform.up, ForceMode2D.Force);
            rigi.velocity = new Vector2(0, force);
        }
        if(movingBack)
        {
            Vector3 temPos = transform.position;
            temPos.x -= 0.03f;
            transform.position = temPos;
            if(transform.position.x <=-1f)
            {
                movingBack = false;
            }
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
            //Debug.Log("gameOver");
            GameManager.Instance.Current_state = GameManager.GAMESTATE.END;
        }
    }
}
