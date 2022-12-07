using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PLAYER ATTRIBUTES")]
    public float MoveSpeed = 5f;
    [Header("PLAYER REFERENCES")]
    public Transform MovePoint;

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
    }
}
