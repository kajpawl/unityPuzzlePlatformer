using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    private Portal[] scenePortals;
    private int portalToSpawnAt;

    void Awake()
    {
        scenePortals = FindObjectsOfType<Portal>();
    }

    public void SetSpawnPortal(Portal portal)
    {
        portalToSpawnAt = portal.portalId;
        PlayerPrefs.SetInt("PortalToSpawnAt", portal.portalId);
        SceneManager.LoadScene(portal.scene);
    }

    public Vector3 GetSpawnPosition()
    {
        portalToSpawnAt = PlayerPrefs.GetInt("PortalToSpawnAt");
        Vector3 spawnPosition = new Vector3();

        foreach (Portal portal in scenePortals)
        {
            if (portal.portalId == portalToSpawnAt)
            {
                spawnPosition = portal.spawnPosition;
            }
        }

        return spawnPosition;
    }
}
