using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class Storage : MonoBehaviour
{
    [SerializeField] private Tank[] _tanks;
    [SerializeField] private List<Transform> _positions;
    [SerializeField] private Load _load;

    private List<Tank> _enemySaves = new List<Tank>();
    private string _filePath;
    private float _angle = 135;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
        LoadGame();
    }

    public void Init(List<Transform> transform)
    {
        _positions = transform;
    }

    public void ListChanged()
    {
        _enemySaves = new List<Tank>();

        for (int i = 0; i < _positions.Count; i++)
        {
            if (_positions[i].GetComponent<PositionTank>().Target != null)
                _enemySaves.Add(_positions[i].GetComponent<PositionTank>().Target.GetComponent<Tank>());
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

        foreach (var enemy in save.EnemiesData)
        {
            var tanksss = Instantiate(_tanks[enemy.Id], new Vector3(enemy.Position.X, enemy.Position.Y, enemy.Position.Z), Quaternion.Euler(new Vector3(0, -_angle, 0)));
            int level = _load.Get(_tanks[enemy.Id].GetComponent<DragItem>().TankName, _tanks[enemy.Id].GetComponent<DragItem>().Level);
            tanksss.GetComponent<DragItem>().SetLevel(level);
            _enemySaves.Add(tanksss);
        }
    }
}

[System.Serializable]
public class Saves
{
    [System.Serializable]
    public struct Vec3
    {
        public float X, Y, Z;

        public Vec3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    [System.Serializable]
    public struct EnemySaveData
    {
        public Vec3 Position;
        public int Id;

        public EnemySaveData(Vec3 position, int id)
        {
            Position = position;
            Id = id;
        }
    }

    public List<EnemySaveData> EnemiesData = new List<EnemySaveData>();

    public void SaveEnemies(List<Tank> enemies)
    {
        foreach (var enemy in enemies)
        {
            Vec3 pos = new Vec3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
            EnemiesData.Add(new EnemySaveData(pos, enemy.GetComponent<Tank>().Level));
        }
    }
}