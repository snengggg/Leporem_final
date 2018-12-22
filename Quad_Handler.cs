using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quad_Handler : MonoBehaviour {

   // Use this for initialization

   // Opacity slider

   /* public float vSliderValue = 0.0f;


   //gameObject.GetComponent<MeshRenderer> ().material.color = Color.white
    void OnGUI()
   {
        vSliderValue = GUI.VerticalSlider(new Rect(25, 25, 100, 30), vSliderValue, 10.0f, 0.0f);
   }*/
    

    public GameObject leftEyeQuad1;
    public GameObject leftEyeQuad2;
    public GameObject rightEyeQuad1;
    public GameObject rightEyeQuad2;
    public GameObject lipQuad;
   public GameObject leftEyebrowQuad;
   public GameObject rightEyebrowQuad;

   private Color LE1OpaColor;
   private Color LE2OpaColor;
   private Color RE1OpaColor;

   private Color RE2OpaColor;

   private Color LIBOpaColor;

   private Color LEBOpaColor;

   private Color REBOpaColor;


   private int Current_Quad_Step = 0;
   private bool allquadUPflag = false;
   private bool allquadDOWNflag = false;
   private bool stepquadflag = true;

   
   void Start () {
      
      allQuadDown();
      
   }

   
   
   // Update is called once per frame
   void Update () {
      //renderer.material.color = new Color(1,1,1,Alpha);
      
   }
   

   public void leftEyeQuadDown(){
      leftEyeQuad1.SetActive(false);
      leftEyeQuad2.SetActive(false);
   } 
   public void leftEyeQuadUp(){
      leftEyeQuad1.SetActive(true);
      leftEyeQuad2.SetActive(true);
   }
   public void rightEyeQuadDown(){
      rightEyeQuad1.SetActive(false);
      rightEyeQuad2.SetActive(false);
   }
   public void rightEyeQuadUp(){
      rightEyeQuad1.SetActive(true);
      rightEyeQuad2.SetActive(true);
   }
   public void lipQuadDown(){
      lipQuad.SetActive(false);
   }
   public void lipQuadUp(){
      lipQuad.SetActive(true);
   }
   public void leftEyebrowQuadDown(){
      leftEyebrowQuad.SetActive(false);
   } 
   public void leftEyebrowQuadUp(){
      leftEyebrowQuad.SetActive(true);
   }

   public void rightEyebrowQuadDown(){
      rightEyebrowQuad.SetActive(false);
   } 
   public void rightEyebrowQuadUp(){
      rightEyebrowQuad.SetActive(true);
   }

   public void allQuadUp(){

      allquadUPflag = true;
      allquadDOWNflag = false;
      stepquadflag = false;
      
      leftEyeQuadUp();
      leftEyebrowQuadUp();
      rightEyeQuadUp();
      rightEyebrowQuadUp();
      lipQuadUp();
   }
   public void allQuadDown(){

      allquadUPflag = false;
      allquadDOWNflag = true;
      stepquadflag = false;

      leftEyeQuadDown();
      leftEyebrowQuadDown();
      rightEyeQuadDown();
      rightEyebrowQuadDown();
      lipQuadDown();
   }

   
   public void onStepButtonClick(){
      allQuadDown();
      allquadUPflag = false;
      allquadDOWNflag = false;
      stepquadflag = true;
      currentStepQuadUp();
   }

   public void currentStepQuadUp(){

      if(Current_Quad_Step == 1){
         leftEyebrowQuadUp();
         rightEyebrowQuadUp();
      }
      else if(Current_Quad_Step == 2){
         leftEyeQuadUp();
         rightEyeQuadUp();
      }
      else if(Current_Quad_Step == 3){
         allQuadDown();
         lipQuadUp();
      }else{
         allQuadUp();
      }


   }

   

   public void FinisiSelectMakeup(){
      Current_Quad_Step = 1;
      onStepButtonClick();
   }

   public void gotoTutorialFirstStep(){
      Current_Quad_Step = 1;
      if(!allquadDOWNflag && !allquadUPflag){
         onStepButtonClick();
      }
   }
   public void gotoTutorialSecondStep(){
      Current_Quad_Step = 2;
      if(!allquadDOWNflag && !allquadUPflag){
         onStepButtonClick();
      }
   }
   public void gotoTutorialThirdStep(){
      Current_Quad_Step = 3;
      if(!allquadDOWNflag && !allquadUPflag){
         onStepButtonClick();
      }
   }

   public void gotoTutorialLastStep(){
      Current_Quad_Step = 4;
      if(!allquadDOWNflag && !allquadUPflag){
         onStepButtonClick();
      }
   }

   public void test1(){
     // OpaColor.a = 0.7f;
   }

   public void test2(){
     // OpaColor.a = 0.3f;
   }

   public void onFirstThumbnailButtonClick(){
      allQuadDown();

   

      Material LE_U = Resources.Load("Material/LE1_U", typeof(Material)) as Material;
      Material LE_D = Resources.Load("Material/LE1_D", typeof(Material)) as Material;
      Material RE_U = Resources.Load("Material/RE1_U", typeof(Material)) as Material;
      Material RE_D = Resources.Load("Material/RE1_D", typeof(Material)) as Material;
      Material LEB = Resources.Load("Material/LEB1", typeof(Material)) as Material;
      Material REB = Resources.Load("Material/REB1", typeof(Material)) as Material;
      Material LIP = Resources.Load("Material/LIP1", typeof(Material)) as Material;

      

      leftEyeQuad1.GetComponent<MeshRenderer>().material = LE_U;
      leftEyeQuad2.GetComponent<MeshRenderer>().material = LE_D;
      rightEyeQuad1.GetComponent<MeshRenderer>().material = RE_U;
      rightEyeQuad2.GetComponent<MeshRenderer>().material = RE_D; 
      leftEyebrowQuad.GetComponent<MeshRenderer>().material = LEB;
      rightEyebrowQuad.GetComponent<MeshRenderer>().material = REB;
      lipQuad.GetComponent<MeshRenderer>().material = LIP;

      
      allQuadUp();
      

   }

  /*  public void allQuadOpacControl(){
      //leftEyeQuad1.GetComponent<MeshRenderer>().material.color = OpaColor;

     

      LE1OpaColor = leftEyeQuad1.GetComponent<MeshRenderer>().material.color;
      LE2OpaColor = leftEyeQuad2.GetComponent<MeshRenderer>().material.color;
      RE1OpaColor = rightEyeQuad1.GetComponent<MeshRenderer>().material.color;
      RE2OpaColor = rightEyeQuad2.GetComponent<MeshRenderer>().material.color;
      LEBOpaColor = leftEyebrowQuad.GetComponent<MeshRenderer>().material.color;
      REBOpaColor = rightEyebrowQuad.GetComponent<MeshRenderer>().material.color;
      LIBOpaColor = lipQuad.GetComponent<MeshRenderer>().material.color;

      LE1OpaColor.a = 0.5f;
      LE2OpaColor.a = 0.5f;
      RE1OpaColor.a = 0.5f;
      RE2OpaColor.a = 0.5f;
      LEBOpaColor.a = 0.5f;
      REBOpaColor.a = 0.5f;
      LIBOpaColor.a = 0.5f;
      
      

      leftEyeQuad1.GetComponent<MeshRenderer>().material.color = LE1OpaColor;
      leftEyeQuad2.GetComponent<MeshRenderer>().material.color = LE2OpaColor;
      rightEyeQuad1.GetComponent<MeshRenderer>().material.color = RE1OpaColor;
      rightEyeQuad2.GetComponent<MeshRenderer>().material.color = RE2OpaColor; 
      leftEyebrowQuad.GetComponent<MeshRenderer>().material.color = LEBOpaColor;
      rightEyebrowQuad.GetComponent<MeshRenderer>().material.color = REBOpaColor;
      lipQuad.GetComponent<MeshRenderer>().material.color = LIBOpaColor;
   }*/



   public void onSecThumbnailButtonClick(){

      allQuadDown();

      //gameObject.GetComponent<MeshRenderer> ().material.color = Color.white;
      
      

      Material LE_U = Resources.Load("Material/LE2_U", typeof(Material)) as Material;
      Material LE_D = Resources.Load("Material/LE2_D", typeof(Material)) as Material;
      Material RE_U = Resources.Load("Material/RE2_U", typeof(Material)) as Material;
      Material RE_D = Resources.Load("Material/RE2_D", typeof(Material)) as Material;
      Material LEB = Resources.Load("Material/LEB2", typeof(Material)) as Material;
      Material REB = Resources.Load("Material/REB2", typeof(Material)) as Material;
      Material LIP = Resources.Load("Material/LIP2", typeof(Material)) as Material;
      
      

      leftEyeQuad1.GetComponent<MeshRenderer>().material = LE_U;
      leftEyeQuad2.GetComponent<MeshRenderer>().material = LE_D;
      rightEyeQuad1.GetComponent<MeshRenderer>().material = RE_U;
      rightEyeQuad2.GetComponent<MeshRenderer>().material = RE_D; 
      leftEyebrowQuad.GetComponent<MeshRenderer>().material = LEB;
      rightEyebrowQuad.GetComponent<MeshRenderer>().material = REB;
      lipQuad.GetComponent<MeshRenderer>().material = LIP;


      allQuadUp();
      
   }
   public void onThirdThumbnailButtonClick(){

      allQuadDown();

      Material LE_U = Resources.Load("Material/LE3_U", typeof(Material)) as Material;
      Material LE_D = Resources.Load("Material/LE3_D", typeof(Material)) as Material;
      Material RE_U = Resources.Load("Material/RE3_U", typeof(Material)) as Material;
      Material RE_D = Resources.Load("Material/RE3_D", typeof(Material)) as Material;
      Material LEB = Resources.Load("Material/LEB3", typeof(Material)) as Material;
      Material REB = Resources.Load("Material/REB3", typeof(Material)) as Material;
      Material LIP = Resources.Load("Material/LIP3", typeof(Material)) as Material;

      leftEyeQuad1.GetComponent<MeshRenderer>().material = LE_U;
      leftEyeQuad2.GetComponent<MeshRenderer>().material = LE_D;
      rightEyeQuad1.GetComponent<MeshRenderer>().material = RE_U;
      rightEyeQuad2.GetComponent<MeshRenderer>().material = RE_D; 
      leftEyebrowQuad.GetComponent<MeshRenderer>().material = LEB;
      rightEyebrowQuad.GetComponent<MeshRenderer>().material = REB;
      lipQuad.GetComponent<MeshRenderer>().material = LIP;

      allQuadUp();
      
   }

   // public void onFourthThumbnailButtonClick(){

   //    allQuadDown();
      
   //    Material LE_U = Resources.Load("Material/LE4_U.mat", typeof(Material)) as Material;
   //    Material LE_D = Resources.Load("Material/LE4_D.mat", typeof(Material)) as Material;
   //    Material RE_U = Resources.Load("Material/RE4_U.mat", typeof(Material)) as Material;
   //    Material RE_D = Resources.Load("Material/RE4_D.mat", typeof(Material)) as Material;
   //    Material LEB = Resources.Load("Material/LEB4.mat", typeof(Material)) as Material;
   //    Material REB = Resources.Load("Material/REB4.mat", typeof(Material)) as Material;
   //    Material LIP = Resources.Load("Material/LIP4.mat", typeof(Material)) as Material;

   //    leftEyeQuad1.GetComponent<MeshRenderer>().material = LE_U;
   //    leftEyeQuad2.GetComponent<MeshRenderer>().material = LE_D;
   //    rightEyeQuad1.GetComponent<MeshRenderer>().material = RE_U;
   //    rightEyeQuad2.GetComponent<MeshRenderer>().material = RE_D; 
   //    leftEyebrowQuad.GetComponent<MeshRenderer>().material = LEB;
   //    rightEyebrowQuad.GetComponent<MeshRenderer>().material = REB;
   //    lipQuad.GetComponent<MeshRenderer>().material = LIP;

   //    allQuadUp();
      
   // }
   // public void onFifthThumbnailButtonClick(){

   //    allQuadDown();
      
   //    Material LE_U = Resources.Load("Material/LE5_U.mat", typeof(Material)) as Material;
   //    Material LE_D = Resources.Load("Material/LE5_D.mat", typeof(Material)) as Material;
   //    Material RE_U = Resources.Load("Material/RE5_U.mat", typeof(Material)) as Material;
   //    Material RE_D = Resources.Load("Material/RE5_D.mat", typeof(Material)) as Material;
   //    Material LEB = Resources.Load("Material/LEB5.mat", typeof(Material)) as Material;
   //    Material REB = Resources.Load("Material/REB5.mat", typeof(Material)) as Material;
   //    Material LIP = Resources.Load("Material/LIP5.mat", typeof(Material)) as Material;

   //    leftEyeQuad1.GetComponent<MeshRenderer>().material = LE_U;
   //    leftEyeQuad2.GetComponent<MeshRenderer>().material = LE_D;
   //    rightEyeQuad1.GetComponent<MeshRenderer>().material = RE_U;
   //    rightEyeQuad2.GetComponent<MeshRenderer>().material = RE_D; 
   //    leftEyebrowQuad.GetComponent<MeshRenderer>().material = LEB;
   //    rightEyebrowQuad.GetComponent<MeshRenderer>().material = REB;
   //    lipQuad.GetComponent<MeshRenderer>().material = LIP;

   //    allQuadUp();
      
   // }



}

