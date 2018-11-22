﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] private Fighter fighter;
    private float maxlife;
    private Text text;

    // Use this for initialization
    void Start()
    {
        maxlife = fighter.Hp;
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = fighter.Hp + "/" + maxlife;
    }
}
