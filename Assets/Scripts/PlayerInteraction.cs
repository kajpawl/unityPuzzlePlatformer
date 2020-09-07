using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Game game;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Key>())
        {
            Key key = collision.gameObject.GetComponent<Key>();
            game.AddKey(key.keyColor);
            key.Take();
        }
    }
}
