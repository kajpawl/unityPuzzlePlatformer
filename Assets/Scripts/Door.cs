using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string keyColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Unlock()
    {
        Destroy(this.gameObject);
    }
}
