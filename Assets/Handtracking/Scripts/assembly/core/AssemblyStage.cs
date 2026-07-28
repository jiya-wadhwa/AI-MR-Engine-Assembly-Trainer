//using UnityEngine;

//GameObject engine = Instantiate(enginePrefab, position, rotation);
//engine.transform.localScale = Vector3.one * 10f;

public enum AssemblyStage
{
    Crankshaft,
    ConnectingRod,
    Piston,
    CylinderHead,
    TimingBelt,
    ValveCover,
    Complete
}