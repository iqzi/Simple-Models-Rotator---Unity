using UnityEngine;

[CreateAssetMenu]
public class SimpleModelsRotator_Preset : ScriptableObject {

    public Rotating rotating = new Rotating();
    public Zooming zooming = new Zooming();

    [System.Serializable]
    public class Rotating {
        public bool rightMouseButtonInput = false;
    }

	[System.Serializable]
    public class Zooming {
        public float zoomSpeed = 10;
        public float zoomMin = 30;
        public float zoomMax = 60;
    }
}
