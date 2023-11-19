using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class SaveSystem : MonoBehaviour
{
    string filePath;

    public List<Tank> EnemySaves = new List<Tank>();
    public Tank[] _tanks;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
        LoadGame();
    }

    public void AddTank(Tank tank)
    {
        EnemySaves.Add(tank);
    }

    private void Update()
    {
        //GameObject[] go = GameObject.FindGameObjectsWithTag("MyTag");




        Tank[] go = GameObject.FindObjectsOfType<Tank>();
        //Debug.Log(go.Length);
        EnemySaves = new List<Tank>();
        for (int i = 0; i < go.Length; i++)
            EnemySaves.Add(go[i]);





        //Tank[] objects = FindObjectOfType<Tank>();
        //Filter();
    }

    public void Filter()
    {
        var filter = EnemySaves.Where(p => p.gameObject.activeSelf == true).ToList();
        Debug.Log(filter.Count);
        EnemySaves = filter;
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
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Saves save = new Saves();
        save.SaveEnemies(EnemySaves);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Saves save = (Saves)bf.Deserialize(fs);
        fs.Close();

        int i = 0;

        foreach (var enemy in save.EnemiesData)
        {
            Debug.Log("колличество " + save.EnemiesData.Count);
            int number = enemy._id;
            Debug.Log("ID" + enemy._id);

            switch (number)
            {
                case 0:
                    Instantiate(_tanks[0], new Vector3(enemy.Position.x,enemy.Position.y,enemy.Position.z),Quaternion.identity);
                    EnemySaves.Add(_tanks[0]);
                    //_tanks[0].GetComponent<Tank>().LoadData(enemy);
                    //i++;

                    Debug.Log(_tanks[0].transform.position.x + " " + _tanks[0].transform.position.y + " " + _tanks[0].transform.position.z);
                    Debug.Log("1");
                    break;

                case 1:
                    Instantiate(_tanks[1], new Vector3(enemy.Position.x, enemy.Position.y, enemy.Position.z), Quaternion.identity);
                    EnemySaves.Add(_tanks[1]);
                    //_tanks[1].GetComponent<Tank>().LoadData(enemy);
                    //i++;
                    Debug.Log(_tanks[1].transform.position.x + " " + _tanks[1].transform.position.y + " " + _tanks[1].transform.position.z);
                    Debug.Log("2");
                    break;

                case 2:
                    Instantiate(_tanks[2], new Vector3(enemy.Position.x, enemy.Position.y, enemy.Position.z), Quaternion.identity);
                    EnemySaves.Add(_tanks[2]);
                    //_tanks[2].GetComponent<Tank>().LoadData(enemy);
                    Debug.Log(_tanks[2].transform.position.x + " " + _tanks[2].transform.position.y + " " + _tanks[2].transform.position.z);
                    Debug.Log("3");
                    //i++;
                    break;
            }

            //EnemySaves[i].GetComponent<Tank>().LoadData(enemy);
            //i++;
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
            EnemiesData.Add(new EnemySaveData(pos, enemy.GetComponent<Tank>().Id));
            Debug.Log(enemy.transform.position.x + " " + enemy.transform.position.y + " " + enemy.transform.position.z);
            Debug.Log(enemy.Id);
        }
    }
}