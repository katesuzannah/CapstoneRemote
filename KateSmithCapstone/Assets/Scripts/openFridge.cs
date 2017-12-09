using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFridge : MonoBehaviour {

    float openAngle = 143.626f;
    float closedAngle = 0f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Open();
        }
    }
    public void Open() {
        float angle = Mathf.LerpAngle(closedAngle, openAngle, Time.deltaTime);
        transform.eulerAngles = new Vector3 (0f, angle, 0f);
    }
}
