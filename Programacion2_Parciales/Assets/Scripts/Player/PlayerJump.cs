
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] private float _jumpForce;
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private KeyCode _jumpKey;
	[SerializeField] private bool _onFloor = true;

	[Space(10)]
	[Header("Animations")]
	[SerializeField] private string _animParameter;
	[SerializeField] private string _jumpParameter;
	[SerializeField] private string _fallingDownParameter;
	[SerializeField] private Animator _anim;

	[Header("Modified Variables")]
	[SerializeField] private float _offset;

	private void Update()
	{
		if (Input.GetKeyDown(_jumpKey) && _onFloor)
		{
			Jump();
		}
	}

	public void Jump()
	{
		_rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
		_anim.SetTrigger(_jumpParameter);
		_anim.SetBool(_animParameter, false);
		_onFloor = false;
	}
	public void CheckFloorDistance(float distance)
	{
		Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + _offset, transform.position.z), -transform.up);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); //Para cambiar la distancia de aterrizaje, se hace desde el animation event de OnAir, en ambos frames de la animacion. 
		if (Physics.Raycast(ray, out hit, distance))
		{
			if (hit.collider.CompareTag("Floor"))
			{
				Debug.Log("Player on floor");
			}
				LandOnFloor();

		}
	}
	public void FallingDownAnimParameter()
	{
		_anim.SetBool(_fallingDownParameter, true);

	}
	public void LandOnFloor()
	{
		_anim.SetBool(_fallingDownParameter, false);
		_anim.SetBool(_animParameter, true);
		_anim.ResetTrigger(_jumpParameter);
		_onFloor = true;
	}
}