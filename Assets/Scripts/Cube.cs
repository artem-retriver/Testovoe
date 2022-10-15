using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int speed;
    public int range;
    public int time;
    public bool isOn;

    public Rigidbody _rb;

    private void Update()
    {
        if(isOn == true)
        {
            UnMoveCube();
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void UnMoveCube()
    {
        Destroy(this.gameObject);
    }
}
