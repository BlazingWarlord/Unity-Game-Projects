using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.SceneManagement;

//UnityEditor.TransformWorldPlacementJSON:{"position":{"x":9.184242248535157,"y":1.7300000190734864,"z":129.5588836669922},"rotation":{"x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{"x":1.0,"y":1.0,"z":1.0}}0.0,"z":0.0,"w":1.0},"scale":{"x":0.11999999731779099,"y":0.05999999865889549,"z":0.11999999731779099}}

public class NavMeshManager : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform friend;

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
        // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Game Over", 0);

    }
    

    // Update is called once per frame
    void Update()
    {
        List<GameObject> friends = GameObject.FindGameObjectsWithTag("Friend").ToList<GameObject>();
        CheckNearest(friends);
        if(PlayerPrefs.GetInt("Game Over") == 1)
        {
            this.GetComponent<NavMeshManager>().enabled = false;
            SceneManager.LoadScene(4);
        }
        Transform body = friend.GetChild(1);
        Debug.Log(body.transform.position.x);
        enemy.SetDestination(new Vector3(body.position.x - 0.2f, body.position.y, body.position.z - 0.2f));
        

    }
}
