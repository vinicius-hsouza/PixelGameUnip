﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  public float Speed;
  public float JumpForce;

  public bool isJumping;
  public bool doubleJumping;

  private Rigidbody2D rig;
  private Animator anim;
  // Start is called before the first frame update
  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
    Jump();
  }

  void Move()
  {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    transform.position += movement * Time.deltaTime * Speed;
    if (Input.GetAxis("Horizontal") > 0f)
    {
      anim.SetBool("walk", true);
      transform.eulerAngles = new Vector3(0, 0f, 0f);
    }
    if (Input.GetAxis("Horizontal") < 0f)
    {
      anim.SetBool("walk", true);
      transform.eulerAngles = new Vector3(0, 180f, 0f);
    }

    if (Input.GetAxis("Horizontal") == 0f)
    {
      anim.SetBool("walk", false);
    }
  }

  void Jump()
  {
    if (Input.GetButtonDown("Jump") && !isJumping)
    {
      if (!isJumping)
      {
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        doubleJumping = true;
        anim.SetBool("jump", true);
      }
      else
      {
        if (doubleJumping)
        {
          rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
          doubleJumping = false;
        }
      }
    }
  }

  void onCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.layer == 8)
    {
      isJumping = false;
      anim.SetBool("jump", false);
    }
  }
  void onCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.layer == 8)
    {
      isJumping = true;
    }
  }
}
