using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerEnemy : MonoBehaviour
{
    public Animator main;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController talk;
    public RuntimeAnimatorController run;
    public RuntimeAnimatorController strafe;
    public FriendMakeScript fms;
    public NavMeshManager nmm;
    bool isc = false;
    // Start is called before the first frame update
    void Start()
    {
        main.runtimeAnimatorController = run;
        fms = GetComponent<FriendMakeScript>();
        nmm = GetComponent<NavMeshManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fms.istalking == true)
        {
            
            main.runtimeAnimatorController = talk;
            if(!isc)
            {
                StartCoroutine(Delay());
                isc = true;
            }
            
        }
        else if(!nmm.isActiveAndEnabled)
        {
            main.runtimeAnimatorController = idle;
        }
        else
        {
            main.runtimeAnimatorController = run;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        isc = false;
    }
}
