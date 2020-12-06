using UnityEngine;

public class CrateTeleportPoint : MonoBehaviour
{
	public GameObject TeleportSiluet;
	public Transform Player;
	public GameObject Particles;

	private InputController _inputController;
	private Vector3 TeleportPoint;
	private bool _startingSelectingTeleportPoint;





	//public float YDelay;
	//[SerializeField] private Transform _playerTransform;
	[SerializeField] private Vector3 _delay;
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private Vector3 _screenWall;
	[SerializeField] private Vector2 _minScreenPosition, _maxScreenPosition;
	[SerializeField] private bool _delayCounted;



	private void Awake()
	{
		_inputController = FindObjectOfType<InputController>();
	}
	private void fixedUpdate()
	{
		if (_inputController.DragingStarted)
		{
			if (!_startingSelectingTeleportPoint)
			{
				TeleportSiluet.SetActive(true);
				_startingSelectingTeleportPoint = true;
			}
			TeleportPoint = new Vector3(_inputController.TouchPosition.x + 5, _inputController.TouchPosition.y - 1, 0);
			TeleportSiluet.transform.position = TeleportPoint;
		}
		else
		{
			if (_startingSelectingTeleportPoint)
			{
				TeleportSiluet.SetActive(false);
				Instantiate(Particles, Player.position, Quaternion.identity);
				Player.position = TeleportPoint;
				Instantiate(Particles, TeleportPoint, Quaternion.identity);
				_startingSelectingTeleportPoint = false;
			}
		}
	}
	private void Update()
	{
		if (_inputController.DragingStarted)
		{
			if (!_delayCounted)
			{
				_delay = _inputController.TouchPosition;
				TeleportSiluet.SetActive(true);
				TeleportSiluet.transform.position = Player.position;
				_startPosition = Player.position;
				_startingSelectingTeleportPoint = true;
				_delayCounted = true;
			}
			TeleportSiluet.transform.position = new Vector3((_startPosition.x + _inputController.TouchPosition.x - _delay.x) * 1.0f, (_startPosition.y + _inputController.TouchPosition.y - _delay.y) * 1.0f, 0);
		}
		else
		{
			if (_delayCounted)
			{
				Instantiate(Particles, Player.position, Quaternion.identity);
				Player.position = TeleportSiluet.transform.position;
				Instantiate(Particles, TeleportSiluet.transform.position, Quaternion.identity);
				TeleportSiluet.SetActive(false);
				_startingSelectingTeleportPoint = false;
			}
			_delayCounted = false;
		}
		//ограничение экрана
		_screenWall.x = Mathf.Clamp(transform.position.x, _minScreenPosition.x, _maxScreenPosition.x);
		_screenWall.y = Mathf.Clamp(transform.position.y, _minScreenPosition.y, _maxScreenPosition.y);
		transform.position = _screenWall;
	}
}
