using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public int speed;
    public int range;
    public int time;

    public Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Destroy(this.gameObject);
            _gameManager.DestroyCubeList();
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
