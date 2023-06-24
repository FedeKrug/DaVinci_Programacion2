
using UnityEngine;

public class PlayerModifiedJump : MonoBehaviour
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
	[SerializeField] private Ray _raycast;
	[SerializeField] private float _rayDistance;
	[SerializeField] private float _offset;
 

	private void Update()
	{
		//CheckFloorDistance(_rayDistance);
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
		_anim.SetBool(_fallingDownParameter, true);
		_onFloor = false;
	}
	public void CheckFloorDistance(float distance)
	{
		Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y +_offset, transform.position.z), -transform.up );
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
		if (Physics.Raycast(_raycast, out hit, distance))
		{
			_anim.SetBool(_fallingDownParameter, false);
		}
		else
		{
			return;
		}
	}

	public void LandOnFloor()
	{
		_anim.SetBool(_animParameter, true);
		_anim.ResetTrigger(_jumpParameter);
		_onFloor = true;
	}
}