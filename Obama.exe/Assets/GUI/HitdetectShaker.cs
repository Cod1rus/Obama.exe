using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitdetectShaker : MonoBehaviour
{
    [SerializeField]
    private bool shakeObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);

            if (rayHit.collider != null)
            {
                Debug.Log("objectHit");
                if (shakeObject)
                {
                    ShakeThisObject(rayHit.collider.gameObject);
                }
            }
        }
    }

    private void ShakeThisObject(GameObject shakeObject)
    {
        shakeObject.GetComponent<Shaker>().ShakeMe();
    }
}
