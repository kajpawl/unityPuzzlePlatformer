using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [UnityEditor.MenuItem("Dev Tools/Delete Save")]
    public static void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }

    [SerializeField]
    private List<string> collectedKeys = new List<string>();
    [SerializeField]
    private int lives;

    private void Awake()
    {
        Load();
    }

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

    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("KeyCount", collectedKeys.Count);
        for (int i = 0; i < collectedKeys.Count; i++)
        {
            PlayerPrefs.SetString("key" + i, collectedKeys[i]);
        }
    }

    private void Load()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("KeyCount"); i++)
        {
            collectedKeys.Add(PlayerPrefs.GetString("key"+i));
        }
    }
}
