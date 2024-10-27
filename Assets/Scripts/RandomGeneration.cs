using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] _variants;
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    public Transform LeftEdge => _leftEdge;
    public Transform RightEdge => _rightEdge;

    private Transform _gridParent;

    private bool generated = false;

    private void Awake()
    {
        _gridParent = transform.parent.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GenerateNextRandom();
    }

    private void GenerateNextRandom()
    {
        if (generated) return;
        var count = _variants.Length;
        var index = Random.Range(0, count);
        var gameObject = Instantiate(_variants[index], _gridParent);
        var next = gameObject.GetComponent<RandomGeneration>();
        var distance = (_rightEdge.position.x - transform.position.x) + (next.transform.position.x - next.LeftEdge.position.x);
        gameObject.transform.position = transform.position + Vector3.right * distance;
        generated = true;
    }
}
