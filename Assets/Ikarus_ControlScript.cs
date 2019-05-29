using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikarus_ControlScript : MonoBehaviour
{
  // Variables ******************************************************************************************************
  // Unity Variables
  private Rigidbody2D body; // physics component defind by Unity

  // Animation for falling (when hitting pillar)
  // Animation for wingflap (at player input)

  // Script Variables
  // public in order to allow editing from within Unity

  private bool isPlayable = true;
  private bool jump = false;

  public float scrollForce; // This force defines how fast the player moves to the right -- note: camera should move at exact same speed, not sure how we will do this yet
  public float jumpForce;


  // Initialisers ***************************************************************************************************

  void Start()
  {
    // assign physics component
    body = GetComponent<Rigidbody2D>();
    // apply force on X to initiate constant movement to the right
    body.AddForce(new Vector2(scrollForce, 0), ForceMode2D.Impulse);
  }

  // Updates ********************************************************************************************************

  // Each Frame
  void Update()
  {
    if (Input.GetButtonDown("Jump"))
    {
      jump = true;
    }
  }

  // Each Physics Step
  void FixedUpdate()
  {
    // Jump on player control
    if (isPlayable == true)
    {
      if (jump == true)
      {
        body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jump = false;
      }
    }
  }

  // Collision
  void OnTriggerEnter2D(Collider2D collision)
  {
    // TODO only trigger if collision is with pillar
    isPlayable = false;
    // TODO play falling animation
    // TODO make collision feel "real" with screen shake, slowing down a little etc.
  }
}
