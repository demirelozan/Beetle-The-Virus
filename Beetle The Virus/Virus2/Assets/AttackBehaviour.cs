using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackBehaviour : StateMachineBehaviour
{
    private Transform PlayerPos;
    private Enemy enemyScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = animator.GetComponent<Enemy>();

        GameManager.instance.Hit(enemyScript, PlayerPos.GetComponent<Player>());

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
