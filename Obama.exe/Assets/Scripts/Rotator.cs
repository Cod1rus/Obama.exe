using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private bool X_Achse;
    [SerializeField]
    private bool Y_Achse;
    [SerializeField]
    private bool Z_Achse;

    public float m_drehsbeve = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (X_Achse)
        {
            this.transform.rotation *= Quaternion.Euler(Time.deltaTime * m_drehsbeve, 0, 0);
        }

        if (Y_Achse)
        {
            this.transform.rotation *= Quaternion.Euler(0, Time.deltaTime * m_drehsbeve, 0);
        }

        if (Z_Achse)
        {
            this.transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * m_drehsbeve);
        }
        
    }
}
