using UnityEngine;

public class PlayerPositioning : MonoBehaviour
{
    [SerializeField]

    private Transform player;

    [SerializeField]

    private Transform startingPosition;

    public void  SetPlayerPosition()
    {
        player.position = startingPosition.position;
        Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();
        playerRigidBody.linearVelocity = Vector3.zero;
        playerRigidBody.angularVelocity = Vector3.zero;
    }
}
