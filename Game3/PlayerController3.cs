using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController3 : MonoBehaviour
{
    float playerYPos;
    [SerializeField] LayerMask obstacleLayer;
    // Start is called before the first frame update
    void Start()
    {
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && GM2.instance.isGameStarted)
        {
            playerYPos = -playerYPos;
            transform.position = new Vector3(transform.position.x,playerYPos,transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & obstacleLayer) != 0) // ✅ Correct Way
        {
            /*GM2.instance.GameOver();*/
            GM2.instance.UpdateLives();
            GM2.instance.Shake();
        }
    }

}
