using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // tar reda på musens position
        // gör om den till punkter på skärmen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        // flyttar spelaren till musens position
        transform.position = mousePosition;
    }

}
