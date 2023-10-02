using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject proj;
    public Transform projPos;

    private float timer;
    void Start() {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4) {
            timer = 0;
            shoot();
        }
    }
    
    void shoot() {
        Instantiate(proj, projPos.position, Quaternion.identity);
    }
}
