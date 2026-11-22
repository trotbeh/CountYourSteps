using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public Vector2Int Cell
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y));
        }
    }
}