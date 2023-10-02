using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileR : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Vector2 direction = transform.right;
        rb.velocity = new Vector2(1, 0).normalized * force;
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
