using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Estructura de una variable -> tipo + nombre + asgnacion (=) + valor asignado + ;


public class Ball : MonoBehaviour
{
  /// <summary>
  /// This function (<c> RB </c>) calls the Rigidbody2D function to be saved in it.
  /// </summary>
  private Rigidbody2D RB;

  /// <summary>
  /// This varible saves the initial velocity for the ball.
  /// </summary>
  private float initVelocity = 4f;

  /// <summary>
  /// this variable will be used to accelerate the ball's speed through time.
  /// </summary>
  public float MultiplyVelocity = 1.1f;

  // Start is called before the first frame update
  void Start()
  {
    // at the begining of the game, this function will call the Rigidbody2D
    RB = GetComponent<Rigidbody2D>();

    // also at the begining, this function will be called.
    Launch();
  }

  // Update is called once per frame
  void Update()
  {

  }

    /// <summary>
    /// this function determines where and how the ball will be randomly launch.
    /// </summary>
    void Launch()
  {
    // this variables will save the value that will come from the function Range within the Random class
    // in this case the range will be between 0, 1 or 2, if the result is 0 the condition will be true
    // but if the result is 1 the condition will be false.
    float x = Random.Range(0, 2) == 0 ? -1 : 1; // 0 = -1, 1 o 2 = 1;
    float y = Random.Range(0, 2) == 0 ? -1 : 1; // 0 = -1, 1 o 2 = 1;

    // the velocity method within RB class will be equal to a new instance of the Vector2 function
    // multiplied by the global variable Init velocity.
    RB.velocity = new Vector2(x, y) * initVelocity;
  }
    /// <summary>
    /// This function does:
    ///     <list>
    ///         <code>
    ///         - Compares tags so it can determine the collision with one side or another.
    ///         </code>
    ///         <code>
    ///         - It adds value to one player's score or another
    ///         </code>
    ///         <code>
    ///         - Finally it resets the positon of the ball when it collides with either left or right wall.
    ///         </code>
    ///     </list>
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("LeftKillWall") || collision.CompareTag("RightKillWall"))
    {
      if (collision.CompareTag("LeftKillWall"))
      {
        LevelManager.instance.P2Score += 1;
      }
      if (collision.CompareTag("RightKillWall"))
      {
        LevelManager.instance.P1Score += 1;
      }

      LevelManager.instance.UpdateScore();
      RB.velocity = new Vector2(0, 0); // Reset Velocity to 0
      transform.position = new Vector3(0, 0, 0); // Align ball in the middle of the screen
      Launch();
    }
  }

}
