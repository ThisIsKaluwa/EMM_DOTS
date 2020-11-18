using Unity.Entities;
using Unity.Transforms;
using System;
using UnityEngine;
using UnityEngine.Rendering;
public class SpawnCollectableSystem : SystemBase
{

    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;


    protected override void OnCreate()
    {

        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((ref SpawnCollectableComponent spawnComponent) =>
                {
                    int seed = new System.Random().Next();
                    Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)seed);


                    for (int i = 0; i <= spawnComponent.amount; i++)
                    {
                        Vector3 randomPos = new Vector3(random.NextFloat(-500, 500), 2, random.NextFloat(-500, 500));

                        Entity entityInstance = commandBuffer.Instantiate(i, spawnComponent.prefab);

                    }


                }).Schedule();


    }


    protected override void OnUpdate()
    {

        Entities.ForEach((ref SpawnCollectableComponent spawn, ref Rotation rot, ref Translation trans) =>
       {


       }).Schedule();
    }
}
