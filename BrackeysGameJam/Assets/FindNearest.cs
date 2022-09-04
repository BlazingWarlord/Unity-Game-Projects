using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindNearest : MonoBehaviour
{
    public GameObject arrow;
    public Transform friend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> friends = GameObject.FindGameObjectsWithTag("Friend").ToList<GameObject>();
        CheckNearest(friends);
        arrow.transform.LookAt(friend);
    }
    public void CheckNearest(List<GameObject> friends)
    {
        if (friends.Count == 0)
        {
            Debug.Log("No Friends Left");
            PlayerPrefs.SetInt("Game Over", 1);
            return;
        };

        // This orders the list so the closest object will be the very first entry
        var sorted = friends.OrderBy(obj => (obj.transform.position - transform.position).sqrMagnitude);

        // currently closest
        var closest = sorted.First();

        friend = closest.transform;


    }
}
