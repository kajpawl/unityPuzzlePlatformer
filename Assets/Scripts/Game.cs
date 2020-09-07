using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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
}
