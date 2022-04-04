using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimation : MonoBehaviour
{
    public Transform wing;
    public float speed = 5f;


    private void Update()
    {
        wing.Rotate(Vector3.up, speed);
    }
}
