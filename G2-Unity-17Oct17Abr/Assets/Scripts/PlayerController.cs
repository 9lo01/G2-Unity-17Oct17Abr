using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsPet = false;
    [Header("PLAYER ATTRIBUTES")]
    public float MoveSpeed = 5f;
    [Header("PLAYER REFERENCES")]
    public Transform MovePoint;

    public float LimitArea = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Aplicamos el movimiento hacia la posicion deseada
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, MovePoint.position) <= LimitArea)
        {
            if (IsPet == false)
            {
                //Movimiento en horizontal definido por absolutos (+, -)
                if (Mathf.Abs(x) == 1f)
                {
                    MovePoint.position += new Vector3(x, 0f, 0f);
                }

                //Movimiento en vertical definido por absolutos (+, -)
                if (Mathf.Abs(y) == 1f)
                {
                    MovePoint.position += new Vector3(0f, y, 0f);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, LimitArea);

        Gizmos.color= Color.green;
        Gizmos.DrawLine(transform.position, MovePoint.position);
    }
}
