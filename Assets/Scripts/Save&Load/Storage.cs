using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class Storage : MonoBehaviour
{
    [SerializeField]private Tank[] _tanks;
    [SerializeField] private PositionTank[] _positionTank; 

    private List<Tank> _enemySaves = new List<Tank>();
    private string _filePath;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
        LoadGame();
    }

    //private void Update()
    //{
    //    Tank[] tanks = GameObject.FindObjectsOfType<Tank>();
    //    _enemySaves = new List<Tank>();

    //    for (int i = 0; i < tanks.Length; i++)
    //        _enemySaves.Add(tanks[i]);
    //}

    public void ListChanged()
    {
        _enemySaves = new List<Tank>();

        for (int i = 0; i < _positionTank.Length; i++)
        {
            if(_positionTank[i].Target != null)
                _enemySaves.Add(_positionTank[i].Target.GetComponent<Tank>());
        }

        SaveGame();
    }

    public void AddTank(Tank tank)
    {
        _enemySaves.Add(tank);
        SaveGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void Exit()
    {
        SaveGame();
        Application.Quit();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Create);
        Saves save = new Saves();
        save.SaveEnemies(_enemySaves);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Open);

        Saves save = (Saves)bf.Deserialize(fs);
        fs.Close();

        //int i = 0;

        foreach (var enemy in save.EnemiesData)
        {
            //int number = enemy._id;

            Instantiate(_tanks[enemy._id], new Vector3(enemy.Position.x, enemy.Position.y, enemy.Position.z), Quaternion.identity);
            _enemySaves.Add(_tanks[enemy._id]);
        }
    }
}

[System.Serializable]
public class Saves
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct EnemySaveData
    {
        public Vec3 Position;
        public int _id;

        public EnemySaveData(Vec3 position, int id)
        {
            Position = position;
            _id = id;
        }
    }

    public List<EnemySaveData> EnemiesData = new List<EnemySaveData>();

    public void SaveEnemies(List<Tank> enemies)
    {
        foreach (var enemy in enemies)
        {
            //var em = enemy.GetComponent<Tank>();
            Vec3 pos = new Vec3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
            EnemiesData.Add(new EnemySaveData(pos, enemy.GetComponent<Tank>().Level));
        }
    }
}