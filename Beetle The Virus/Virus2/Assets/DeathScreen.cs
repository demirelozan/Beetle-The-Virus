using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;
    private bool start1;
    private bool start2;

    public void Death()
    {
        Invoke("Image1", 1);
        Invoke("Image2", 3);
    }


    private void Image1()
    {
        start1 = true;
    }

    private void Image2()
    {
        start2 = true;
    }

    void Update()
    {
        if (start1)
        {
            image1.color = new Color(1, 1, 1, image1.color.a+Time.deltaTime);
        }
        if (start2)
        {
            image2.color = new Color(1, 1, 1, image2.color.a + Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);


    }
}
