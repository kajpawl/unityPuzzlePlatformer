using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Take()
    {
        Destroy(this.gameObject);
    }
}
