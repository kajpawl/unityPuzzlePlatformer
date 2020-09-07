using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Game game;

    void Awake()
    {
        game = FindObjectOfType<Game>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Debug.Log("Die!");
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Died!");
        game.RemoveLife();
        // SceneManager.LoadScene(0);
    }
}
