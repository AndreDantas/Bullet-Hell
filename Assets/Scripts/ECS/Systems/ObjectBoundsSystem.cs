
using Unity.Entities;
[UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.Update))]
public class ObjectBoundsSystem : ComponentSystem
{
    struct Data
    {
        public int Length;
        public ComponentArray<ObjectBounds> bounds;
    }

    [Inject] private Data data;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data.bounds[i].transform.position = data.bounds[i].transform.position.ClampToBounds(data.bounds[i].bounds);
        }
    }
}
