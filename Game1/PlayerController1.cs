using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x < Screen.width / 2) 
            {
                rb.velocity = Vector2.left * moveSpeed;
                sp.flipX = true;
            }
            else
            {
                rb.velocity = Vector2.right * moveSpeed;
                sp.flipX = false;
            }
        }
    }
}
