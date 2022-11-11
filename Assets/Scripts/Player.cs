using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 6f;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
        string materialNamae = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        if (materialNamae == "Safe (Instance)")
        {

        } else if (materialNamae == "UnSafe (Instance)")
        {
            Debug.Log("Game Over");
            audioManager.Play("game over");
            GameManager.gameOver = true;
        }
        else if (materialNamae == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            Debug.Log("Complete Level");
            audioManager.Play("win level");
            GameManager.levelComplete = true;
        }
    }
}
