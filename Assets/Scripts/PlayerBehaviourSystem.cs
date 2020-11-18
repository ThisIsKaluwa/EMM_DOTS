using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public class PlayerBehaviourSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float elapsedTime = (float)Time.ElapsedTime;
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        
        Entities.ForEach((ref PlayerComponent playercomp, ref Rotation rot, ref Translation trans) =>
        {

            playercomp.rotationAngle += inputH;
            float3 targetDirection = new float3 (math.sin(playercomp.rotationAngle), 0, math.cos(playercomp.rotationAngle));

            rot.Value = quaternion.LookRotationSafe(targetDirection, new float3(0,1,0));
           
            trans.Value += targetDirection * playercomp.speed *  inputV * elapsedTime;

            // float height = math.sin(elapsedTime);
            // trans.Value = new float3(trans.Value.x, height, trans.Value.z);
        }).Schedule();
    }
}
