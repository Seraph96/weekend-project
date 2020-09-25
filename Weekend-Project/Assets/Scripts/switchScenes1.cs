using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class switchScenes1 : MonoBehaviour
{


    void OnMouseDown()
    {
        Debug.Log("clicked");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    
    
}
