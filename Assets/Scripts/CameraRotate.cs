using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dx = Input.GetAxisRaw("Mouse X");
        transform.Rotate(0, dx * rotSpeed, 0);
    }
}
