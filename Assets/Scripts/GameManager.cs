using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Cube _cube;
    [SerializeField] private TMP_InputField _inputSpeed;
    [SerializeField] private TMP_InputField _inputRange;
    [SerializeField] private TMP_InputField _inputTime;

    public List<Cube> _currentCube;
    //[SerializeField] private  _text;

    private int _currentspeedCube;
    private int _currentRangeCube;
    private double _currentTimeCube;

    private void Start()
    {
        _currentCube.Add(Instantiate(_cube));
        _currentCube[0].gameObject.SetActive(true);
        //_cube = GetComponent<Cube>();
        //_currentCube = _cube;
        //Instantiate(_cube);
    }

    private void Update()
    {
        for (int i = 0; i < _currentCube.Count; i++)
        {
            if (_currentCube[i].transform.position.z != 0)
            {
                if (_currentCube[i].transform.position == new Vector3(0, 0, _currentCube[i].range))
                {
                    var array = _currentCube.Where(x => x.range == _currentRangeCube);

                    foreach (var x in array)
                    {
                        _currentCube.Remove(x);
                        Destroy(x.gameObject);
                    }
                }
            }
        }
    }

    public void MoveCube()
    {
        for (int i = 0; i < _currentCube.Count; i++)
        {
            if (_currentCube[i].speed != 0 && _currentCube[i].range != 0 && _currentCube[i].time != 0)
            {
                _currentCube[i]._rb.velocity = Vector3.forward * _currentCube[i].speed;
                StartCoroutine(WaitInstatiateCube());
            }
            else
            {
                Debug.Log("¬введите данные");
            }
        }
        
    }

    public void InstantiateCube()
    {
        _currentCube.Add(Instantiate(_cube));

        for (int i = 0; i < _currentCube.Count; i++)
        {
            _currentCube[i].gameObject.SetActive(true);

            _currentCube[i].range = _currentRangeCube;
            _currentCube[i].speed = _currentspeedCube;
            _currentCube[i].time = _currentTimeCube;

            //Debug.Log(_currentCube.speed);
            MoveCube();
            //_currentCube[i]._rb.velocity = Vector3.forward * _currentCube[i].speed;
        }

        Debug.Log(_currentspeedCube);

       
    }

    public void DestroyObject()
    {
        
    }

    public void SpeedCube()
    {
        for (int i = 0; i < _currentCube.Count; i++)
        {
            int.TryParse(_inputSpeed.text, out _currentCube[i].speed);
            _currentspeedCube = _currentCube[i].speed;
        }
    }

    public void RangeCube()
    {
        for (int i = 0; i < _currentCube.Count; i++)
        {
            int.TryParse(_inputRange.text, out _currentCube[i].range);
            _currentRangeCube = _currentCube[i].range;
        }
    }

    public void TimeCube()
    {
        for (int i = 0; i < _currentCube.Count; i++)
        {
            double.TryParse(_inputTime.text, out _currentCube[i].time);
            _currentTimeCube = _currentCube[i].time;
        }
    }

    private IEnumerator WaitInstatiateCube()
    {
        yield return new WaitForSeconds(_currentspeedCube);
        InstantiateCube();
    }
}
