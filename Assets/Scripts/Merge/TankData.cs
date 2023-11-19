using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankData : MonoBehaviour
{
    //public Tank _tank;
    public float[] _position;

    public TankData(Tank tank)
    {
        //_tank = tank;
        _position = new float[3];
        _position[0] = tank.transform.position.x;
        _position[1] = tank.transform.position.y;
        _position[2] = tank.transform.position.z;
    }
}
