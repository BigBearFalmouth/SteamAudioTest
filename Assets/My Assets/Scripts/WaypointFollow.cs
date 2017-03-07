using UnityEngine;
using System.Collections;

public class WaypointFollow : MonoBehaviour {

    //Waypoints to follow
    public Transform[] waypoints;
    public bool loop = true;
    public float speed = 10.0f;
	// Use this for initialization
	void Start () {
        FollowPath();
    }

    void OnDrawGizmos()
    {
        //Draw Path in Editor
        iTween.DrawPathGizmos(waypoints);
    }

    //Called when the path is complete
    void OnPathFollowComplete()
    {
        //If we are looping, start following path again
        if (loop)
        {
            FollowPath();
        }
    }

    //Follow Path
    public void FollowPath()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", waypoints,
            "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "OnPathFollowComplete"));
    }
}
