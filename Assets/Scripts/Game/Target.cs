using System;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public bool isDecoy;
    Vector3 targetPosition;
    private float Timer;

    private void OnEnable()
    {
        if (Random.value > 0.5f)
        {
            isDecoy = true;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        transform.position = new Vector3(0, -1, 0);
    }

    private void Update()
    {
        if (Timer < 0)
        {
            targetPosition = new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0);
            Timer = Random.Range(1f, 2f);
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        Timer -= Time.deltaTime;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Crosshair")) this.enabled = false;
    }
    private void OnDisable()
    {
        if (isDecoy)
        {
            GameplayManager.Instance.InvertPenalty();
        }
        else GameplayManager.Instance.DuckHit();
    }
}
