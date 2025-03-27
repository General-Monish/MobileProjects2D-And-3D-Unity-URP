using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*moveSpeed*Time.deltaTime);
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
