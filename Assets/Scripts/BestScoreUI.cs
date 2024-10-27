using TMPro;
using UnityEngine;

public class BestScoreUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(Scorer.BestScore) && PlayerPrefs.HasKey(Scorer.BestTime))
            _text.text = $"Лучший результат: {PlayerPrefs.GetFloat(Scorer.BestScore)}\nЛучшее время: {PlayerPrefs.GetFloat(Scorer.BestTime)}";
    }

}
