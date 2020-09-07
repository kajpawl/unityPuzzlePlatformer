using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private List<string> collectedKeys = new List<string>();
    [SerializeField]
    private int lives;

    public void RemoveLife()
    {
        lives--;
        if (lives < 0)
        {
            Debug.Log("Game over");
        }
    }

    public void AddKey(string key)
    {
        collectedKeys.Add(key);
    }

    public void RemoveKey(string key)
    {
        collectedKeys.Remove(key);
    }

    public bool HasKey(string key)
    {
        return collectedKeys.Contains(key);
    }
}
