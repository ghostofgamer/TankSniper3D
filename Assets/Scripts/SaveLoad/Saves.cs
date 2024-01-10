using System.Collections.Generic;
using Assets.Scripts.GamePlayer;

namespace Assets.Scripts.SaveLoad
{
    [System.Serializable]
    public class Saves
    {
        public List<TankSaveData> TanksData = new List<TankSaveData>();

        public void SaveEnemies(List<Tank> tanks)
        {
            foreach (Tank tank in tanks)
            {
                Vec3 pos = new Vec3(tank.transform.position.x, tank.transform.position.y, tank.transform.position.z);
                TanksData.Add(new TankSaveData(pos, tank.GetComponent<Tank>().Level));
            }
        }
    }
}