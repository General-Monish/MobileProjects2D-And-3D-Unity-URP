using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBS : MonoBehaviour
{
    [SerializeField] float obsRotateSpeed;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] LayerMask PlayerLayer;
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
        transform.Rotate(0, 0, -obsRotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsGrounded())
        {
            Destroy(gameObject,0.2f);
            GM1.Instance.IncreaseScore();
        }

        if(IsHittingPlayer())
        {
            Destroy(collision.gameObject);
            GM1.Instance.GameOver();
        }
    }
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, GroundLayer.value);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    bool IsHittingPlayer()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        Debug.DrawRay(position, direction * distance, Color.red, 1f); // Debugging Raycast


        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, PlayerLayer.value);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

}
