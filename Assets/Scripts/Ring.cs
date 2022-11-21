using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > player.position.y)
        {
            GameManager.numberOfPassesRings++;
            Debug.Log(GameManager.numberOfPassesRings);
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.score++;
            Destroy(gameObject);

            if (GameManager.trackMode)
            {
                HelixManager helixManager = FindObjectOfType<HelixManager>();
                
                for (int i = 0; i < 2; i++)
                {
                    int index = Random.Range(0, helixManager.helixRings.Count);
                    helixManager.SpawnRing(index);
                }
            }
        }   
    }
}
