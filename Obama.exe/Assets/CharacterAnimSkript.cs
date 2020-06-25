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
            anim.CrossFade("MikeTPose", 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.CrossFade("MikeWalking", 0.1f);
        }

        if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }
    }
}
