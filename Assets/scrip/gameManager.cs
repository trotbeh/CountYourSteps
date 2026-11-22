using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Sahne referanslari")]
    public PlayeYurume player;
    public adımSay counter;
    public PortalTrigger portal;

    [Header("Kazanma sahnesi")]
    public string winSceneName = "Kazandin";

    public bool IsOver { get; private set; }
    public bool Won { get; private set; }

    void OnEnable()
    {
        if (player != null) player.Moved += HandleMove;
    }

    void OnDisable()
    {
        if (player != null) player.Moved -= HandleMove;
    }

    // Karakter her kare degistirdiginde buraya gelir
    void HandleMove(Vector2Int cell)
    {
        if (IsOver) return;

        counter.SpendStep();

        // Henuz adim kaldiysa devam
        if (counter.StepsLeft > 0) return;

        // Adim bitti: portalda miyiz?
        bool onPortal = portal != null && portal.Cell == cell;

        if (onPortal) Win();
        else Lose();
    }

    void Win()
    {
        IsOver = true;
        Won = true;
        if (player != null) player.canMove = false;
        SceneManager.LoadScene(winSceneName);
    }

    void Lose()
    {
        IsOver = true;
        Won = false;
        if (player != null) player.canMove = false;
    }

    void Update()
    {
        // Kaybettiysek Space ile sahneyi bastan baslat
        if (IsOver && !Won && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}