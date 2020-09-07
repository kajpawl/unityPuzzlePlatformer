﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Game game;
    private PortalController portalController;

    private void Awake()
    {
        portalController = FindObjectOfType<PortalController>();
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Door>())
        {
            Door door = collision.gameObject.GetComponent<Door>();

            if (game.HasKey(door.keyColor))
            {
                game.RemoveKey(door.keyColor);
                door.Unlock();
            }
        }

        if (collision.gameObject.GetComponent<Portal>())
        {
            portalController.SetSpawnPortal(collision.gameObject.GetComponent<Portal>());
        }
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
