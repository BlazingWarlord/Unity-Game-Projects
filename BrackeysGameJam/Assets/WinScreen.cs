using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TMP_Text winner;
    public TMP_Text scores;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if(PlayerPrefs.GetInt("FriendsRed") > PlayerPrefs.GetInt("FriendsBlue"))
        {
            winner.text = "Winner: Red";
        }
        else
        {
            winner.text = "Winner: Blue";
        }

        scores.text = "Scores: Blue - " + PlayerPrefs.GetInt("FriendsBlue").ToString() + " Red - " + PlayerPrefs.GetInt("FriendsRed").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
