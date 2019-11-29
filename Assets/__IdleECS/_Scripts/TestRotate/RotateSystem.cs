using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace RotateCube
{
    public class RotateSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Rotate rotate, ref Rotation rotation) =>
            {
                rotation = new Rotation { 
                    Value = math.mul(
                        math.normalizesafe(rotation.Value), 
                        quaternion.AxisAngle(math.up(), rotate.radiansPerSecond * deltaTime)
                    )
                };
            });
        }
    }
}