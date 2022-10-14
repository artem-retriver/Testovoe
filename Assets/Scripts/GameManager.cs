using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private TMP_InputField _inputSpeed;
    [SerializeField] private TMP_InputField _inputRange;
    [SerializeField] private TMP_InputField _inputTime;
    //[SerializeField] private  _text;

    private int _speedCube;

    private void Update()
    {
        
    }

    public void SpeedCube()
    {
        int.TryParse(_inputSpeed.text, out _cube.speed);
    }

    public void RangeCube()
    {
        int.TryParse(_inputRange.text, out _cube.range);
    }

    public void TimeCube()
    {
        double.TryParse(_inputTime.text, out _cube.time);
    }
}
