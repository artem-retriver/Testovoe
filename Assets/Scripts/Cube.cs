using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //[SerializeField] public GameManager manager;
    public int speed;
    public int range;
    public double time;

    public Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void UnMoveCube()
    {
        Destroy(this.gameObject);
    }
}
