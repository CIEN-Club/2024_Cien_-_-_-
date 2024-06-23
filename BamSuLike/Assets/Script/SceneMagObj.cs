using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMagObj : MonoBehaviour
{
    public void LoadScene(string name)
    {
        try
        {
            SceneManager.LoadScene(name);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            Debug.Log("There is not \"" + name + "\" Scene.");
        }
    }
}
