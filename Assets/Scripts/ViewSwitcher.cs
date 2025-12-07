using UnityEngine;

public class ViewSwitcher : MonoBehaviour
{
    public Camera thirdPersonCam;
    public Camera firstPersonCam;

    
    public Renderer[] renderersToHideInFirstPerson;

    bool isFirstPerson = false;

    void Start()
    {
        SetView(false); 
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
        
        thirdPersonCam.enabled = !firstPerson;
        firstPersonCam.enabled = firstPerson;

        
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


