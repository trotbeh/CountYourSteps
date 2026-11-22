using System;
using UnityEngine;

public class adımSay : MonoBehaviour
{
    [Header("Baslangic adim sayisi")]
    public int startSteps = 10;

    public int StepsLeft { get; private set; }

    // Sayi her degistiginde haber verir (HUD bunu dinleyecek)
    public event Action<int> Changed;

    // Sayi 0'a dustugunde haber verir
    public event Action Emptied;

    void Start()
    {
        ResetCounter();
    }

    public void ResetCounter()
    {
        StepsLeft = startSteps;
        Changed?.Invoke(StepsLeft);
    }

    public void SpendStep()
    {
        if (StepsLeft <= 0) return;

        StepsLeft--;
        Changed?.Invoke(StepsLeft);

        if (StepsLeft == 0) Emptied?.Invoke();
    }
}