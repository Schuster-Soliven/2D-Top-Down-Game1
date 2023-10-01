using UnityEngine;

public class TrapController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            Debug.Log("DEAD!");
            Destroy(collision.gameObject); // This destroys the player GameObject
        }
    }
}

//1. Attach script to trap
//2. Tag the player to be assigned to Player GameObject
//3. And add collider to the trap (Tilemap Collider 2D)
