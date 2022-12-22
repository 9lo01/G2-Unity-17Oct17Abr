using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class (<c> PlayerController </c>) allow us to control the player.
/// It also has the special feature of having a circle pet (simple AI).
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// This variable (<c> IsPet </c>) will allow the circle to move.
    /// Whenever the  boolean 
    /// condition be true.
    /// </summary>
    public bool IsPet = false;

    /// <summary>
    /// This variable (<c> MoveSpeed </c>) will determine the speed of
    /// the movement.
    /// </summary>
    public float MoveSpeed = 5f;

    /// <summary>
    /// This variable (<c> MovePoint </c>) is the point that will guide
    /// the player' movement.
    /// </summary>
    public Transform MovePoint;

    /// <summary>
    /// (<c> LimitArea is in charge of setting a range between the original
    /// position and the target </c>)
    /// </summary>
    public float LimitArea = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // Here we are indicating that at the begining of the game
        // the MovePoint's parent (the "Player" GameObject) will exist but
        // won't have any value
        MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Here we are calling the "Move" function once per second.
        Move();
    }

    /// <summary>
    /// This method is in charge of the movement of the object. 
    /// <example>
    /// For Example:
    /// <code>
    ///     The transformed position will be equal to the Vector3's MoveTowards function
    ///     (which contains: the transformed position with the tarjet position with the
    ///     speed multiplied by the time)
    /// </code>
    /// It will return a new position.
    /// </example>
    /// 
    /// 
    /// <list type="Enemy">
    /// <item>
    /// <description>
    /// Item1.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Item2.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    void Move()
    {
        // This variable contains the function that will call the "Horizontal" input.
        float x = Input.GetAxisRaw("Horizontal");
        // This variable contains the function that will call the "Vertical" input.
        float y = Input.GetAxisRaw("Vertical");

        // we move to the desired position
        // se leería como:
        // la posición transformada será igual a la función "MoveTowards" del Vector3
        // (la cual contiene: la posición transformada con la posición objetivo (MovePoint), con la velocidad multiplicado por el tiempo).
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, MoveSpeed * Time.deltaTime);

        /// Aquí tenemos una codición, la cual se leería:
        /// si la función Distance del Vector3 (la cual contiene: la posición transformada con la posición objetivo) es menos o igual que LimitArea
        /// (variable pública ya declara antes)
        if (Vector3.Distance(transform.position, MovePoint.position) <= LimitArea)
        {
            // si la variable IsPet es igual a falso
            if (IsPet == false)
            {
                // si el movimiento en horizontal es definido por absolutos (+, -) y es igual a 1f
                if (Mathf.Abs(x) == 1f)
                {
                    // entoces a la posición del MovePoint hay que sumarle una nuevo Vector3, cuyo valor sera: (la variable x de los absolutos, 0f y 0f)
                    MovePoint.position += new Vector3(x, 0f, 0f);
                }

                //si el movimiento en vertical es definido por absolutos (+, -) y es igual a 1f
                if (Mathf.Abs(y) == 1f)
                {
                    //entonces a la posicion del MovePoint hay que sumarle un nuevo Vector3, cuyo valor sera: (la variable y de los absolutos, 0f y 0f)
                    MovePoint.position += new Vector3(0f, y, 0f);
                }
            }
        }
    }
    // esta siguiente función es solo un ejemplo
    /// <summary>
    /// This is an example.
    /// </summary>
    /// <param name="health"> This parameter is in charge of giving anew value for
    /// the health.
    /// </param>
    public void SetHealth(int health)
    {

    }

    /// <summary>
    /// This method (<c> OnDrawGizmosSeleted </c>) is used to show a green line between objects
    /// so we can see how they pet follows the player and this follows the MovePoint.
    /// Also there's a green circle in the center of LimitArea.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, LimitArea);

        Gizmos.color= Color.green;
        Gizmos.DrawLine(transform.position, MovePoint.position);
    }
}
