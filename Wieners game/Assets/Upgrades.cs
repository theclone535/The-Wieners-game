using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    static public bool test;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(test);
        if (Input.GetKey("l"))
        {
            test = true;
        }
    }
}
