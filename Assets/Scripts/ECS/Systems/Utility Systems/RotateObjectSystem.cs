
using UnityEngine;
using Unity.Entities;

public class RotateObjectSystem : ComponentSystem
{

    struct Data
    {
        public int Length;
        public ComponentArray<Rotate> rotate;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            var transform = data.rotate[i].transform;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + data.rotate[i].RotateSpeed * Time.deltaTime);
        }
    }
}
