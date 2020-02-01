using UnityEngine;

public class WorldMarkerBeaconComponent : MonoBehaviour
{
    public WorldMarkerUIObject getMarker(out bool isJustCreated) {
        isJustCreated = false;
        if (null == _marker) {
            _marker = Instantiate(_markerPrefab);
            isJustCreated = true;
        }

        return _marker;
    }

    private void OnDestroy(){
        Destroy(_marker.gameObject);
    }

    //Fields
    [SerializeField] private WorldMarkerUIObject _markerPrefab = null;
    private WorldMarkerUIObject _marker = null;
}
