using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.GamePlayer;
using Assets.Scripts.MergeTanks;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    public class Storage : MonoBehaviour
    {
        [SerializeField] private Tank[] _tanks;
        [SerializeField] private List<Transform> _positions;
        [SerializeField] private Load _load;

        private List<Tank> _tanksSaves = new List<Tank>();
        private string _filePath;
        private float _angle = 135;

        private void Start()
        {
            _filePath = Application.persistentDataPath + "/save.gamesave";
            LoadGame();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        public void Init(List<Transform> transform)
        {
            _positions = transform;
        }

        public void ListChanged()
        {
            _tanksSaves = new List<Tank>();

            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i].GetComponent<PositionTank>().Target != null)
                    _tanksSaves.Add(_positions[i].GetComponent<PositionTank>().Target.GetComponent<Tank>());
            }

            SaveGame();
        }

        public void AddTank(Tank tank)
        {
            _tanksSaves.Add(tank);
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
            save.SaveEnemies(_tanksSaves);
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

            foreach (var tank in save.TanksData)
            {
                var newTank = Instantiate(_tanks[tank.Id], new Vector3(tank.Position.X, tank.Position.Y, tank.Position.Z), Quaternion.Euler(new Vector3(0, -_angle, 0)));
                int level = _load.Get(_tanks[tank.Id].GetComponent<DragItem>().TankName, _tanks[tank.Id].GetComponent<DragItem>().Level);
                newTank.GetComponent<DragItem>().SetLevel(level);
                _tanksSaves.Add(newTank);
            }
        }
    }
}