using UnityEngine;
using Unity.Cinemachine;
using UnityEditor;
using TMPro;
public class CameraManager : MonoBehaviour
{
    //FreeCamera
    public CinemachineVirtualCameraBase cmVirtualCam;
    public Camera mainCamera;
    private bool usingVirtualCam = true;

    //カメラリセット用変数
    public Transform player;
    private Vector3 CamOffset;

    [Range(0.01f,1.0f)]
    public float smoothness = 0.5f;


    //FreeCam(Text)
    [SerializeField]
    private TextMeshProUGUI viewtext;

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            usingVirtualCam = !usingVirtualCam; //On:Off

            if (usingVirtualCam)   //true
            {
                cmVirtualCam.transform.position = mainCamera.transform.position;
                cmVirtualCam.gameObject.SetActive(true);
                viewtext.text = "FreeView(space):Disable";
            }
            else    //false
            {
                cmVirtualCam.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(true);
                viewtext.text = "FreeView(space):Enable";
            }
        }
        if(!usingVirtualCam)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            if(x < 10)
            {
                mainCamera.transform.position -= Vector3.right * Time.deltaTime * 10;
            }
            else if(x > Screen.width - 10)
            {
                mainCamera.transform.position -= Vector3.left * Time.deltaTime * 10;
            }

            if(y < 10)
            {
                mainCamera.transform.position -= Vector3.forward * Time.deltaTime * 10;
            }
            else if(y > Screen.height - 10)
            {
                mainCamera.transform.position -= Vector3.back * Time.deltaTime * 10;
            }
        }
    }

    private void VcamRepos()
    {

    }
}
