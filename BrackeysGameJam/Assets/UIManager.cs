using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text Total;
    public TMP_Text Blue;
    public TMP_Text Red;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Friends", 10);
        PlayerPrefs.SetInt("FriendsBlue", 0);
        PlayerPrefs.SetInt("FriendsRed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Friend");
        PlayerPrefs.SetInt("Friends", go.Length);
        Total.text = "People Left: " + PlayerPrefs.GetInt("Friends", 10).ToString();
        Blue.text = "Friends Made: " + PlayerPrefs.GetInt("FriendsBlue", 0).ToString();
        Red.text = "Friends Made: " + PlayerPrefs.GetInt("FriendsRed", 0).ToString();
    }
}
