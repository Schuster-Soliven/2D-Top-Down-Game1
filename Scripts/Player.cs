using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    float moveSpeed = 2.5f;
    Vector2 moveDir = Vector2.zero;
    Rigidbody2D rb2d;
    [SerializeField]
    public float health = 1;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.MovePosition(rb2d.position + moveDir * moveSpeed * Time.deltaTime * Time.timeScale);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Enemy") ) {
            Debug.Log("Collision Trigger");
            SceneManager.LoadScene(5);
        }
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}
