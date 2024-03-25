using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public List<Color> colors;
    public GameObject carPrefab;


    public int speed = 20;
    public int gear = 5;
    public int maxCar = 5;

    private Vector3 _positionNext = new Vector3(-4f,0f,0f);
    private int _carNumber = 0;
    private List<GameObject> _carPrefabs = new List<GameObject>();
    private float _size = 1f;
    private float _sizeVariation = 0.2f;


    private void Start()
    {
        colors.Add(Color.blue);
        colors.Add(Color.cyan);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
    }
    public int TotalSpeed
    {
        get { return speed * gear; }
    }

    public void CreateCar()
    {
        if(_carNumber < maxCar)
        {
            var a = Instantiate(carPrefab);
            _carPrefabs.Add(a);
            a.transform.Scale(_size + _sizeVariation);
            ParticleSystem.MainModule main = a.GetComponentInChildren<ParticleSystem>().main;
            main.startColor = colors.GetRandom();
            a.GetComponent<Renderer>().material.SetColor("_Color", main.startColor.color);
            a.transform.position = _positionNext;
            _positionNext.x = a.transform.position.x + 2;
            Debug.Log("_positionNext is "+ _positionNext);
            _carNumber++;
            //_size += _sizeVariation;
        }
    }

    public void RemoveCar()
    {
        if (_carNumber > 0)
        {
            Destroy(_carPrefabs[_carNumber-1]);
            _carPrefabs.Remove(_carPrefabs[_carNumber - 1]);
            _positionNext.x -= 2;
            _carNumber--;
            //_size -= _sizeVariation;
        }
    }
}
