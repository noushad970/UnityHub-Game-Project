using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class WaypointManager : EditorWindow
{

    [MenuItem("WayPoints/WayPoint Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManager>("WayPoint Editor Tools");
    }
    public Transform waypointOrigin;
    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));
        if (waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoint origin transform. ", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();

    }
    void CreateButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWayPoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<WayPoint>())
        {
            if (GUILayout.Button("Create Waypoint Before"))
            {
                CreateWayPointBefore();
            }
            if (GUILayout.Button("Create Waypoint After"))
            {
                CreateWayPointAfter();
            }
            if (GUILayout.Button("Remove Waypoint"))
            {
                RemoveWaypoint();
            }
        }
    }
    void CreateWayPoint()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin, false);

        WayPoint waypoint = waypointObject.GetComponent<WayPoint>();
        if (waypointOrigin.childCount > 1)
        {
            waypoint.previousWayPoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<WayPoint>();
            waypoint.previousWayPoint.nextWayPoint = waypoint;

            waypoint.transform.position = waypoint.previousWayPoint.transform.position;
            waypoint.transform.forward = waypoint.previousWayPoint.transform.forward;
        }

        Selection.activeGameObject = waypointObject.gameObject;

    }

    void CreateWayPointBefore()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin, false);
        WayPoint newWaypoint = waypointObject.GetComponent<WayPoint>();

        WayPoint selectedWaypoint = Selection.activeGameObject.GetComponent<WayPoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.position = selectedWaypoint.transform.forward;

        if (selectedWaypoint.previousWayPoint)
        {
            newWaypoint.previousWayPoint = selectedWaypoint.previousWayPoint;
            selectedWaypoint.previousWayPoint.nextWayPoint = newWaypoint;
        }

        newWaypoint.nextWayPoint = selectedWaypoint;
        selectedWaypoint.previousWayPoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }
    void CreateWayPointAfter()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin, false);
        WayPoint newWaypoint = waypointObject.GetComponent<WayPoint>();

        WayPoint selectedWaypoint = Selection.activeGameObject.GetComponent<WayPoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.position = selectedWaypoint.transform.forward;
        if (selectedWaypoint.nextWayPoint != null)
        {
            selectedWaypoint.nextWayPoint.previousWayPoint = newWaypoint;
            newWaypoint.nextWayPoint = selectedWaypoint.nextWayPoint;
        }
        selectedWaypoint.nextWayPoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;

    }
    void RemoveWaypoint()
    {
        WayPoint selectedWaypoint = Selection.activeGameObject.GetComponent<WayPoint>();

        if (selectedWaypoint.nextWayPoint != null)
        {
            selectedWaypoint.nextWayPoint.previousWayPoint = selectedWaypoint.previousWayPoint;
        }
        if (selectedWaypoint.previousWayPoint != null)
        {
            selectedWaypoint.previousWayPoint.nextWayPoint = selectedWaypoint.nextWayPoint;
            Selection.activeGameObject = selectedWaypoint.previousWayPoint.gameObject;

            DestroyImmediate(selectedWaypoint.gameObject);

        }

    }
}
