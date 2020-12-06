using UnityEngine;

public class SpawnPortals : MonoBehaviour
{
	public GameObject Portal1;
	public GameObject Portal2;
	public PlayerScript Player;
	private InputController _inputController;
	private int LastPortalSpawned = 1;
	private bool _isAlreadySpawnPortal = true;
	private void Awake()
	{
		_inputController = FindObjectOfType<InputController>();
	}
	private void FixedUpdate()
	{
		if (_inputController.DragingStarted)
		{
			if (!_isAlreadySpawnPortal)
			{
				Player.CanTeleport = true;
				if (LastPortalSpawned == 1)
				{
					_isAlreadySpawnPortal = true;
					Portal1.transform.position = new Vector3(_inputController.TouchPosition.x + 5, _inputController.TouchPosition.y - 2, 0);
					LastPortalSpawned = 2;
				}
				else if (LastPortalSpawned == 2)
				{
					_isAlreadySpawnPortal = true;
					Portal2.transform.position = new Vector3(_inputController.TouchPosition.x + 5, _inputController.TouchPosition.y - 2, 0);
					LastPortalSpawned = 1;
				}
			}
		}
		else
		{
			_isAlreadySpawnPortal = false;
		}
	}
}
