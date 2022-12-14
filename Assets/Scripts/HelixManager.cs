using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HelixManager : MonoBehaviour
{
    public List<GameObject> helixRings;
    public List<GameObject> helixMoreRings;
    public float ySpawn = 0 ;
    public float ringDistance = 5;
    public int numberOfRings;
    private int initRings = 5;
    private bool hasCompleteRing;
    [SerializeField]
    private GameObject lastRing;
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
                SpawnRing(Random.Range(1, helixRings.Count));
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
                numberOfRings = (GameManager.currentLevelIndex + 2) + initRings;
                for (int i = 0; i < (numberOfRings - initRings - 1); i++)
                {
                    SpawnRing(Random.Range(1, helixRings.Count));
                }
                SpawnLastRing();
            }


            if (GameManager.currentLevelIndex > 10 && !GameManager.trackMode)
            {
                Player player = FindObjectOfType<Player>();
                Instantiate(player.transform, player.transform.position, player.transform.rotation);
                helixRings.AddRange(helixMoreRings);
                GameManager.hasTwoPlayer = true;
            } else
            {
                if (GameManager.trackMode)
                {
                    if (numberOfRings > 20)
                    {
                        helixRings.AddRange(helixMoreRings);
                    }
                }
            }

            GameManager.isSetUp = true;
        }
    }

    public void SpawnRing(int ringIndex = 0)
    {
        GameObject helixRing = helixRings[ringIndex];
        GameObject[] helix = GameObject.FindGameObjectsWithTag("Ring");

        if (GameManager.isGameStarted && GameManager.currentLevelIndex > 2)
        {
            if (GameManager.currentLevelIndex < 5)
            {
                if (helix.Length > 2)
                {
                    while (helix[helix.Length - 1].name.Contains(helixRing.name) && helix[helix.Length - 2].name.Contains(helixRing.name))
                    {
                        ringIndex = Random.Range(1, helixRings.Count);
                        helixRing = helixRings[ringIndex];
                    }
                }
            }
            else
            {
                if (helix.Length > 1)
                {
                    while (helix[helix.Length - 1].name.Contains(helixRing.name))
                    {
                        ringIndex = Random.Range(1, helixRings.Count);
                        helixRing = helixRings[ringIndex];
                    }
                }
            }
        } else
        {
            if (helix.Length > 3)
            {
                while (helix[helix.Length - 1].name.Contains(helixRing.name) && 
                    helix[helix.Length - 2].name.Contains(helixRing.name) && 
                    helix[helix.Length - 3].name.Contains(helixRing.name))
                {
                    ringIndex = Random.Range(1, helixRings.Count);
                    helixRing = helixRings[ringIndex];
                }
            }
        }

        GameObject go = Instantiate(helixRing, transform.up * ySpawn, (GameManager.isGameStarted && GameManager.currentLevelIndex > 3) ? helixRing.transform.rotation : Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }

    public void SpawnRing( GameObject lastRing = null)
    {
        GameObject go = Instantiate(lastRing, transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }

    public void SpawnLastRing()
    {
        if (!GameManager.trackMode && !hasCompleteRing)
        {
            hasCompleteRing = true;
            SpawnRing(lastRing);
        }
    }
}
