using UnityEngine;
using System.Collections;

public class UnCheckIsKinematicOnTriggerEnter : MonoBehaviour {

	[SerializeField]
	private Rigidbody _targetRigidbody;

    [SerializeField]
    private Vector3 _force;

    public void OnDrawGizmos()
	{
		if (_targetRigidbody != null)
			Debug.DrawLine(this.transform.position, _targetRigidbody.transform.position, Color.yellow);

        Debug.DrawLine(this.transform.position, this.transform.position + _force / Physics.gravity.magnitude, Color.red);
    }

	public void OnTriggerEnter(Collider col)
	{
		if (_targetRigidbody != null)
		{
			_targetRigidbody.isKinematic = false;
			_targetRigidbody.WakeUp();
		}
        if (col.GetComponent<Rigidbody>() != null)
        {
            col.GetComponent<Rigidbody>().AddForce(_force);
        }
    }
}