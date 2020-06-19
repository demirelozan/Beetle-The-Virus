using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour, ITakeDamage<float>, IDoDamage
{
    [SerializeField]
    private float _HP = 15f;
    public float HP
    {
        get { return _HP; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Dead");
                GetComponent<Animator>().SetTrigger("Die");
            }
            else
                _HP = value;
        }
    }
    public float range = 1f;
    public int direction = 1;
    public float attackPeriod;

    private float attack = 10f;


    private Transform PlayerPos;

    public GameObject Bullet;
    private GameObject spawnedBullet;

    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        

    }


    public void TakeDamage(float damageTaken)
    {
        HP -= damageTaken;
    }

    public void Attack()
    {

        spawnedBullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
        spawnedBullet.GetComponent<Rigidbody>().velocity = (PlayerPos.position - transform.position).normalized *2;
    }


    public float AttackDamage()
    {
        return attack;
    }
}
