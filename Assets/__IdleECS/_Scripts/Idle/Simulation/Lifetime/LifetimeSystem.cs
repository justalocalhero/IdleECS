using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace IdleECS
{
    public class ExpirationSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float dt = Time.DeltaTime;

            Entities.ForEach((Entity entity, ref Lifetime lifetime) =>
            {
                lifetime.value -= dt;
                
                if(lifetime.value <= 0)
                    PostUpdateCommands.DestroyEntity(entity);
            });
        }
    }
}