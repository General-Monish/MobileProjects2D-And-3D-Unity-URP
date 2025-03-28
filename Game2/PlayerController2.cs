using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed;
    public float rotateSpeed;
    float roateDegree;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.x < 0)
            {
                roateDegree = rotateSpeed;
            }
            else
            {
                roateDegree = -rotateSpeed;
            }
            transform.Rotate(0,0,roateDegree);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "danger")
        {
            SceneManager.LoadScene("Game2");
        }
    }

 
}
