﻿using UnityEngine;
using System.Collections;

public class ComputerScreen : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ShowProfile()
    {
        this.gameObject.SetActive(true);
    }
}
