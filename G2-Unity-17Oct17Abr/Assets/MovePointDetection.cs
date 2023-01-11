using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointDetection : MonoBehaviour
{
    public bool IsObjectNear = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            IsObjectNear = true;
            Debug.Log("Hay un objeto enfrente");
        }
    }
}
