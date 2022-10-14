using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int speed;
    public int range;
    public double time;

    private Vector3 _newPosition;

    private void Update()
    {
       // MoveCube();
    }

    public void MoveCube()
    {
        if(speed != 0 && range != 0 && time != 0)
        {
            _newPosition = new Vector3(0, 0, range + speed * Time.deltaTime);
            transform.position = _newPosition;  
        }
        else
        {
            Debug.Log("¬введите данные");
        }
    }
}
