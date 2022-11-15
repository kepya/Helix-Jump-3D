using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0 ;
    public float ringDistance = 5;
    public int numberOfRings;
    private int initRings = 5;
    private bool hasCompleteRing;

    // Start is called before the first frame update
    void Start()
    {
        hasCompleteRing = false;
        numberOfRings = initRings;

        //Spawn helix ring
        for (int i = 0; i < numberOfRings; i++)
        {
            if (i==0)
                SpawnRing(0);
            else
                SpawnRing(Random.Range(1, helixRings.Length - 1));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isGameStarted && !GameManager.isSetUp) {
            if (GameManager.currentLevelIndex <= 1)
            {
                SpawnLastRing();
            } else
            {
                numberOfRings = GameManager.currentLevelIndex * initRings;
                for (int i = 0; i < (numberOfRings - initRings - 1); i++)
                {
                    SpawnRing(Random.Range(1, helixRings.Length - 1));
                }
                SpawnLastRing();
            }


            if (numberOfRings > 10 && !GameManager.trackMode)
            {
                Player player = FindObjectOfType<Player>();
                Instantiate(player.transform, player.transform.position, player.transform.rotation);
            }

            GameManager.isSetUp = true;
        }
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }

    public void SpawnLastRing()
    {
        if (!GameManager.trackMode && !hasCompleteRing)
        {
            hasCompleteRing = true;
            SpawnRing(helixRings.Length - 1);
        }
    }
}
