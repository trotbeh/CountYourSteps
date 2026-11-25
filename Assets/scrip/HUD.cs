using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public adımSay counter;
    public TMP_Text stepsText;

    void OnEnable()
    {
        if (counter != null) counter.Changed += OnStepsChanged;
    }

    void OnDisable()
    {
        if (counter != null) counter.Changed -= OnStepsChanged;
    }

    void Start()
    {
        if (counter != null) OnStepsChanged(counter.StepsLeft);
    }

    void OnStepsChanged(int value)
    {
        if (stepsText != null) stepsText.text = "   " + value;
    }
}