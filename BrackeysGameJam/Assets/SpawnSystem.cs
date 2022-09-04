using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnityEditor.TransformWorldPlacementJSON:{"position":{"x":4.199999809265137,"y":0.0,"z":225.89999389648438},"rotation":{"x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{"x":1.0,"y":1.0,"z":1.0}}
//Vector3(4.19999981,0,225.899994)
public class SpawnSystem : MonoBehaviour
{
    private System.Random _random = new System.Random();
    public GameObject friend;
    public GameObject[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Debug.Log(spawnpoints[0].transform.name);
        Shuffle(spawnpoints);
        for(int i = 0;i<11;i++)
        {
            Instantiate(friend, spawnpoints[i].transform);
            Debug.Log((spawnpoints[i].transform.position.x,spawnpoints[i].transform.position.y,spawnpoints[i].transform.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shuffle(GameObject[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(1, n);
            GameObject t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }
}
