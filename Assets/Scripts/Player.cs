using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 6f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
        string materialNamae = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        if (materialNamae == "Safe (Instance)")
        {

        } else if (materialNamae == "UnSafe (Instance)")
        {
            Debug.Log("Game Over");
            GameManager.gameOver = true;
        }
        else if (materialNamae == "LastRing (Instance)")
        {
            Debug.Log("Complete Level");
            GameManager.levelComplete = true;
        }
    }
}
