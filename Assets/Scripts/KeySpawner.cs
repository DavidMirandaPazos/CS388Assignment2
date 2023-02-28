using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Door doorReference;
    public GameObject keyPrefab;
    public List<Transform> possiblePositions;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, possiblePositions.Count - 1);
        GameObject go = Instantiate( keyPrefab, possiblePositions[randomIndex].position, Quaternion.identity);
        go.GetComponent<PickUpKey>().doorReference = doorReference;
    }
}
