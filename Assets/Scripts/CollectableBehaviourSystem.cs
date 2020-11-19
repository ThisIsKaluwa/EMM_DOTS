using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public class CollectableBehaviourSystem : SystemBase
{
    protected override void OnUpdate()
    {
        double time = math.sin(Time.ElapsedTime);
        

        Entities.ForEach((ref CollectedComponent collectedComp, ref Rotation rot) =>
        {
            rot.Value = Quaternion.Euler(0, (float) (50*time) , 0);
            
        }).Schedule();
    }
}