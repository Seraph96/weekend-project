﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class switchScenes : MonoBehaviour
{


    void OnMouseDown()
    {
        Debug.Log("clicked");
        
         SceneManager.LoadScene(1);

    }
    
    
}
