using UnityEngine;
using System.Collections;

/// <summary>
/// Uses a NavMesh from the world to then make a public NavMeshPath for use by other scripts,
/// alongside the object found.
/// </summary>
public class NavMeshGet : GetObject
{
    private UnityEngine.AI.NavMeshPath m_CalculatedPath;
    public UnityEngine.AI.NavMeshPath PathToUse { get { return m_CalculatedPath; } }
    public UnityEngine.AI.NavMeshPathStatus PathStatus { get { return m_CalculatedPath.status; } }

    void Start()
    {
        m_CalculatedPath = new UnityEngine.AI.NavMeshPath();
        //enable finding for path/leader formation positions
        StartCoroutine(CheckObjFound());
        //enable making a path if the above coroutine finds an object to goto
        StartCoroutine(NavGetPath());
    }

    IEnumerator NavGetPath()
    {
        while(true)
        {
            //if an object is found
            if (m_ObjectFound)
            {
                //calculate a path on the default layer
                UnityEngine.AI.NavMesh.CalculatePath(gameObject.transform.position, m_ObjectFound.transform.position, 1, m_CalculatedPath);
            }

            yield return new WaitForSeconds(m_fCheckObjFoundTimer * 0.5f);
        }
    }
}
