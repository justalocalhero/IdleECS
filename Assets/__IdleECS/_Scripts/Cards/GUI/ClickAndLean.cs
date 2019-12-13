using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndLean : MonoBehaviour
{
	private Vector3 eulerRotation;
    public float yMag = 15;
		
	void OnMouseDown()
    {
        eulerRotation = transform.rotation.eulerAngles;
    }
		
	void OnMouseDrag()
    {
        float mouseX = Input.GetAxis("Mouse X");

		transform.rotation = Quaternion.Euler(new Vector3(
            x: eulerRotation.x,
            y: eulerRotation.y + (mouseX * yMag),
            z: eulerRotation.z
        ));
	}

    void OnMouseUp()
    {
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
