using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCar : MonoBehaviour
{
    public float yOffset;
    public float delay;

    private List<GameObject> carChildren = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            StartCoroutine(Delay());
        }
    }

    private void PlaceCar()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

        Vector3 _carPosition = gameObject.transform.position;
        _carPosition.y += yOffset;
        gameObject.transform.position = _carPosition;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);

        PlaceCar();
    }       
}
