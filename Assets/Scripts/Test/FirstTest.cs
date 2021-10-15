using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTest : MonoBehaviour
{
    public int x = 1;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, 2);
    }
}
