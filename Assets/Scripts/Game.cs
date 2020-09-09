using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private List<string> collectedKeys = new List<string>();
    [SerializeField]
    private int initialLives = 9;
    private int lives;
    [SerializeField]
    private TMPro.TextMeshProUGUI[] keyCountTexts;
    [SerializeField]
    private TMPro.TextMeshProUGUI livesText;

    // [UnityEditor.MenuItem("Dev Tools/Delete Save")]
    public static void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }

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
            PlayerPrefs.DeleteAll();
            collectedKeys.Clear();
            lives = initialLives;
        }
        PlayerPrefs.DeleteKey("PortalToSpawnAt");
        UpdateUI();
    }

    public void AddKey(string key)
    {
        collectedKeys.Add(key);
        UpdateUI();
    }

    public void RemoveKey(string key)
    {
        collectedKeys.Remove(key);
        UpdateUI();
    }

    public bool HasKey(string key)
    {
        return collectedKeys.Contains(key);
    }

    private void OnDestroy()
    {
        Save();
    }

    private void UpdateUI()
    {
        keyCountTexts[0].text = collectedKeys.Count(key => key == "green").ToString();
        keyCountTexts[1].text = collectedKeys.Count(key => key == "red").ToString();
        keyCountTexts[2].text = collectedKeys.Count(key => key == "blue").ToString();
        livesText.text = lives.ToString();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("KeyCount", collectedKeys.Count);
        PlayerPrefs.SetInt("Lives", lives);
        for (int i = 0; i < collectedKeys.Count; i++)
        {
            PlayerPrefs.SetString("key" + i, collectedKeys[i]);
        }
    }

    private void Load()
    {
        lives = PlayerPrefs.GetInt("Lives", initialLives);
        for (int i = 0; i < PlayerPrefs.GetInt("KeyCount"); i++)
        {
            collectedKeys.Add(PlayerPrefs.GetString("key"+i));
        }
        UpdateUI();
    }
}
