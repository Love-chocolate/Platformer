using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardController : MonoBehaviour
{
    [SerializeField] private GameObject corePrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bombard;

    private float playerAndBombardDistance;

    private void Update()
    {
        CheckDistance();

        if(playerAndBombardDistance < 0.5f && Input.GetKeyDown(KeyCode.E))
        {
            GameObject core = Instantiate(corePrefab);
            StartCoroutine(DestroyExplosionPrefab(core));
        }
    }

    private void CheckDistance()
    {
        playerAndBombardDistance = Vector3.Distance(player.transform.position, bombard.transform.position);
    }

    private IEnumerator DestroyExplosionPrefab(GameObject core)
    {
        yield return new WaitForSeconds(1);
        Destroy(core);
    }
}
