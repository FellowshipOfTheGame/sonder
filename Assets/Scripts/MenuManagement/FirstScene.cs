﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstScene : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("CasaPrincipal");
    }
}
