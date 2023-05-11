using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour //TODO: implementar una interfaz hittable que tenga una función TakeDamage();
{
    [SerializeField] private MeshRenderer _myMesh;
    [SerializeField] private Color _hitColor = Color.red;

    private Material _myMat;
    private Color _ogColor;
    private bool _isHit;

    private void Start()
    {
        _myMat = _myMesh.material;
        _ogColor = _myMat.color;

    }
    private IEnumerator CO_TakeDamage()
    {
        _isHit = !_isHit;
        yield return null;
    }
}
