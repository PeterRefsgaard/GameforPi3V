using UnityEngine;

public class ViewSwitcher : MonoBehaviour
{
    public Camera thirdPersonCam;
    public Camera firstPersonCam;

    // Any renderers you want to HIDE in first person
    public Renderer[] renderersToHideInFirstPerson;

    bool isFirstPerson = false;

    void Start()
    {
        SetView(false); // start in third person
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            SetView(isFirstPerson);
        }
    }

    void SetView(bool firstPerson)
    {
        // Cameras
        thirdPersonCam.enabled = !firstPerson;
        firstPersonCam.enabled = firstPerson;

        // Hide/show selected renderers (e.g. head)
        if (renderersToHideInFirstPerson != null)
        {
            foreach (var r in renderersToHideInFirstPerson)
            {
                if (r != null)
                    r.enabled = !firstPerson;
            }
        }
    }
}


