namespace Assets.Scripts.SaveLoad
{
    [System.Serializable]
    public struct TankSaveData
    {
        public Vec3 Position;
        public int Id;

        public TankSaveData(Vec3 position, int id)
        {
            Position = position;
            Id = id;
        }
    }
}