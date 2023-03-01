using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // tar reda p� musens position
        // g�r om den till punkter p� sk�rmen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        // flyttar spelaren till musens position
        transform.position = mousePosition;
    }

}
