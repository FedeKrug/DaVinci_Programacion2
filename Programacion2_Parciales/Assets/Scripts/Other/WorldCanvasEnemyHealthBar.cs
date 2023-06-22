using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WorldCanvasEnemyHealthBar : MonoBehaviour
{
	//HealthBar behaviours
	[Header("Camera")]
	[SerializeField] private Camera _cam;
	[Header("UI Elements")]
	[SerializeField] private Image _parentHealthBar;
	[SerializeField] private Image _healthBar;



	private void Start()
	{
		_cam = Camera.main;
	}
	private void LateUpdate()
	{
		transform.LookAt(_cam.transform.position);
	}
	public void UpdateEnemyHealthBar(float health, float maxHealth)
	{
		_healthBar.fillAmount = health / maxHealth;
	}
}
