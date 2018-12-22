using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
using DlibFaceLandmarkDetector;

namespace LeporemDetectLandmark{
	public class DetectLandmark : MonoBehaviour {
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

        WebCamTexture webCamTexture;
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

        //메쉬가 될 쿼드들.
        //public으로 설정한 이유는, 외부에서 할당과 접근이 가능하도록
        public GameObject leftEyeQuad1;
        public GameObject leftEyeQuad2;
        public GameObject rightEyeQuad1;
        public GameObject rightEyeQuad2;
        public GameObject lipQuad;
        public GameObject leftEyebrowQuad;
        public GameObject rightEyebrowQuad;

        //meshfilter는 할당할 필요가 없으므로 private.
        private MeshFilter leftEyeMF1;
        private MeshFilter leftEyeMF2;
        private MeshFilter rightEyeMF1;
        private MeshFilter rightEyeMF2;
        private MeshFilter lipMF;
        private MeshFilter leftEyebrowMF;
        private MeshFilter rightEyebrowMF;

        //바꾸어줄 메쉬들
        Mesh leftEyeMesh1;
        Mesh leftEyeMesh2;
        Mesh rightEyeMesh1;
        Mesh rightEyeMesh2;
        Mesh lipMesh;
        Mesh leftEyebrowMesh;
        Mesh rightEyebrowMesh;

        //랜드마크 받아오기위한 배열들
        Vector2[] leftEyeLM1;
        Vector2[] leftEyeLM2;
        Vector2[] rightEyeLM1;
        Vector2[] rightEyeLM2;
        Vector2[] lipLM;
        Vector2[] leftEyebrowLM;
        Vector2[] rightEyebrowLM;

        //Vertex 갱신
        Vector3[] leftEyeV1;
        Vector3[] leftEyeV2;
        Vector3[] rightEyeV1;
        Vector3[] rightEyeV2;
        Vector3[] lipV;
        Vector3[] leftEyebrowV;
        Vector3[] rightEyebrowV;

        //Vertex 할당할 벡터
        Vector3[] leftEyeVertices1;
        Vector3[] leftEyeVertices2;
        Vector3[] rightEyeVertices1;
        Vector3[] rightEyeVertices2;
        Vector3[] lipVertices;
        Vector3[] leftEyebrowVertices;
        Vector3[] rightEyebrowVertices;

        //Triangle 할당
        int[] leftEyeTriangles1;
        int[] leftEyeTriangles2;
        int[] rightEyeTriangles1;
        int[] rightEyeTriangles2;
        int[] lipTriangles;
        int[] leftEyebrowTriangles;
        int[] rightEyebrowTriangles;

        //UV 할당
        Vector2[] leftEyeUVs1;
        Vector2[] leftEyeUVs2;
        Vector2[] rightEyeUVs1;
        Vector2[] rightEyeUVs2;
        Vector2[] lipUVs;
        Vector2[] leftEyebrowUVs;
        Vector2[] rightEyebrowUVs;

        //랜더러
        public Renderer leftEyeRend1;
        public Renderer leftEyeRend2;
        public Renderer rightEyeRend1;
        public Renderer rightEyeRend2;
        public Renderer lipRend;
        public Renderer leftEyebrowRend;
        public Renderer rightEyebrowRend;

        //shader
        public Shader leftEyeShad1;
        public Shader leftEyeShad2;
        public Shader rightEyeShad1;
        public Shader rightEyeShad2;
        public Shader lipShad;
        public Shader leftEyebrowShad;
        public Shader rightEyebrowShad;

        //UV를 올바르게 펴주기위해 임의로 적당한 초기값 설정
        //총 랜드마크 수 = 42개
        //lefteye 11개
        //float lex1 = 0.1f; float ley1 = 0.5f;
        //float lex2 = 0.1f; float ley2 = 0.9f;
        //float lex3 = 0.7f; float ley3 = 0.9f;
        //float lex4 = 0.9f; float ley4 = 0.7f;
        //float lex5 = 0.9f; float ley5 = 0.3f;
        //float lex6 = 0.7f; float ley6 = 0.1f;
        //float lex7 = 0.5f; float ley7 = 0.1f;
        float lex1 = 0.1f; float ley1 = 0.1f;
        float lex2 = 0.1f; float ley2 = 0.5f;
        float lex3 = 0.5f; float ley3 = 0.5f;
        float lex4 = 0.7f; float ley4 = 0.5f;
        float lex5 = 0.9f; float ley5 = 0.3f;
        float lex6 = 0.9f; float ley6 = 0.1f;
        float lex7 = 0.7f; float ley7 = 0.3f;
        float lex8 = 0.5f; float ley8 = 0.3f;
        float lex9 = 0.3f; float ley9 = 0.1f;

        float lex10 = 0.1f; float ley10 = 0.9f;
        float lex11 = 0.3f; float ley11 = 0.9f;
        float lex12 = 0.5f; float ley12 = 0.7f;
        float lex13 = 0.6f; float ley13 = 0.7f;
        float lex14 = 0.9f; float ley14 = 0.9f;
        float lex15 = 0.9f; float ley15 = 0.5f;
        float lex16 = 0.7f; float ley16 = 0.3f;
        float lex17 = 0.5f; float ley17 = 0.3f;

        //righteye 11개
        //float rex1 = 0.1f; float rey1 = 0.7f;
        //float rex2 = 0.3f; float rey2 = 0.9f;
        //float rex3 = 0.9f; float rey3 = 0.9f;
        //float rex4 = 0.9f; float rey4 = 0.5f;
        //float rex5 = 0.5f; float rey5 = 0.1f;
        //float rex6 = 0.3f; float rey6 = 0.1f;
        //float rex7 = 0.1f; float rey7 = 0.3f;
        float rex1 = 0.1f; float rey1 = 0.3f;
        float rex2 = 0.3f; float rey2 = 0.5f;
        float rex3 = 0.5f; float rey3 = 0.5f;
        float rex4 = 0.9f; float rey4 = 0.5f;
        float rex5 = 0.9f; float rey5 = 0.1f;
        float rex6 = 0.7f; float rey6 = 0.1f;
        float rex7 = 0.5f; float rey7 = 0.3f;
        float rex8 = 0.3f; float rey8 = 0.3f;
        float rex9 = 0.1f; float rey9 = 0.1f;

        float rex10 = 0.1f; float rey10 = 0.9f;
        float rex11 = 0.3f; float rey11 = 0.7f;
        float rex12 = 0.5f; float rey12 = 0.7f;
        float rex13 = 0.7f; float rey13 = 0.9f;
        float rex14 = 0.9f; float rey14 = 0.9f;
        float rex15 = 0.5f; float rey15 = 0.3f;
        float rex16 = 0.3f; float rey16 = 0.3f;
        float rex17 = 0.1f; float rey17 = 0.5f;

        //lip 20개
        float x13 = 0.2f; float y13 = 0.3f;
        float x14 = 0.3f; float y14 = 0.4f;
        float x15 = 0.4f; float y15 = 0.5f;
        float x16 = 0.5f; float y16 = 0.45f;
        float x17 = 0.6f; float y17 = 0.5f;
        float x18 = 0.7f; float y18 = 0.4f;
        float x19 = 0.8f; float y19 = 0.3f;
        float x20 = 0.7f; float y20 = 0.25f;
        float x21 = 0.6f; float y21 = 0.15f;
        float x22 = 0.5f; float y22 = 0.1f;
        float x23 = 0.4f; float y23 = 0.15f;
        float x24 = 0.3f; float y24 = 0.25f;
        float x25 = 0.3f; float y25 = 0.3f;
        float x26 = 0.4f; float y26 = 0.35f;
        float x27 = 0.5f; float y27 = 0.4f;
        float x28 = 0.6f; float y28 = 0.35f;
        float x29 = 0.7f; float y29 = 0.3f;
        float x30 = 0.6f; float y30 = 0.25f;
        float x31 = 0.5f; float y31 = 0.2f;
        float x32 = 0.4f; float y32 = 0.25f;

        //lefteyebrow 10개
        float lbx1 = 0.1f; float lby1 = 0.6f;
        float lbx2 = 0.3f; float lby2 = 0.6f;
        float lbx3 = 0.5f; float lby3 = 0.6f;
        float lbx4 = 0.7f; float lby4 = 0.6f;
        float lbx5 = 0.9f; float lby5 = 0.6f;
        float lbx6 = 0.9f; float lby6 = 0.35f;
        float lbx7 = 0.7f; float lby7 = 0.35f;
        float lbx8 = 0.5f; float lby8 = 0.35f;
        float lbx9 = 0.3f; float lby9 = 0.35f;
        float lbx10 = 0.1f; float lby10 = 0.35f;

        //righteyebrow 10개
        float rbx1 = 0.1f; float rby1 = 0.6f;
        float rbx2 = 0.3f; float rby2 = 0.6f;
        float rbx3 = 0.5f; float rby3 = 0.6f;
        float rbx4 = 0.7f; float rby4 = 0.6f;
        float rbx5 = 0.9f; float rby5 = 0.6f;
        float rbx6 = 0.9f; float rby6 = 0.4f;
        float rbx7 = 0.7f; float rby7 = 0.4f;
        float rbx8 = 0.5f; float rby8 = 0.4f;
        float rbx9 = 0.3f; float rby9 = 0.4f;
        float rbx10 = 0.1f; float rby10 = 0.4f;



        void Start ()
        {
            leftEyeV1 = new Vector3[9];
            leftEyeV2 = new Vector3[8];
            rightEyeV1 = new Vector3[9];
            rightEyeV2 = new Vector3[8];
            lipV = new Vector3[20];
            leftEyebrowV = new Vector3[10];
            rightEyebrowV = new Vector3[10];

            for (int i = 0; i < 9; i++)
            {
                leftEyeV1[i] = new Vector3(0, 0, 0);
                rightEyeV1[i] = new Vector3(0, 0, 0);
            }
            for (int i = 0; i < 8; i++)
            {
                leftEyeV2[i] = new Vector3(0, 0, 0);
                rightEyeV2[i] = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < 20; i++)
            {
                lipV[i] = new Vector3(0, 0, 0);
            }
            for (int i = 0; i < 10; i++)
            {
                leftEyebrowV[i] = new Vector3(0, 0, 0);
                rightEyebrowV[i] = new Vector3(0, 0, 0);
            }

            // meshfilter 초기화
            leftEyeMF1 = leftEyeQuad1.GetComponent<MeshFilter>();
            leftEyeMF2 = leftEyeQuad2.GetComponent<MeshFilter>();
            rightEyeMF1 = rightEyeQuad1.GetComponent<MeshFilter>();
            rightEyeMF2 = rightEyeQuad2.GetComponent<MeshFilter>();
            lipMF = lipQuad.GetComponent<MeshFilter>();
            leftEyebrowMF = leftEyebrowQuad.GetComponent<MeshFilter>();
            rightEyebrowMF = rightEyebrowQuad.GetComponent<MeshFilter>();

            //mesh 초기화
            leftEyeMesh1 = leftEyeMF1.mesh;
            leftEyeMesh2 = leftEyeMF2.mesh;
            rightEyeMesh1 = rightEyeMF1.mesh;
            rightEyeMesh2 = rightEyeMF2.mesh;
            lipMesh = lipMF.mesh;
            leftEyebrowMesh = leftEyebrowMF.mesh;
            rightEyebrowMesh = rightEyebrowMF.mesh;

            //Vertex 초기화
            leftEyeVertices1 = new Vector3[]
            {
                new Vector3(lex1, ley1, 0),
                new Vector3(lex2, ley2, 0),
                new Vector3(lex3, ley3, 0),
                new Vector3(lex4, ley4, 0),
                new Vector3(lex5, ley5, 0),
                new Vector3(lex6, ley6, 0),
                new Vector3(lex7, ley7, 0),
                new Vector3(lex8, ley8, 0),
                new Vector3(lex9, ley9, 0)
            };
            leftEyeVertices2 = new Vector3[]
            {
                new Vector3(lex10, ley10, 0),
                new Vector3(lex11, ley11, 0),
                new Vector3(lex12, ley12, 0),
                new Vector3(lex13, ley13, 0),
                new Vector3(lex14, ley14, 0),
                new Vector3(lex15, ley15, 0),
                new Vector3(lex16, ley16, 0),
                new Vector3(lex17, ley17, 0)
            };
            rightEyeVertices1 = new Vector3[]
            {
                new Vector3(rex1, rey1, 0),
                new Vector3(rex2, rey2, 0),
                new Vector3(rex3, rey3, 0),
                new Vector3(rex4, rey4, 0),
                new Vector3(rex5, rey5, 0),
                new Vector3(rex6, rey6, 0),
                new Vector3(rex7, rey7, 0),
                new Vector3(rex8, rey8, 0),
                new Vector3(rex9, rey9, 0)
            };
            rightEyeVertices2 = new Vector3[]
            {
                new Vector3(rex10, rey10, 0),
                new Vector3(rex11, rey11, 0),
                new Vector3(rex12, rey12, 0),
                new Vector3(rex13, rey13, 0),
                new Vector3(rex14, rey14, 0),
                new Vector3(rex15, rey15, 0),
                new Vector3(rex16, rey16, 0),
                new Vector3(rex17, rey17, 0)
            };
            lipVertices = new Vector3[]
            {
                new Vector3(x13, y13,0),
                new Vector3(x14, y14,0),
                new Vector3(x15, y15,0),
                new Vector3(x16, y16,0),
                new Vector3(x17, y17,0),
                new Vector3(x18, y18,0),
                new Vector3(x19, y19,0),
                new Vector3(x20, y20,0),
                new Vector3(x21, y21,0),
                new Vector3(x22, y22,0),
                new Vector3(x23, y23,0),
                new Vector3(x24, y24,0),
                new Vector3(x25, y25,0),
                new Vector3(x26, y26,0),
                new Vector3(x27, y27,0),
                new Vector3(x28, y28,0),
                new Vector3(x29, y29,0),
                new Vector3(x30, y30,0),
                new Vector3(x31, y31,0),
                new Vector3(x32, y32,0)
            };
            leftEyebrowVertices = new Vector3[]
            {
                new Vector3(lbx1, lby1, 0),
                new Vector3(lbx2, lby2, 0),
                new Vector3(lbx3, lby3, 0),
                new Vector3(lbx4, lby4, 0),
                new Vector3(lbx5, lby5, 0),
                new Vector3(lbx6, lby6, 0),
                new Vector3(lbx7, lby7, 0),
                new Vector3(lbx8, lby8, 0),
                new Vector3(lbx9, lby9, 0),
                new Vector3(lbx10, lby10, 0)
            };
            rightEyebrowVertices = new Vector3[]
            {
                new Vector3(rbx1, rby1, 0),
                new Vector3(rbx2, rby2, 0),
                new Vector3(rbx3, rby3, 0),
                new Vector3(rbx4, rby4, 0),
                new Vector3(rbx5, rby5, 0),
                new Vector3(rbx6, rby6, 0),
                new Vector3(rbx7, rby7, 0),
                new Vector3(rbx8, rby8, 0),
                new Vector3(rbx9, rby9, 0),
                new Vector3(rbx10, rby10, 0)
            };

            //Triangle 초기화 (시계방향으로 초기화)
            //leftEyeTriangles = new int[]
            //{
            //    0, 1, 2,
            //    0, 2, 3,
            //    0, 3, 4,
            //    0, 4, 5,
            //    0, 5, 6
            //};
            //rightEyeTriangles = new int[]
            //{
            //    1, 2, 3,
            //    0, 1, 3,
            //    0, 3, 6,
            //    3, 5, 6,
            //    3, 4, 5
            //};
            leftEyeTriangles1 = new int[]
            {
                0, 7, 8,
                0, 1, 7,
                1, 2, 7,
                2, 3, 7,
                3, 6, 7,
                3, 4, 6,
                4, 5, 6
            };
            leftEyeTriangles2 = new int[]
            {
                0, 1, 2,
                0, 2, 7,
                2, 6, 7,
                2, 3, 6,
                3, 5, 6,
                3, 4, 5
            };
            rightEyeTriangles1 = new int[]
            {
                0, 7, 8,
                0, 1, 7,
                1, 6, 7,
                1, 2, 6,
                2, 3, 6,
                3, 4, 6,
                4, 5, 6
            };
            rightEyeTriangles2 = new int[]
            {
                0, 1, 7,
                1, 6, 7,
                1, 2, 6,
                2, 5, 6,
                2, 4, 5,
                2, 3, 4
            };
            lipTriangles = new int[]
            {
                0, 1, 12,
                1,13,12,
                1,2,13,
                2,3,13,
                13,3,14,
                14,3,15,
                3,4,15,
                4,5,15,
                15,5,16,
                16,6,7,
                17,16,7,
                17,7,8,
                18,17,8,
                9,18,8,
                10,18,9,
                10,19,18,
                11,19,10,
                11,12,19,
                0,12,11,
                0,1,12
            };
            leftEyebrowTriangles = new int[]
            {
                0, 8, 9,
                0, 1, 8,
                1, 7, 8,
                1, 2, 7,
                2, 6, 7,
                2, 3, 6,
                3, 5, 6,
                3, 4, 5
            };
            rightEyebrowTriangles = new int[]
            {
                0, 8, 9,
                0, 1, 8,
                1, 7, 8,
                1, 2, 7,
                2, 6, 7,
                2, 3, 6,
                3, 5, 6,
                3, 4, 5
            };

            //uv 할당
            leftEyeUVs1 = new Vector2[]
            {
                new Vector2(lex1, ley1),
                new Vector2(lex2, ley2),
                new Vector2(lex3, ley3),
                new Vector2(lex4, ley4),
                new Vector2(lex5, ley5),
                new Vector2(lex6, ley6),
                new Vector2(lex7, ley7),
                new Vector2(lex8, ley8),
                new Vector2(lex9, ley9)
            };
            leftEyeUVs2 = new Vector2[]
            {
                new Vector2(lex10, ley10),
                new Vector2(lex11, ley11),
                new Vector2(lex12, ley12),
                new Vector2(lex13, ley13),
                new Vector2(lex14, ley14),
                new Vector2(lex15, ley15),
                new Vector2(lex16, ley16),
                new Vector2(lex17, ley17)
            };
            rightEyeUVs1 = new Vector2[]
            {
                new Vector2(rex1, rey1),
                new Vector2(rex2, rey2),
                new Vector2(rex3, rey3),
                new Vector2(rex4, rey4),
                new Vector2(rex5, rey5),
                new Vector2(rex6, rey6),
                new Vector2(rex7, rey7),
                new Vector2(rex8, rey8),
                new Vector2(rex9, rey9)
            };
            rightEyeUVs2 = new Vector2[]
            {
                new Vector2(rex10, rey10),
                new Vector2(rex11, rey11),
                new Vector2(rex12, rey12),
                new Vector2(rex13, rey13),
                new Vector2(rex14, rey14),
                new Vector2(rex15, rey15),
                new Vector2(rex16, rey16),
                new Vector2(rex17, rey17)
            };
            lipUVs = new Vector2[]
            {
                new Vector2(x13, y13),
                new Vector2(x14, y14),
                new Vector2(x15, y15),
                new Vector2(x16, y16),
                new Vector2(x17, y17),
                new Vector2(x18, y18),
                new Vector2(x19, y19),
                new Vector2(x20, y20),
                new Vector2(x21, y21),
                new Vector2(x22, y22),
                new Vector2(x23, y23),
                new Vector2(x24, y24),
                new Vector2(x25, y25),
                new Vector2(x26, y26),
                new Vector2(x27, y27),
                new Vector2(x28, y28),
                new Vector2(x29, y29),
                new Vector2(x30, y30),
                new Vector2(x31, y31),
                new Vector2(x32, y32)
            };
            leftEyebrowUVs = new Vector2[]
            {
                new Vector2(lbx1, lby1),
                new Vector2(lbx2, lby2),
                new Vector2(lbx3, lby3),
                new Vector2(lbx4, lby4),
                new Vector2(lbx5, lby5),
                new Vector2(lbx6, lby6),
                new Vector2(lbx7, lby7),
                new Vector2(lbx8, lby8),
                new Vector2(lbx9, lby9),
                new Vector2(lbx10, lby10)
            };
            rightEyebrowUVs = new Vector2[]
            {
                new Vector2(rbx1, rby1),
                new Vector2(rbx2, rby2),
                new Vector2(rbx3, rby3),
                new Vector2(rbx4, rby4),
                new Vector2(rbx5, rby5),
                new Vector2(rbx6, rby6),
                new Vector2(rbx7, rby7),
                new Vector2(rbx8, rby8),
                new Vector2(rbx9, rby9),
                new Vector2(rbx10, rby10)
            };

            //mesh clear and recalculate normals
            leftEyeMesh1.Clear();
            leftEyeMesh1.vertices = leftEyeVertices1;
            leftEyeMesh1.uv = leftEyeUVs1;
            leftEyeMesh1.triangles = leftEyeTriangles1;
            leftEyeMesh1.RecalculateNormals();

            leftEyeMesh2.Clear();
            leftEyeMesh2.vertices = leftEyeVertices2;
            leftEyeMesh2.uv = leftEyeUVs2;
            leftEyeMesh2.triangles = leftEyeTriangles2;
            leftEyeMesh2.RecalculateNormals();

            rightEyeMesh1.Clear();
            rightEyeMesh1.vertices = rightEyeVertices1;
            rightEyeMesh1.uv = rightEyeUVs1;
            rightEyeMesh1.triangles = rightEyeTriangles1;
            rightEyeMesh1.RecalculateNormals();

            rightEyeMesh2.Clear();
            rightEyeMesh2.vertices = rightEyeVertices2;
            rightEyeMesh2.uv = rightEyeUVs2;
            rightEyeMesh2.triangles = rightEyeTriangles2;
            rightEyeMesh2.RecalculateNormals();

            lipMesh.Clear();
            lipMesh.vertices = lipVertices;
            lipMesh.uv = lipUVs;
            lipMesh.triangles = lipTriangles;
            lipMesh.RecalculateNormals();

            leftEyebrowMesh.Clear();
            leftEyebrowMesh.vertices = leftEyebrowVertices;
            leftEyebrowMesh.uv = leftEyebrowUVs;
            leftEyebrowMesh.triangles = leftEyebrowTriangles;
            leftEyebrowMesh.RecalculateNormals();

            rightEyebrowMesh.Clear();
            rightEyebrowMesh.vertices = rightEyebrowVertices;
            rightEyebrowMesh.uv = rightEyebrowUVs;
            rightEyebrowMesh.triangles = rightEyebrowTriangles;
            rightEyebrowMesh.RecalculateNormals();

            //renderer 초기화
            leftEyeRend1 = leftEyeQuad1.GetComponent<Renderer>();
            leftEyeRend2 = leftEyeQuad2.GetComponent<Renderer>();
            rightEyeRend1 = rightEyeQuad1.GetComponent<Renderer>();
            rightEyeRend2 = rightEyeQuad2.GetComponent<Renderer>();
            lipRend = lipQuad.GetComponent<Renderer>();
            leftEyebrowRend = leftEyebrowQuad.GetComponent<Renderer>();
            rightEyebrowRend = rightEyebrowQuad.GetComponent<Renderer>();
            



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


        void Update ()
        {            

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

                Color32[] colors = GetColors ();

                if (colors != null) {

                    faceLandmarkDetector.SetImage<Color32> (colors, texture.width, texture.height, 4, true);

                    //detect face rects
                    List<Rect> detectResult = faceLandmarkDetector.Detect ();

                    foreach (var rect in detectResult) {
                        //Debug.Log ("face : " + rect);

                        //detect landmark points
                        points = faceLandmarkDetector.DetectLandmark (rect);

                        float eyeBoundUpper = 9;
                        float eyeBoundLower = 8;
                        float ebUpper = 1;
                        float ebLower = 8;

                        //left eye
                        leftEyeV1[0].x = (texture.width / 2) - points[36].x + eyeBoundUpper;
                        leftEyeV1[0].y = -(texture.height / 2) + points[36].y;

                        leftEyeV1[1].x = (texture.width / 2) - points[36].x + eyeBoundUpper;
                        leftEyeV1[1].y = -(texture.height / 2) + points[36].y - (eyeBoundUpper * 2);

                        leftEyeV1[2].x = (texture.width / 2) - points[37].x;
                        leftEyeV1[2].y = -(texture.height / 2) + points[37].y - (eyeBoundUpper * 2);

                        leftEyeV1[3].x = (texture.width / 2) - points[38].x;
                        leftEyeV1[3].y = -(texture.height / 2) + points[38].y - eyeBoundUpper;

                        leftEyeV1[4].x = (texture.width / 2) - points[39].x;
                        leftEyeV1[4].y = -(texture.height / 2) + points[39].y - eyeBoundUpper;

                        leftEyeV1[5].x = (texture.width / 2) - points[39].x;
                        leftEyeV1[5].y = -(texture.height / 2) + points[39].y;

                        leftEyeV1[6].x = (texture.width / 2) - points[38].x;
                        leftEyeV1[6].y = -(texture.height / 2) + points[38].y;

                        leftEyeV1[7].x = (texture.width / 2) - points[37].x;
                        leftEyeV1[7].y = -(texture.height / 2) + points[37].y;

                        leftEyeV1[8].x = (texture.width / 2) - points[36].x;
                        leftEyeV1[8].y = -(texture.height / 2) + points[36].y;


                        leftEyeV2[0].x = (texture.width / 2) - points[36].x + eyeBoundUpper + 2;
                        leftEyeV2[0].y = -(texture.height / 2) + points[36].y + 2;

                        leftEyeV2[1].x = (texture.width / 2) - points[36].x;
                        leftEyeV2[1].y = -(texture.height / 2) + points[36].y + 2;

                        leftEyeV2[2].x = (texture.width / 2) - points[41].x;
                        leftEyeV2[2].y = -(texture.height / 2) + points[41].y + 2;

                        leftEyeV2[3].x = (texture.width / 2) - points[40].x;
                        leftEyeV2[3].y = -(texture.height / 2) + points[40].y + 2;

                        leftEyeV2[4].x = (texture.width / 2) - points[39].x;
                        leftEyeV2[4].y = -(texture.height / 2) + points[39].y + 2;

                        leftEyeV2[5].x = (texture.width / 2) - points[39].x;
                        leftEyeV2[5].y = -(texture.height / 2) + points[39].y + eyeBoundLower;

                        leftEyeV2[6].x = (texture.width / 2) - points[40].x;
                        leftEyeV2[6].y = -(texture.height / 2) + points[40].y + eyeBoundLower;

                        leftEyeV2[7].x = (texture.width / 2) - points[41].x;
                        leftEyeV2[7].y = -(texture.height / 2) + points[41].y + eyeBoundLower;


                        //right eye
                        rightEyeV1[0].x = (texture.width / 2) - points[42].x;
                        rightEyeV1[0].y = -(texture.height / 2) + points[42].y - eyeBoundUpper;

                        rightEyeV1[1].x = (texture.width / 2) - points[43].x;
                        rightEyeV1[1].y = -(texture.height / 2) + points[43].y - eyeBoundUpper;

                        rightEyeV1[2].x = (texture.width / 2) - points[44].x;
                        rightEyeV1[2].y = -(texture.height / 2) + points[44].y - (eyeBoundUpper * 2);

                        rightEyeV1[3].x = (texture.width / 2) - points[44].x - eyeBoundUpper;
                        rightEyeV1[3].y = -(texture.height / 2) + points[44].y - (eyeBoundUpper * 2);

                        rightEyeV1[4].x = (texture.width / 2) - points[45].x - eyeBoundUpper;
                        rightEyeV1[4].y = -(texture.height / 2) + points[45].y;

                        rightEyeV1[5].x = (texture.width / 2) - points[45].x;
                        rightEyeV1[5].y = -(texture.height / 2) + points[45].y;

                        rightEyeV1[6].x = (texture.width / 2) - points[44].x;
                        rightEyeV1[6].y = -(texture.height / 2) + points[44].y;

                        rightEyeV1[7].x = (texture.width / 2) - points[43].x;
                        rightEyeV1[7].y = -(texture.height / 2) + points[43].y;

                        rightEyeV1[8].x = (texture.width / 2) - points[42].x;
                        rightEyeV1[8].y = -(texture.height / 2) + points[42].y;



                        rightEyeV2[0].x = (texture.width / 2) - points[42].x;
                        rightEyeV2[0].y = -(texture.height / 2) + points[42].y + 2;

                        rightEyeV2[1].x = (texture.width / 2) - points[47].x;
                        rightEyeV2[1].y = -(texture.height / 2) + points[47].y + 2;

                        rightEyeV2[2].x = (texture.width / 2) - points[46].x;
                        rightEyeV2[2].y = -(texture.height / 2) + points[46].y + 2;

                        rightEyeV2[3].x = (texture.width / 2) - points[45].x;
                        rightEyeV2[3].y = -(texture.height / 2) + points[45].y + 2;

                        rightEyeV2[4].x = (texture.width / 2) - points[45].x - eyeBoundLower;
                        rightEyeV2[4].y = -(texture.height / 2) + points[45].y + 2;

                        rightEyeV2[5].x = (texture.width / 2) - points[46].x;
                        rightEyeV2[5].y = -(texture.height / 2) + points[46].y + (eyeBoundLower);

                        rightEyeV2[6].x = (texture.width / 2) - points[47].x;
                        rightEyeV2[6].y = -(texture.height / 2) + points[47].y + (eyeBoundLower);

                        rightEyeV2[7].x = (texture.width / 2) - points[42].x;
                        rightEyeV2[7].y = -(texture.height / 2) + points[42].y + (eyeBoundLower);

                        //lip
                        for (int i = 48; i < 68; i++)
                        {
                            lipV[i - 48].x = (texture.width / 2) - points[i].x;
                            lipV[i - 48].y = -(texture.height / 2) + points[i].y;
                        }

                        int rear = 9;

                        for (int i = 17; i < 22; i++)
                        {
                            leftEyebrowV[i - 17].x = (texture.width / 2) - points[i].x;
                            leftEyebrowV[i - 17].y = -(texture.height / 2) + points[i].y - ebUpper;

                            leftEyebrowV[rear - i + 17].x = (texture.width / 2) - points[i].x;
                            leftEyebrowV[rear - i + 17].y = -(texture.height / 2) + points[i].y + ebLower;
                        }

                        for (int i = 22; i < 27; i++)
                        {
                            rightEyebrowV[i - 22].x = (texture.width / 2) - points[i].x;
                            rightEyebrowV[i - 22].y = -(texture.height / 2) + points[i].y - ebUpper;

                            rightEyebrowV[rear - i + 22].x = (texture.width / 2) - points[i].x;
                            rightEyebrowV[rear - i + 22].y = -(texture.height / 2) + points[i].y + ebLower;
                        }

                        leftEyeMF1.mesh.vertices = leftEyeV1;
                        leftEyeMF2.mesh.vertices = leftEyeV2;
                        rightEyeMF1.mesh.vertices = rightEyeV1;
                        rightEyeMF2.mesh.vertices = rightEyeV2;
                        lipMF.mesh.vertices = lipV;
                        leftEyebrowMF.mesh.vertices = leftEyebrowV;
                        rightEyebrowMF.mesh.vertices = rightEyebrowV;
                    }
                    
                    texture.SetPixels32 (colors);
                    texture.Apply (false);
                    
                }
            }
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

        public void OnReShootButtonClick()
		{
			Debug.Log("OnReShootButtonClick");
			webCamTexture.Play();
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

