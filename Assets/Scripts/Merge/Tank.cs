using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int _id;

    public int Id => _id; 

    //    public void Save()
    //    {
    //        SaveSystem.SaveTank(this);
    //    }

    //    public void Load()
    //    {
    //        TankData data =  SaveSystem.LoadTank();

    //        Vector3 position;
    //        position.x = data.transform.position[0];
    //        position.y = data.transform.position[1];
    //        position.z = data.transform.position[2];
    //        transform.position = position;
    //    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(1, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-1, 0, 0);
    }

    public void LoadData(Saves.EnemySaveData save)
    {
        transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
    }
}
