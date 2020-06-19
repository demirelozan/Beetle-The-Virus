using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDoDamage 
{
    private float damage = 10f;
    public float BulletSpeed = 5f;
    
    
    
    void Start()
    {
        Invoke("KillYourself", 8f);
    }

    
    public float AttackDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform && other.transform.GetComponent<Player>())
        GameManager.instance.Hit(this, other.transform.GetComponent<Player>());

    }
    private void KillYourself()
    {
        Destroy(gameObject);
    }
}
