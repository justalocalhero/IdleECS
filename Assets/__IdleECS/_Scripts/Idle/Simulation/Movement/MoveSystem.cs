using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace IdleECS
{
    public class MoveSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float dt = Time.DeltaTime;

            Entities.ForEach((ref Velocity velocity, ref Translation translation) =>
            {
                translation.Value += dt * velocity.value;
            });
        }
    }
}