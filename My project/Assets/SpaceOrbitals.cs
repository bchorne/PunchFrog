using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceOrbitals : MonoBehaviour
{
    private List<GameObject> orbitals = new List<GameObject>();
    public GameObject sawPrefab;

    public GameObject player;
    public float radius;
    public int sawDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddOrbital();
        }

        transform.position = player.transform.position;
    }

    public void AddOrbital()
    {
        GameObject saw = Instantiate(sawPrefab, transform);
        saw.transform.SetParent(transform, false);
        orbitals.Add(saw);
        saw.GetComponent<saw>().dmg = sawDamage;

        RecalcPos();
    }

    private void RecalcPos()
    {
        for (int i = 0; i < orbitals.Count; i++)
        {
            float theta = (2 * Mathf.PI / orbitals.Count) * i;

            float x = Mathf.Cos(theta) * radius;
            float y = Mathf.Sin(theta) * radius;

            orbitals[i].transform.position = new Vector3(x, y, -2);
        }
    }
}
