using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LeukocyteBullet : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;
    public float lifeTime;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent(entity, typeof(MoveForward));
        MoveSpeed movespeed = new MoveSpeed { Value = speed };
        dstManager.AddComponentData(entity,movespeed);
        TimeToLive timetolive = new TimeToLive { Value = lifeTime };
    }

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
