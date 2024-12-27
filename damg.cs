using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class damg : MonoBehaviour

   {
    Vector2 startPos;
    private void Start() {
        startPos = transform.position;}
    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))

    Die();
    }
    void Die() {
        StartCoroutine(Respawn(0f));
    }
    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
    }
   }