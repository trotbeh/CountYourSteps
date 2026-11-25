using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayeYurume : MonoBehaviour
{
    [Header("Kare Boyutu (dunyanin olcegi)" )]
    public float cellSize = 32f;
    [Header("Oda sinirlari")]
    public int minX = -6;
    public int maxX = 3;
    public int minY = -5;
    public int maxY = 4;
    public PortalTrigger portal;
    public adımSay counter;

    [Header("Animasyon")]
    public Animator anim;

    [Header("Hareket")]
    public float moveDuration = 0.3f;

    public bool canMove = true;
    public Vector2Int Cell { get; private set; }
    public event Action<Vector2Int> Moved;

    bool moving;
    Vector3 targetPos;

    void Start()
    {
    
    
        Cell = WorldToCell(transform.position);
        Snap();

        
        if (anim != null) anim.Play("asagiRun", 0, 1f);
    }

    void Update()
    {
        
        if (moving)
        {
            float speed = cellSize / Mathf.Max(0.01f, moveDuration);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if ((transform.position - targetPos).sqrMagnitude < 0.0001f)
            {
                transform.position = targetPos;
                moving = false;
            }
            return;
        }

        if (!canMove) return;

        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector2Int.up;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector2Int.down;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector2Int.left;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector2Int.right;

        if (dir == Vector2Int.zero) return;
        Vector2Int hedef = Cell + dir;
        if (portal != null && counter != null && hedef == portal.Cell && counter.StepsLeft > 1)
           return;

        TryMove(dir);
    }

    void TryMove(Vector2Int dir)
    {
        
        Vector2Int next = Cell + dir;


        if (portal != null && counter != null && next == portal.Cell)
        {
            if (counter.StepsLeft > 1) return;
            if (portal.butonGerekli && !portal.acik) return;

        }
      
        if (next.x < minX || next.x > maxX || next.y < minY || next.y > maxY) return;

        Cell = next;
        targetPos = CellToWorld(Cell);
        moving = true;

        PlayRun(dir);
        Moved?.Invoke(Cell);
    }

    void PlayRun(Vector2Int dir)
    {
        if (anim == null) return;

        if (dir == Vector2Int.up) anim.Play("yukariRun", 0, 0f);
        else if (dir == Vector2Int.down) anim.Play("asagiRun", 0, 0f);
        else if (dir == Vector2Int.left) anim.Play("solRun", 0, 0f);
        else if (dir == Vector2Int.right) anim.Play("sagRun", 0, 0f);
    }
    Vector3 CellToWorld(Vector2Int cell)
    {
        return new Vector3(cell.x * cellSize, cell.y * cellSize, transform.position.z);

    }

    Vector2Int WorldToCell(Vector3 pos)
    {
        return new Vector2Int(Mathf.RoundToInt(pos.x / cellSize) , Mathf.RoundToInt(pos.y / cellSize));
     
    }

    void Snap()
    {
        transform.position = CellToWorld(Cell);
        targetPos = transform.position;
    }
}