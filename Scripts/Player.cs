using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    EnemyManager em;
    [SerializeField]
    [Range(0,100)]
    float moveSpeed = 2.5f;
    Vector2 moveDir = Vector2.zero;
    Rigidbody2D rb2d;
    [SerializeField]
    RectTransform healthbarForeground;
    [SerializeField]
    float maxHealth = 3;
    float curHealth = 0;
    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        rb2d = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.MovePosition(rb2d.position + moveDir * moveSpeed * Time.deltaTime * Time.timeScale);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(curHealth-- < 0) curHealth = maxHealth;

        if(collider.gameObject.CompareTag("Trap"))
            Destroy(collider.gameObject);
        
        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}