using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimSkript : MonoBehaviour
{
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeToTPose();
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    //anim.CrossFade("MikeWalking", 0.1f);
        //    anim.SetBool("");
        //}

        else if(Input.GetKey(KeyCode.W))
        {
            ChangeToWalking();
        }
        else
        {
            ChangeToIdle();
        }
    }


    void ChangeToWalking()
    {
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsTPose", false);
        //anim.CrossFade("MikeWalking", 0.1f );
    }
    void ChangeToIdle()
    {
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsTPose", false);
        //anim.CrossFade("MikeIdle", 0.1f);
    }
    void ChangeToTPose()
    {
        //anim.CrossFade("MikeTPose", 0.1f);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsTPose", true);

    }
}
