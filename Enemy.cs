using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fireRate = 3f; //shoots 3 times/seccond
    public GameObject shootPrefab;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 0f, 1f / fireRate);
    }

    void Update()
{
    transform.LookAt(player);
}

    void Shoot()
    {
        GameObject shoot = Instantiate(shootPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = shoot.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20f;
        Destroy(shoot, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
