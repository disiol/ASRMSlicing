using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LayerCutting : MonoBehaviour
{
    [SerializeField] private GameObject knife; // Reference to the knife object
    [SerializeField] private GameObject objectToCut; // Reference to the object being cut
    [SerializeField] private float knifeSpeed;

    private bool isCutting; // Flag to indicate if the player is cutting
    private Vector3 _knifeTransformPosition;
    private bool _isObjectStopped;

    private void Start()
    {
        _knifeTransformPosition = knife.transform.position;
        _isObjectStopped = objectToCut.GetComponent<CupMovement>().isObjectStopped;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectToCut.GetComponent<CupMovement>().isObjectStopped = true;
            _isObjectStopped = objectToCut.GetComponent<CupMovement>().isObjectStopped;


            isCutting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isObjectStopped = objectToCut.GetComponent<CupMovement>().isObjectStopped;

            isCutting = false;

            //TODO  Якщо гравець різко піднімає палець з екрану — шар залишається недорізаним, а об’єкт стоїть на місці.
            objectToCut.GetComponent<CupMovement>().isObjectStopped = false;
            _isObjectStopped = objectToCut.GetComponent<CupMovement>().isObjectStopped;
        }

        if (isCutting)
        {
            _knifeTransformPosition -= new Vector3(0, knifeSpeed * Time.deltaTime, 0);
        }
        else if (_isObjectStopped)
        {
            // Code to make the object stop moving
            // You can freeze its position, stop its velocity, etc.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == knife && isCutting)
        {
            // Code to cut off the layer here
            // This could involve removing a portion of the object, wrapping the layer, etc.
        }
    }
}