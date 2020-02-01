using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private bool chase;

    public void SetChase(bool state)
    {
        chase = state;
    }
}
