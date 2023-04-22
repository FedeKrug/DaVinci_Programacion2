using System.Collections.Generic;
using UnityEngine;
using Game.Cameras;

public class InteractableTrigger : MonoBehaviour
{
    [SerializeField] private List<CameraChanger> _cameraChangerList = new List<CameraChanger>();

	private void OnTriggerEnter(Collider other)
	{
        var cameraChanger = other.GetComponent<CameraChanger>();
        if (cameraChanger == null) return;
        _cameraChangerList.Add(cameraChanger);
	}
	private void OnTriggerExit(Collider other)
	{
        var cameraChanger = other.GetComponent<CameraChanger>();
        if (cameraChanger == null) return;
        _cameraChangerList.Remove(cameraChanger);
    }
    public void Interact()
	{
        if (_cameraChangerList.Count <= 0) return;
        _cameraChangerList[_cameraChangerList.Count - 1].ChangeCamera();
	}

}