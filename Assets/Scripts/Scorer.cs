using UnityEngine;

public class Scorer : MonoBehaviour
{
    public const string BestScore = nameof(BestScore);
    public const string BestTime = nameof(BestTime);

    
    private float _score = 0;
    private float _time = 0;
    private float _lastX = 0;
    private float _startX = 0;

    public float Score => _score;
    public float Time => _time;

    private void Awake()
    {
        _startX = transform.position.x;
    }

    private void OnEnable()
    {
        GetComponent<DeathControl>().OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        GetComponent<DeathControl>().OnDeath -= OnDeath;
    }

    private void Update()
    {
        _time += UnityEngine.Time.deltaTime;
        
        if (_lastX < transform.position.x)
        {
            _lastX = transform.position.x;
            _score = transform.position.x - _startX;
        }
    }

    private void OnDeath()
    {
        if ((PlayerPrefs.HasKey(BestScore) && PlayerPrefs.GetFloat(BestScore) < _score) || !PlayerPrefs.HasKey(BestScore)) PlayerPrefs.SetFloat(BestScore, _score);
        if ((PlayerPrefs.HasKey(BestTime) && PlayerPrefs.GetFloat(BestTime) < _time) || !PlayerPrefs.HasKey(BestTime)) PlayerPrefs.SetFloat(BestTime, _time);
        PlayerPrefs.Save();
        
        enabled = false;
    }
}
