using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public GameObject TrackedObject;
    public GameObject DesiredPoint;
    public Vector3 DesiredGridLocation = Vector3.zero;
    public GameObject TextToAppear;

    public Material standardMaterial;
    public Material correctAnswerMaterial;
    private Renderer trackedObjRenderder;
    private GridObjectTracker trackedObjComponent;

    private void Start()
    {
        trackedObjRenderder = TrackedObject.GetComponent<Renderer>();
        trackedObjRenderder.sharedMaterial = standardMaterial;
        trackedObjComponent = TrackedObject.GetComponentInChildren<GridObjectTracker>();
        DesiredGridLocation = new Vector3(DesiredGridLocation.x, DesiredGridLocation.z, DesiredGridLocation.y);
    }
    private void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (trackedObjComponent.localGridCoordinates == DesiredGridLocation)
        {
            // If colliding, make TextToAppear active in scene
            TextToAppear.SetActive(true);
            trackedObjRenderder.sharedMaterial = correctAnswerMaterial;
        }
        else
        {
            // If not colliding, make TextToAppear inactive in scene
            TextToAppear.SetActive(false);
            trackedObjRenderder.sharedMaterial = standardMaterial;    // if already assigned, unity will skip this operation
        }

        //// Check if both Objects are touching
        //if (TrackedObject.GetComponent<Collider>().bounds.Intersects(DesiredPoint.GetComponent<Collider>().bounds))
        //{
        //    // If colliding, make TextToAppear active in scene
        //    TextToAppear.SetActive(true);
        //    trackedObjRenderder.sharedMaterial = correctAnswerMaterial;
        //}
        //else
        //{
        //    // If not colliding, make TextToAppear inactive in scene
        //    TextToAppear.SetActive(false);
        //    trackedObjRenderder.sharedMaterial = standardMaterial;    // if already assigned, unity will skip this operation
        //}
    }
}

