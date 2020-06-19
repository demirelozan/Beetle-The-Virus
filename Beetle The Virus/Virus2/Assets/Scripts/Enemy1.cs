using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, ITakeDamage<float>, IDoDamage
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
                AudioManager.instance.Play(1);
            }
            else
                _HP = value;
        }
    }
    public float range = 1f;
    public int direction = 1;
    public float attackPeriod = 5f;

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
      /*  if (Input.GetKeyDown(KeyCode.O))
        {
            spawnedBullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
        }
        */
    }


    public void TakeDamage(float damageTaken)
    {
        HP -= damageTaken;
    }

    public void Attack()
    {
        GameManager.instance.Hit(this, PlayerPos.GetComponent<Player>());
        AudioManager.instance.Play(2);
    }


    public float AttackDamage()
    {
        return attack;
    }
}
