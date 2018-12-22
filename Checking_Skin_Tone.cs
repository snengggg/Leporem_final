using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;


#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
using DlibFaceLandmarkDetector;

namespace LeporemDetectLandmark
{
	public class Checking_Skin_Tone : MonoBehaviour {

        //public Text resultText;

        
		public string skinTone="default";
		public string newTone, message;
        
        public bool btnPressed = false;
        //public Text text;

		[SerializeField, TooltipAttribute ("Set the name of the device to use.")]
        public string requestedDeviceName = null;

        [SerializeField, TooltipAttribute ("Set the width of WebCamTexture.")]
        public int requestedWidth = 320;

        [SerializeField, TooltipAttribute ("Set the height of WebCamTexture.")]
        public int requestedHeight = 480;

        [SerializeField, TooltipAttribute ("Set FPS of WebCamTexture.")]
        public int requestedFPS = 60;

        [SerializeField, TooltipAttribute ("Set whether to use the front facing camera.")]
        public bool requestedIsFrontFacing = true;

        public Toggle adjustPixelsDirectionToggle;

        [SerializeField, TooltipAttribute ("Determines if adjust pixels direction.")]
        public bool adjustPixelsDirection = true;

        public WebCamTexture webCamTexture;
        WebCamDevice webCamDevice;

        Color32[] colors;

        Color32[] rotatedColors;

        bool rotate90Degree = false;

        bool isInitWaiting = false;

        bool hasInitDone = false;

        ScreenOrientation screenOrientation;

        int screenWidth;

        int screenHeight;

        FaceLandmarkDetector faceLandmarkDetector;

        Texture2D texture;

        public GameObject model;

        public int width = 640;
        public int height = 480;


        string dlibShapePredictorFileName = "sp_human_face_68.dat";
        string dlibShapePredictorFilePath;

        #if UNITY_WEBGL && !UNITY_EDITOR
        Stack<IEnumerator> coroutines = new Stack<IEnumerator> ();
        #endif
        List<Vector2> points = new List<Vector2>();
		// Use this for initialization
		void Start () {
			dlibShapePredictorFileName = DlibFaceLandmarkDetectorExample.DlibFaceLandmarkDetectorExample.dlibShapePredictorFileName;
            #if UNITY_WEBGL && !UNITY_EDITOR
            var getFilePath_Coroutine = Utils.getFilePathAsync (dlibShapePredictorFileName, (result) => {
                coroutines.Clear ();

                dlibShapePredictorFilePath = result;
                Run ();
            });
            coroutines.Push (getFilePath_Coroutine);
            StartCoroutine (getFilePath_Coroutine);
            #else
            dlibShapePredictorFilePath = Utils.getFilePath (dlibShapePredictorFileName);
            Run ();
            #endif
		}
		private void Run ()
        {
            faceLandmarkDetector = new FaceLandmarkDetector (dlibShapePredictorFilePath);
    
            Initialize ();
        }
		private void Initialize ()
        {
            if (isInitWaiting)
                return;

            #if UNITY_ANDROID && !UNITY_EDITOR
            if (requestedIsFrontFacing) {
                int rearCameraFPS = 60;
                requestedFPS = 60;
                StartCoroutine (_Initialize ());
                requestedFPS = rearCameraFPS;
            } else {
                StartCoroutine (_Initialize ());
            }
            #else
            StartCoroutine (_Initialize ());
            #endif
        }

		private IEnumerator _Initialize ()
        {
            if (hasInitDone)
                Dispose ();

            isInitWaiting = true;

            // Creates the camera
            if (!String.IsNullOrEmpty (requestedDeviceName)) {
                int requestedDeviceIndex = -1;
                if (Int32.TryParse (requestedDeviceName, out requestedDeviceIndex)) {
                    if (requestedDeviceIndex >= 0 && requestedDeviceIndex < WebCamTexture.devices.Length) {
                        webCamDevice = WebCamTexture.devices [requestedDeviceIndex];
                        webCamTexture = new WebCamTexture (webCamDevice.name, requestedWidth , requestedHeight  , requestedFPS);
                    }
                } else {
                    for (int cameraIndex = 0; cameraIndex < WebCamTexture.devices.Length; cameraIndex++) {
                        if (WebCamTexture.devices [cameraIndex].name == requestedDeviceName) {
                            webCamDevice = WebCamTexture.devices [cameraIndex];
                            webCamTexture = new WebCamTexture (webCamDevice.name, requestedWidth   ,requestedHeight  , requestedFPS);
                            break;
                        }
                    }
                }
                if (webCamTexture == null)
                    Debug.Log ("Cannot find camera device " + requestedDeviceName + ".");
            }
            if (webCamTexture == null) {
                // Checks how many and which cameras are available on the device
                for (int cameraIndex = 0; cameraIndex < WebCamTexture.devices.Length; cameraIndex++) {                   
                    if (WebCamTexture.devices [cameraIndex].isFrontFacing == requestedIsFrontFacing) {
                        webCamDevice = WebCamTexture.devices [cameraIndex];
                        webCamTexture = new WebCamTexture (webCamDevice.name,requestedWidth  ,requestedHeight , requestedFPS);
                        break;
                    }
                }
            }
            if (webCamTexture == null) {
                if (WebCamTexture.devices.Length > 0) {
                    webCamDevice = WebCamTexture.devices [0];
                    webCamTexture = new WebCamTexture (webCamDevice.name,requestedWidth ,requestedHeight  , requestedFPS);
                } else {
                    Debug.Log ("Camera device does not exist.");
                    isInitWaiting = false;
                    yield break;
                }
            }

            webCamTexture.Play ();

            while (true) {
                //If you want to use webcamTexture.width and webcamTexture.height on iOS, you have to wait until webcamTexture.didUpdateThisFrame == 1, otherwise these two values will be equal to 16. (http://forum.unity3d.com/threads/webcamtexture-and-error-0x0502.123922/)
                #if UNITY_IOS && !UNITY_EDITOR && (UNITY_4_6_3 || UNITY_4_6_4 || UNITY_5_0_0 || UNITY_5_0_1)
                if (webCamTexture.width > 16 && webCamTexture.height > 16) {
                #else
                if (webCamTexture.didUpdateThisFrame) {
                    #if UNITY_IOS && !UNITY_EDITOR && UNITY_5_2                                    
                    while (webCamTexture.width <= 16) {
                        webCamTexture.GetPixels32 ();
                        yield return new WaitForEndOfFrame ();
                    } 
                    #endif
                    #endif
                        
                    Debug.Log ("name:" + webCamTexture.deviceName + " width:" + webCamTexture.width + " height:" + webCamTexture.height + " fps:" + webCamTexture.requestedFPS);
                    Debug.Log ("videoRotationAngle:" + webCamTexture.videoRotationAngle + " videoVerticallyMirrored:" + webCamTexture.videoVerticallyMirrored + " isFrongFacing:" + webCamDevice.isFrontFacing);
                        
                    screenOrientation = Screen.orientation;
                    screenWidth = Screen.width;
                    screenHeight = Screen.height;
                    isInitWaiting = false;
                    hasInitDone = true;

                    OnInited ();
                        
                    break;
                } else {
                    yield return 0;
                }
            }
        }
		private void Dispose ()
        {
            rotate90Degree = false;
            isInitWaiting = false;
            hasInitDone = false;

            if (webCamTexture != null) {
                webCamTexture.Stop ();
                WebCamTexture.Destroy (webCamTexture);
                webCamTexture = null;
            }
            if (texture != null) {
                Texture2D.Destroy (texture);
                texture = null;
            }
        }
        private void OnInited ()
        {
            if (colors == null || colors.Length != webCamTexture.width * webCamTexture.height) {
                colors = new Color32[webCamTexture.width * webCamTexture.height];
                rotatedColors = new Color32[webCamTexture.width * webCamTexture.height];
            }

            if (adjustPixelsDirection) {
                #if !UNITY_EDITOR && !(UNITY_STANDALONE || UNITY_WEBGL) 
                if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                    rotate90Degree = true;
                }else{
                    rotate90Degree = false;
                }
                #endif
            }         
            if (rotate90Degree) {
                texture = new Texture2D (webCamTexture.height, webCamTexture.width, TextureFormat.RGBA32, false);
            } else {
                texture = new Texture2D (webCamTexture.width, webCamTexture.height, TextureFormat.RGBA32, false);
            }                      

            gameObject.GetComponent<Renderer> ().material.mainTexture = texture;


            gameObject.transform.localScale = new Vector3 (texture.width, texture.height, 1);
            Debug.Log ("Screen.width " + Screen.width + " Screen.height " + Screen.height + " Screen.orientation " + Screen.orientation);
            

            float width = texture.width;
            float height = texture.height;

            float widthScale = (float)Screen.width / width;
            float heightScale = (float)Screen.height / height;
            
        



             if (widthScale < heightScale) {
                Camera.main.orthographicSize = (width * (float)Screen.height / (float)Screen.width) / 2;
                Debug.Log ("Screen상태 :1 " + Camera.main.orthographicSize);
            } else {
                Camera.main.orthographicSize = height / 2;
                Debug.Log ("Screen상태 :2 " + Camera.main.orthographicSize);
            }
            
        }
		// Update is called once per frame
		void Update () {
			
            if (adjustPixelsDirection) {
                // Catch the orientation change of the screen.
                if (screenOrientation != Screen.orientation && (screenWidth != Screen.width || screenHeight != Screen.height)) {
                    Initialize ();
                } else {
                    screenWidth = Screen.width;
                    screenHeight = Screen.height;
                }
            }

           
            if (hasInitDone && webCamTexture.isPlaying && webCamTexture.didUpdateThisFrame) {
				int middle_x = 0, middle_y = 0;
                Color32[] colors = GetColors ();

                if (colors != null) {

                    faceLandmarkDetector.SetImage<Color32> (colors, texture.width, texture.height, 4, true);

                    //detect face rects
                    List<Rect> detectResult = faceLandmarkDetector.Detect ();

                    foreach (var rect in detectResult) {
                        //Debug.Log ("face : " + rect);

                        //detect landmark points
                        points = faceLandmarkDetector.DetectLandmark (rect);
                        middle_x = (int)((points[29].x + points[1].x) / 2);
						middle_y = (int)((points[29].y + points[1].y) / 2);
                    }
                    if (btnPressed)
					{

						//최종 r, g, b값
						double result_r = 0, result_g = 0, result_b = 0;

						//잘라낼 사진 높이, 넓이
						int width = 10;
						int height = 10;

						//추출 이미지 중심 랜드마크 포인트 좌표 로그 출력
						Debug.Log("middle coordinate x:" + middle_x + " y:" + middle_y);

						//카메라 이미지 잘라서 "saved.png" 라는 의미로 Resource 경로에 저장
						SaveImage(middle_x, middle_y);

						UnityEngine.Rect rect = new UnityEngine.Rect(0, 0, width, height);

						double sum_r = 0, sum_g = 0, sum_b = 0;

						//잘라낸 이미지 텍스쳐로 변환
						Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
						tex = Resources.Load<Texture2D>("saved1");


						//텍스처로부터 rgb추출
						tex.ReadPixels(rect, 0, 0);
						for (int pixel_y = 0; pixel_y < height; ++pixel_y)
						{
							for (int pixel_x = 0; pixel_x < width; ++pixel_x)
							{
								Color c = tex.GetPixel(pixel_x, pixel_y);

								Debug.LogFormat("pixel[{0},{1}] = {2}, R:{3} G:{4} B:{5}", pixel_x, pixel_y, c, c.r * 255, c.g * 255, c.b * 255);
								sum_r += c.r * 255;
								sum_g += c.g * 255;
								sum_b += c.b * 255;
							}
						}
						//[결과] rgb = 각 픽셀 rgb 평균값 
						result_r = sum_r / (width * height);
						result_g = sum_g / (width * height);
						result_b = sum_b / (width * height);

						Debug.LogFormat(" [평균] R:{0} G:{1} B:{2}", result_r, result_g, result_b);

						webCamTexture.Stop();

						//피부톤 분류
						if (result_r > result_b)
						{
							skinTone = "웜";
						}
						else
						{
							skinTone = "쿨";
						}
						Debug.Log("피부톤: " + skinTone);
						//script = GameObject.FindObjectOfType<Result>();
						
						//	Debug.Log(GameObject.FindObjectOfType<Script>());
						//	script.GetSkinTone(skinTone);
						
					}
                    faceLandmarkDetector.DrawDetectResult<Color32> (colors, texture.width, texture.height, 4, true, 107, 255, 64, 255, 2);
                    texture.SetPixels32 (colors);
                    texture.Apply (false);
                    
                }
            }
        }
        
		
		//웹캠 이미지를 Resources/ 경로에 png 형식으로 저장
		void SaveImage(int middle_x, int middle_y)
		{
			/*
			//Create a Texture2D with the size of the rendered image on the screen.
			Texture2D texture = new Texture2D(rawimage.texture.width, rawimage.texture.height, TextureFormat.ARGB32, false);

			//Save the image to the Texture2D
			texture.SetPixels(webcamTexture.GetPixels());
			texture.Apply();

			//PNG로 인코딩
			byte[] bytes = texture.EncodeToPNG();

			//촬영한 사진 saved.png 로저장 
			File.WriteAllBytes(Application.dataPath + "/DlibFaceLandmarkDetector/Examples/Test/Resources/saved.png", bytes);
			*/

			OpenCVForUnity.Mat srcMat = new OpenCVForUnity.Mat(webCamTexture.height, webCamTexture.width, OpenCVForUnity.CvType.CV_8UC4);
			OpenCVForUnity.Utils.webCamTextureToMat(webCamTexture, srcMat);
			//Debug.Log("scrMat:" + srcMat.ToString());

			OpenCVForUnity.Rect area = new OpenCVForUnity.Rect(middle_x + 5, middle_y + 5, 10, 10);
			OpenCVForUnity.Mat desMat = srcMat.submat(area);
			Texture2D desTex = new Texture2D(desMat.cols(), desMat.rows(), TextureFormat.RGBA32, false);
			OpenCVForUnity.Utils.matToTexture2D(desMat, desTex);
			//Debug.Log("desTex:" + desTex.ToString());
			byte[] img = desTex.EncodeToPNG();
			File.WriteAllBytes(Application.dataPath + "/DlibFaceLandmarkDetector/Examples/WebCamTextureExample/Resources/saved1.png", img);
			//Debug.Log("saved");
            //File.WriteAllBytes(Application.persistentDataPath + @"/saved1.png", img);
            //12.13수정

            Debug.Log("application.persistentdatapath" + Application.persistentDataPath);
            Debug.Log("application.datapath" + Application.dataPath);
         //File.WriteAllBytes(Application.persistentDataPath + "/DlibFaceLandmarkDetector/Examples/WebCamTextureExample/Resources/saved1.png", img);

		}
        private Color32[] GetColors ()
        {
            webCamTexture.GetPixels32 (colors);

            if (adjustPixelsDirection) {
                //Adjust an array of color pixels according to screen orientation and WebCamDevice parameter.
                if (rotate90Degree) {
                    Rotate90CW (colors, rotatedColors, webCamTexture.width, webCamTexture.height);
                    FlipColors (rotatedColors, webCamTexture.width, webCamTexture.height);
                    return rotatedColors;
                } else {
                    FlipColors (colors, webCamTexture.width, webCamTexture.height);
                    return colors;
                }
            }
            return colors;
        }
        void OnDestroy ()
        {
            Dispose ();

            if (faceLandmarkDetector != null)
                faceLandmarkDetector.Dispose ();

            #if UNITY_WEBGL && !UNITY_EDITOR
            foreach (var coroutine in coroutines) {
                StopCoroutine (coroutine);
                ((IDisposable)coroutine).Dispose ();
            }
            #endif
        }

        

        
         public void OnBackButtonClick ()
        {
            #if UNITY_5_3 || UNITY_5_3_OR_NEWER
            SceneManager.LoadScene ("DlibFaceLandmarkDetectorExample");
            #else
            Application.LoadLevel ("DlibFaceLandmarkDetectorExample");
            #endif
        }
        public void OnChangeCameraButtonClick ()
        {
            if (hasInitDone) {
                requestedDeviceName = null;
                requestedIsFrontFacing = !requestedIsFrontFacing;
                Initialize ();
            }
        }
/*      public void OnAdjustPixelsDirectionToggleValueChanged ()
        {
            if (adjustPixelsDirectionToggle.isOn != adjustPixelsDirection) {
                adjustPixelsDirection = adjustPixelsDirectionToggle.isOn;
                Initialize ();
            }
        }*/
        void FlipColors (Color32[] colors, int width, int height)
        {
            int flipCode = int.MinValue;

            if (webCamDevice.isFrontFacing) {
                if (webCamTexture.videoRotationAngle == 0) {
                    flipCode = 1;
                } else if (webCamTexture.videoRotationAngle == 90) {
                    flipCode = 1;
                }
                if (webCamTexture.videoRotationAngle == 180) {
                    flipCode = 0;
                } else if (webCamTexture.videoRotationAngle == 270) {
                    flipCode = 0;
                }
            } else {
                if (webCamTexture.videoRotationAngle == 180) {
                    flipCode = -1;
                } else if (webCamTexture.videoRotationAngle == 270) {
                    flipCode = -1;
                }
            }                

            if (flipCode > int.MinValue) {
                if (rotate90Degree) {
                    if (flipCode == 0) {
                        FlipVertical (colors, colors, height, width);
                    } else if (flipCode == 1) {
                        FlipHorizontal (colors, colors, height, width);
                    } else if (flipCode < 0) {
                        Rotate180 (colors, colors, height, width);
                    }
                } else {
                    if (flipCode == 0) {
                        FlipVertical (colors, colors, width, height);
                    } else if (flipCode == 1) {
                        FlipHorizontal (colors, colors, width, height);
                    } else if (flipCode < 0) {
                        Rotate180 (colors, colors, height, width);
                    }
                }
            }
        }
        void FlipVertical (Color32[] src, Color32[] dst, int width, int height)
        {
            for (var i = 0; i < height / 2; i++) {
                var y = i * width;
                var x = (height - i - 1) * width;
                for (var j = 0; j < width; j++) {
                    int s = y + j;
                    int t = x + j;
                    Color32 c = src [s];
                    dst [s] = src [t];
                    dst [t] = c;
                }
            }
        }
        void FlipHorizontal (Color32[] src, Color32[] dst, int width, int height)
        {
            for (int i = 0; i < height; i++) {
                int y = i * width;
                int x = y + width - 1;
                for (var j = 0; j < width / 2; j++) {
                    int s = y + j;
                    int t = x - j;
                    Color32 c = src [s];
                    dst [s] = src [t];
                    dst [t] = c;
                }
            }
        }
        void Rotate180 (Color32[] src, Color32[] dst, int height, int width)
        {
            int i = src.Length;
            for (int x = 0; x < i / 2; x++) {
                Color32 t = src [x];
                dst [x] = src [i - x - 1];
                dst [i - x - 1] = t;
            }
        }

        void Rotate90CW (Color32[] src, Color32[] dst, int height, int width)
        {
            int i = 0;
            for (int x = height - 1; x >= 0; x--) {
                for (int y = 0; y < width; y++) {
                    dst [i] = src [x + y * height];
                    i++;
                }
            }
        }
        void Rotate90CCW (Color32[] src, Color32[] dst, int width, int height)
        {
            int i = 0;
            for (int x = 0; x < width; x++) {
                for (int y = height - 1; y >= 0; y--) {
                    dst [i] = src [x + y * width];
                    i++;
                }
            }
        }
    }   



}

