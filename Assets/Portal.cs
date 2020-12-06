using UnityEngine;

public class Portal : MonoBehaviour
{
    public int PortalNum;
    public Transform AnotherPortal;
    public PlayerScript Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Player.CanTeleport)
        {
            Player.CanTeleport = false;
            other.transform.position = AnotherPortal.transform.position;
        }
    }
}
