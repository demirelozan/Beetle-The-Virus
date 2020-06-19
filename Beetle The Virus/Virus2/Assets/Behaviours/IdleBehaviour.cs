using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private Transform PlayerPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteRenderer sprite = animator.GetComponent<SpriteRenderer>();

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (Random.Range(0f, 1f) > 0.5f)
            sprite.flipX = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("IsFollowing", true);
        }
        */

        float distance = Vector3.Distance(PlayerPos.transform.position, animator.transform.position);
        if (distance < 5)
        {
            animator.SetBool("IsFollowing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
