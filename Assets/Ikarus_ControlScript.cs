using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikarus_ControlScript : MonoBehaviour {
  // Variables ******************************************************************************************************
  // Unity Variables
  private Rigidbody2D body; // physics component defind by Unity

  // Animation for falling (when hitting pillar)
  // Animation for wingflap (at player input)

  // Script Variables
  // public in order to allow editing from within Unity

  private bool isPlayable = true;
  private bool jump = false;
  private float scrollForce;

  public float defaultScrollForce; // This force defines how fast the player moves to the right -- note: camera should move at exact same speed, not sure how we will do this yet
  public float jumpForce;
  public float jumpScale;


  // Initialisers ***************************************************************************************************

  void Start() {
    // assign physics component
    body = GetComponent<Rigidbody2D>();
    // apply force on X to initiate constant movement to the right
    // body.AddForce(new Vector2(scrollForce, 0), ForceMode2D.Impulse);
    //
    if (defaultScrollForce == 0) {
      defaultScrollForce = 1;
    }
    scrollForce = defaultScrollForce;
  }

  // Updates ********************************************************************************************************

  // Each Frame
  void Update() {
    if (Input.GetButtonDown("Jump")) {
      jump = true;
    }
  }

  // Each Physics Step
  void FixedUpdate() {
    // Jump on player control
    if (isPlayable == true) {
      if (jump == true) {
        //body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        body.AddForce(new Vector2(0, -1 * jumpScale * Physics2D.gravity.y * body.gravityScale), ForceMode2D.Impulse);
        jump = false;
      }
    }
    body.AddForce(new Vector2(scrollForce * Time.deltaTime, 0), ForceMode2D.Force);
  }

  // Collision
  void OnTriggerEnter2D(Collider2D collision) {
    // TODO only trigger if collision is with pillar
    isPlayable = false;
    // TODO play falling animation
    // TODO make collision feel "real" with screen shake, slowing down a little etc.
    scrollForce = (float) 0.8 * defaultScrollForce;
  }
}
