using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFollowingBehaviour : StateMachineBehaviour
{
    private float speed = 1f;
    private Transform PlayerPos;
    private SpriteRenderer sprite;
    private EnemyShooter enemyScript;
    private float timer = 3f;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = animator.GetComponent<SpriteRenderer>();
        enemyScript = animator.GetComponent<EnemyShooter>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetBool("IsFollowing", false);
        }
        //

        if(Vector3.Distance(animator.transform.position, PlayerPos.position) > animator.GetComponent<EnemyShooter>().range)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(PlayerPos.position.x, 0, PlayerPos.position.z), speed * Time.deltaTime);

        }
        else
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(animator.transform.position.x - PlayerPos.position.x, 0, animator.transform.position.z - PlayerPos.position.z), speed * Time.deltaTime);
        }



        if (PlayerPos.position.x - animator.transform.position.x > 0)
        {
            sprite.flipX = true;
            enemyScript.direction = -1;

        }
        else
        {
            sprite.flipX = false;
            enemyScript.direction = 1;
        }


        timer -= Time.deltaTime;

        if (Vector3.Distance(animator.transform.position, PlayerPos.position) < animator.GetComponent<EnemyShooter>().range && timer <= 0)
        {
            timer = enemyScript.attackPeriod;
            animator.SetBool("Attack", true);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
