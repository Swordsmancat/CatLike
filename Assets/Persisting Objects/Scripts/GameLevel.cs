using UnityEngine;

public class GameLevel : PersistableObject
{
    [SerializeField]
    private SpawnZone spawnZone;

    [SerializeField]
    PersistableObject[] persistableObjects;

    public static GameLevel Current { get; private set; }



    private void OnEnable()
    {
        Current = this;
        if(persistableObjects == null)
        {
            persistableObjects = new PersistableObject[0];
        }
    }

  
    public void ConfigureSpawn(Shape shape)
    {
        spawnZone.ConfigureSpawn(shape);
    }

    public override void Save(GameDataWriter writer)
    {
        writer.Write(persistableObjects.Length);
        for (int i = 0; i < persistableObjects.Length; i++)
        {
            persistableObjects[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader)
    {
        int saveCount = reader.ReadInt();
        for (int i = 0; i < saveCount; i++)
        {
            persistableObjects[i].Load(reader);
        }
    }

    //private void Start()
    //{
    //    Game.Instance.spawnZoneOfLevel = spawnZone;//
    //}
}

