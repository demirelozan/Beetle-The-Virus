using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public void SetBarSize(float size)
    {
        transform.localScale = new Vector3(size, 1, 1);
    }
}
