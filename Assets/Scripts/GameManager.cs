using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Button _playButton;
    [SerializeField] public Cube _cube;
    [SerializeField] private TMP_InputField _inputSpeed;
    [SerializeField] private TMP_InputField _inputRange;
    [SerializeField] private TMP_InputField _inputTime;
    [SerializeField] public TMP_Dropdown _dropDown;
    [SerializeField] public Obstacle _obstacle;

    public List<Cube> _currentCube;

    private int _currentspeedCube;
    private int _currentRangeCube;
    private int _currentTimeCube;

    private void Start()
    {
        _currentCube.Add(Instantiate(_cube));
        _currentCube[0].gameObject.SetActive(true);
    }

    public void ChangeColors()
    {
        var x = _currentCube.Count;

        if (_dropDown.value == 0)
        {
            _currentCube[x - 1].GetComponent<Renderer>().material.color = Color.black;
        }
        else if (_dropDown.value == 1)
        {
            _currentCube[x - 1].GetComponent<Renderer>().material.color = Color.green;
        }
        else if (_dropDown.value == 2)
        {
            _currentCube[x - 1].GetComponent<Renderer>().material.color = Color.red;
        }
        else if (_dropDown.value == 3)
        {
            _currentCube[x - 1].GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    public void DestroyCubeList()
    {
        _currentCube.RemoveAt(0);
    }

    public void MoveCube()
    {
        var x = _currentCube.Count;
            
        if (_currentCube[0].speed != 0 && _currentCube[0].range != 0 && _currentCube[0].time != 0)
        {
            _playButton.gameObject.SetActive(false);

            _currentCube[x - 1]._rb.velocity = Vector3.forward * _currentCube[0].speed;
            StartCoroutine(WaitInstatiateCube());
        }
        else
        {
            Debug.Log("¬введите данные");
        }

        _obstacle.gameObject.SetActive(true);
        _obstacle.transform.position = new Vector3(0, 0, _currentCube[0].range);
    }

    public void InstantiateCube()
    {
        var x = _currentCube.Count;
        _currentCube.Add(Instantiate(_cube));

        _currentCube[x].gameObject.SetActive(true);

        _currentCube[x].range = _currentRangeCube;
        _currentCube[x].speed = _currentspeedCube;
        _currentCube[x].time = _currentTimeCube;

        if (_dropDown.value == 0)
        {
            _currentCube[x].GetComponent<Renderer>().material.color = Color.black;
        }
        else if (_dropDown.value == 1)
        {
            _currentCube[x].GetComponent<Renderer>().material.color = Color.green;
        }
        else if (_dropDown.value == 2)
        {
            _currentCube[x].GetComponent<Renderer>().material.color = Color.red;
        }
        else if (_dropDown.value == 3)
        {
            _currentCube[x].GetComponent<Renderer>().material.color = Color.blue;
        }

        MoveCube();
    }

    public void SpeedCube()
    {
        int.TryParse(_inputSpeed.text, out _currentCube[0].speed);
        _currentspeedCube = _currentCube[0].speed;
    }

    public void RangeCube()
    {
        int.TryParse(_inputRange.text, out _currentCube[0].range);
        _currentRangeCube = _currentCube[0].range;
    }

    public void TimeCube()
    {
        int.TryParse(_inputTime.text, out _currentCube[0].time);
        _currentTimeCube = _currentCube[0].time;
    }

    private IEnumerator WaitInstatiateCube()
    {
        yield return new WaitForSeconds(_currentTimeCube);
        InstantiateCube();
    }
}
