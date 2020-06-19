using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : StateMachineBehaviour
{
    private EnemyShooter enemyScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyScript = animator.GetComponent<EnemyShooter>();
        enemyScript.Attack();

        

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}