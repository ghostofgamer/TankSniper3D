using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class Storage : MonoBehaviour
{
    [SerializeField] private Tank[] _tanks;
    //[SerializeField] private PositionTank[] _positionTank;
    [SerializeField] private List<Transform> _positionsss;

    //[SerializeField] private Transform[] _positionsList;
    [SerializeField] private Load _load;
    private List<PositionTank> _positions;
    //private List<Transform> _pos;

    private List<Tank> _enemySaves = new List<Tank>();
    private string _filePath;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
        LoadGame();
    }

    public void Init(List<Transform> transform)
    {
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Debug.Log(transform.childCount);

        //    _positions.Add(transform.GetChild(i).GetComponent<PositionTank>());
        //}
        _positionsss = transform;
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

        //for (int i = 0; i < _positionTank.Length; i++)
        //{
        //    if (_positionTank[i].Target != null)
        //        _enemySaves.Add(_positionTank[i].Target.GetComponent<Tank>());
        //}

        for (int i = 0; i < _positionsss.Count; i++)
        {
            if (_positionsss[i].GetComponent<PositionTank>().Target != null)
                _enemySaves.Add(_positionsss[i].GetComponent<PositionTank>().Target.GetComponent<Tank>());
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

            var tanksss = Instantiate(_tanks[enemy._id], new Vector3(enemy.Position.x, enemy.Position.y, enemy.Position.z), Quaternion.Euler(/*_tanks[enemy._id].transform.position*/  new Vector3(0, -135, 0)));
            int level = _load.Get(_tanks[enemy._id].GetComponent<DragItem>().TankName, _tanks[enemy._id].GetComponent<DragItem>().Level);
            tanksss.GetComponent<DragItem>().SetLevel(level);
            //tank.transform.rotation = new Vector3(0, 0, 0); 
            _enemySaves.Add(tanksss);
            //_enemySaves.Add(_tanks[enemy._id]);
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