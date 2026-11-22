using UnityEngine;

public class PortalTrigger : MonoBehaviour
{

    public float cellSize = 32f;
    
    public Vector2Int Cell
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / cellSize),
                Mathf.RoundToInt(transform.position.y / cellSize));
        }
    }
}