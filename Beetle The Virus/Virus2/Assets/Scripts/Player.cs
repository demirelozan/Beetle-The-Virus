using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage<float>, IDoDamage
{
    [SerializeField]
    private float _HP = 50f;
    public float HP
       
    {
        get { return _HP; }
        set
        {
            if (value <= 0)
            {
                healthBar.SetBarSize(0);
                deathScreen.Death();
                Debug.Log("GameOver!");

            }
            else
            {
                _HP = value;
                healthBar.SetBarSize(value / 50);
            }
        }
    }

    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private DeathScreen deathScreen;

    public float attackPeriod = 3f;
    public float attack = 5f;
    private float range = 1f;
    public int direction = 1;
    public bool kırbac = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
            AudioManager.instance.Play(0);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        HP -= damageTaken;
    }

    public void Attack()
    {
        RaycastHit hit;

        List<int> raycastHits = new List<int>();

        for (float angle = -45; angle <= 45; angle += 15)
        {
            Physics.Raycast(transform.position, Quaternion.Euler(0, angle, 0) * Vector3.left * direction, out hit, range);

            Debug.DrawRay(transform.position, Quaternion.Euler(0, angle, 0) * Vector3.left * direction, Color.blue);

            GetComponent<Animator>().SetTrigger("Attack");

            if (hit.transform && hit.transform.GetComponent<Enemy>() != null)
            {
                int hitID = hit.transform.GetInstanceID();

                if (!raycastHits.Contains(hitID))
                {

                    raycastHits.Add(hitID);
                    Debug.Log("Hit");
                    GameManager.instance.Hit(this, hit.transform.GetComponent<Enemy>());
                    hit.rigidbody.AddForce((hit.transform.position - transform.position).normalized * 200);
                }

            }
        }
        raycastHits.Clear();
    }

    public float AttackDamage()
    {
        return attack;
    }
}
