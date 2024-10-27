using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 offset = new(0, 0, -10);

    private void Update()
    {
        transform.position = _target.position + offset;
    }
}
