using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
 /*   public void Start()
    {
        AudioManager.instance.Play(5);
    }*/


    [SerializeField]
    private GameObject winScreen;
    private bool start1 = false;

    public void Hit(IDoDamage attacker, ITakeDamage<float> defender)
    {
        Debug.Log("Hit");
        defender.TakeDamage(attacker.AttackDamage());
    }

    public void WinScreen()
    {
        start1 = true;
        winScreen.SetActive(true);

    }

    private void Update()
    {
        if (start1)
        {
            winScreen.GetComponent<Image>().color = new Color(1, 1, 1, winScreen.GetComponent<Image>().color.a + Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
