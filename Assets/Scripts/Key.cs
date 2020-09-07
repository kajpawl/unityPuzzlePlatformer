using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public string keyColor;

    void Awake()
    {
        if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name, 0) == 1)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public void Take()
    {
        PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name, 1);
        Destroy(this.gameObject);
    }
}
