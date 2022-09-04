using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMakeScript : MonoBehaviour
{
    public bool istalking = false;
    public GameObject textbox;
    float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(istalking == true)
        {
            textbox.SetActive(true);
            if(delay <= 0)
            {
                
                textbox.SetActive(false);
                istalking = false;
                delay = 5f;
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }
    }
}
