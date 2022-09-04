using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform targetpos;
    int speed = 30;
    public AudioSource horn;
    public GameObject player;
    public float dist;
    bool hornblow = false;
    //UnityEditor.TransformWorldPlacementJSON:{"position":{"x":201.09622192382813,"y":2.5057451725006105,"z":-197.45999145507813},"rotation":{"x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{"x":1.0,"y":1.0,"z":1.0}}
    // Start is called before the first frame update
    void Start()
    {
        
        targetpos = point1.transform;
        horn = GetComponent<AudioSource>();
        

        
        
    }

    // Update is called once per frame
    void Update()
    {

        dist = Mathf.Abs(transform.position.sqrMagnitude - player.transform.position.sqrMagnitude);
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, targetpos.position, step);
        gameObject.transform.LookAt(targetpos);
        if (Mathf.Abs(transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) < 1000f)
        {
           
            horn.Play();
            
            
        }
        
        if (gameObject.transform.position == point1.position)
        {
            targetpos = point2.transform;
        }
        if (gameObject.transform.position == point2.position)
        {
            targetpos = point3.transform;
        }
        if (gameObject.transform.position == point3.position)
        {
            targetpos = point4.transform;
        }
        if (gameObject.transform.position == point4.position)
        {
            targetpos = point1.transform;
        }
        

        
    }
}
