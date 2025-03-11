using UnityEngine;

public class PlayerPositioning : MonoBehaviour
{
    [SerializeField]

    private Transform player;

    [SerializeField]

    private Transform startingPosition;

    public void SetPlayerPosition()
    {
        player.position = startingPosition.position;
    }
}
