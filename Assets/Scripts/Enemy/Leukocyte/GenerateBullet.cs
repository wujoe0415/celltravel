//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;

public class GenerateBullet : MonoBehaviour
{
    
    EntityManager manager;
    Entity bulletEntityPrefab;

    public GameObject shot;
    // Start is called before the first frame update
    public Transform shotSpawn;
    public int spreadAmount;
    
    void Start()
    {

        manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var _blobStore = new BlobAssetStore();
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _blobStore);
        bulletEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(shot, settings);

        _blobStore.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("right");
            Vector3 rotation = shotSpawn.rotation.eulerAngles;
            rotation.x = 0.0f;
            SpawnBulletESC(rotation);
        }
    }

    void SpawnBulletESC(Vector3 rotation)
    {
        Debug.Log("in");
        int max = spreadAmount / 2;
        int min = -1 * max;
        int totalAmount = spreadAmount;

        Vector3 tempRote = rotation;
        int index = 0;

        NativeArray<Entity> Bullets = new NativeArray<Entity>(totalAmount,Allocator.TempJob);
        manager.Instantiate(bulletEntityPrefab, Bullets);
        Debug.Log(bulletEntityPrefab);

        for(int y = min; y < max ; y++ )
        {
            tempRote.y = (rotation.y + y * 3) % 360;

            manager.SetComponentData(Bullets[index], new Translation { Value = shotSpawn.position });
            manager.SetComponentData(Bullets[index], new Rotation { Value = Quaternion.Euler(tempRote) });

            index++;
        }
        Debug.Log("out");
        Bullets.Dispose();
    }
}
