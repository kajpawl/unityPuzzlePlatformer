using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int portalId;
    public int scene;
    public Vector3 spawnPosition;

    void Start()
    {
        
    }

    private void Awake()
    {
        spawnPosition = transform.GetChild(0).position;
    }
}
