using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Scorer scorer;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _text.text = $"Ваш результат: {scorer.Score}\nВаше время: {scorer.Time}";
    }

}
