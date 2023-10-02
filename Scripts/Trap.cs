using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Trap : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            Debug.Log("Collision Triggered");
            SceneManager.LoadScene(5);
        }
    }
}
//1. Attach script to trap
//2. Tag the player to be assigned to Player GameObject
//3. And add collider to the trap (Tilemap Collider 2D)
