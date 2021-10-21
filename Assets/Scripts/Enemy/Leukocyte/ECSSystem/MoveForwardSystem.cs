using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Transforms
{
    public class MoveForwardSystem : JobComponentSystem
    {
        [BurstCompile]
        [RequireComponentTag(typeof(MoveForward))]
        struct MoveForwardRotation : IJobForEach<Translation, Rotation, MoveSpeed>
        {
            public float dt;

            public void Execute(ref Translation pos, [ReadOnly] ref Rotation rot, [ReadOnly] ref MoveSpeed speed)
            {
                pos.Value = pos.Value + (dt * speed.Value * math.forward(rot.Value));
            }

            /*public void Execute(ref Translation c0, ref Rotation c1, ref MoveForward c2)
            {
                throw new System.NotImplementedException();
            }*/

            public MoveForwardRotation(float dt)
            {
                this.dt = dt;
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var moveForwardRotationJob = new MoveForwardRotation(Time.DeltaTime);

            //moveForwardRotationJob.dt = Time.DeltaTime;


            return moveForwardRotationJob.Schedule(this, inputDeps);
            //throw new System.NotImplementedException();
        }
    }
}
