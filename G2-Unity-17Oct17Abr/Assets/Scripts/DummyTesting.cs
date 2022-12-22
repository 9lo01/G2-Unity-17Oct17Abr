using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// this class (<c> DummyTesting </c>) has the power of containing features for the main character.
/// </summary>
public class DummyTesting : MonoBehaviour
{
  // ESTRUCTURA DE UNA VARIABLE: PUBLIC/PRIVATE + TIPO DE DATO + NOMBRE DE LA VARIABLE + DATO ASIGNADO

  // VARIABLES NATIVAS DEL C#
  public int Edad = 23;
  public float Estatura = 1.83f;
  public bool RecibiDano = false;
  public char letras = 'a';
  public double Contraseña = 123456789;
  public string nombre = "Roberto";
  public string Inventario;
  public bool IsInUpdate = true;
  public bool IsInFixedUpdate = true;
  public bool IsInLateUpdate = true;
  // VARIABLES NATIVAS DE UNITY
  public Vector3 Posicion;
  public int vida = 10;
  public TMP_Text contador;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    //Debug.Log(name + " collide with: " + collision.gameObject.name);

    if (collision.gameObject.CompareTag("Obstacle"))
    {
      if (vida <= 0)
      {
        Debug.Log("Game Over");
        return;
      }
      Debug.Log(name + " collide with: " + collision.gameObject.name);
      vida = vida - 1;
      Debug.Log("Vida Actual: " + vida.ToString());
    }

    if (collision.gameObject.CompareTag("SafeZone"))
    {
      vida = vida + collision.gameObject.GetComponent<SafeZone>().healthPoints;
      
    }
    contador.text = vida.ToString();


  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("SafeArea"))
    {
      Inventario = collision.gameObject.transform.parent.gameObject.GetComponent<SafeZone>().Items[2];

            Debug.Log("Al chocar con la SafeArea obtuviste: " + Inventario);
    }
  }
}
