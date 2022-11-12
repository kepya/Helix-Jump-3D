using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = newCharacter;
        characters[selectedCharacter].SetActive(true);
    }
}
