using UnityEngine;

public class DataManagerB : SingletonMonoBehaviour<DataManagerB>
{
    // CAUTION:
    // GameObject field will be serialized as 'instanceID' number.
    // However, it shows different value bt. Editor and Player(build).
    // So we can't serialize DataManagerB directly.
    // All of instanceID type field have same problem.

    public int        paramA;
    public float      paramB;
    public GameObject someObject;
}