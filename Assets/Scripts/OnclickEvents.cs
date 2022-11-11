using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnclickEvents : MonoBehaviour
{

    public TextMeshProUGUI soundText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            soundText.text = "/";
        }
        else
        {
            soundText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() { 
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            soundText.text = "";
            GameManager.mute = false;
        } else
        {
            soundText.text = "/";
            GameManager.mute = true;
        }
    }
}
