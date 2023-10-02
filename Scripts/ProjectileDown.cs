using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileD : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1).normalized * force;
    }
    void Update() {
        timer += Time.deltaTime;
        if (timer > 2) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().health -= 1;
            Destroy(gameObject);
        }
    }
}
