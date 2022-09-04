using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    public Animator main;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController talk;
    public RuntimeAnimatorController run;
    public RuntimeAnimatorController strafe;
    public FriendMakeScript fms;
    public AudioSource walksound;
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
        main.runtimeAnimatorController = idle;
        fms = GetComponent<FriendMakeScript>();
        cc = GetComponent<CharacterController>();
        walksound.Pause();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fms.istalking == true)
        {
            main.runtimeAnimatorController = talk;
            walksound.Stop();
            cc.enabled = false;
        }
        else if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            cc.enabled = true;
            main.runtimeAnimatorController = run;
            if (!walksound.isPlaying)
            {
                walksound.Play();
            }
        }
        
        else if (Input.GetKey("w"))
        {
            cc.enabled = true;
            main.runtimeAnimatorController = walk;
            if(!walksound.isPlaying)
            {
                walksound.Play();
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("d"))
        {
            main.runtimeAnimatorController = strafe;
            cc.enabled = true;
            if (!walksound.isPlaying)
            {
                walksound.Play();
            }
        }
        else
        {
            main.runtimeAnimatorController = idle;
            walksound.Stop();
            cc.enabled = true;
        }
    }
}
