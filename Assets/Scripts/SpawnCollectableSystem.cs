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
        

    }


    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((Entity entity, int entityInQueryIndex, in SpawnCollectableComponent spawnComponent) =>
                {
                    int seed = 5;
                    Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)seed);

                    for (int i = 0; i <= spawnComponent.amount; i++)
                    {
                        Vector3 randomPos = new Vector3(random.NextFloat(-500, 500), 2, random.NextFloat(-500, 500));

                        Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, spawnComponent.prefab);

                        commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Translation { Value = randomPos });
                        commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Rotation { });
                        commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new CollectedComponent { isCollected = false });

                    }

                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);
                }).Schedule();

        
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);

    }
}
