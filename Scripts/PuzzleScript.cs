using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuzzleScript : MonoBehaviour
{
   public int value = 1;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            PuzzleCollector.instance.IncreasePiece(value);
            Destroy(gameObject);
        }
    }
}
