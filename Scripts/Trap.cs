using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Trap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
            Destroy(collider.gameObject);
            Debug.Log("Main Menu");
            SceneManager.LoadScene(0);
    }
}

//1. Attach script to trap
//2. Tag the player to be assigned to Player GameObject
//3. And add collider to the trap (Tilemap Collider 2D)
