using UnityEngine;

public class WorldMarkerBeaconComponent : MonoBehaviour
{
    [SerializeField] private HintType HintType;
    public HintType getHintType => HintType;
    
    public WorldMarkerUIObject getMarker(out bool isJustCreated) {
        isJustCreated = false;
        if (null == _marker) {
            _marker = Instantiate(_markerPrefab);
            isJustCreated = true;
        }

        return _marker;
    }

    //Fields
    [SerializeField] private WorldMarkerUIObject _markerPrefab = null;
    private WorldMarkerUIObject _marker = null;
}
