using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage_Manager : MonoBehaviour {
   public GameObject contents_w_1;
   public GameObject contents_w_2;

   public GameObject contents_w_3;
   public GameObject contents_w_4;
   public GameObject contents_w_5;
   public GameObject contents_m_1;
   public GameObject contents_m_2;

   public GameObject Mencategory;
   public GameObject WoMencategory;
   public GameObject prefab;

   public Image MenCategoryButtonImage;

   public Text MenCategoryButtonText;
   public Image WoMenCategoryButtonImage;

   public Text WoMenCategoryButtonText;

   public Text W_1;

   public Text W_2;
   public Text W_3;
   public Text W_4;
   public Text W_5;
   public Text M_1;
   public Text M_2;


	public static bool isFirst = true;
   
   // Use this for initialization
   void Start () {
	   //Debug.Log("isfirst" + " " + isFirst);

	  	StartCoroutine(w_1());
      StartCoroutine(w_2());
      StartCoroutine(w_3());
      StartCoroutine(w_4());
      StartCoroutine(w_5());
      StartCoroutine(m_1());
      StartCoroutine(m_2());
      
   }
   
   // Update is called once per frame
   void Update () {
	   
	  	
      
   }
   IEnumerator w_1(){

      WWW list_w_1_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/test%2F%E1%84%8B%E1%85%A7_1_1.png?alt=media&token=5959c237-2b2e-4893-a44d-908cc1caf7a7");
      yield return list_w_1_1;
      GameObject go_w_1_1 = Instantiate(prefab) as GameObject;
      go_w_1_1.AddComponent<LayoutElement>();
      go_w_1_1.GetComponent<LayoutElement>().minWidth = 900;
      go_w_1_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_w_1_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_w_1_1.texture;
      go_w_1_1.transform.parent = contents_w_1.transform;
      go_w_1_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F1%2Fw_1_1.txt?alt=media&token=8523e2ff-cc08-4fe6-ac41-354ecf0a0746");
        yield return text1;

        go_w_1_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_w_1_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/test%2F%E1%84%8B%E1%85%A7_1_2.png?alt=media&token=15d679aa-b207-40d3-bb5e-102d7261c521");
        yield return list_w_1_2;
      GameObject go_w_1_2 = Instantiate(prefab) as GameObject;
      go_w_1_2.AddComponent<LayoutElement>();
      go_w_1_2.GetComponent<LayoutElement>().minWidth = 900;
      go_w_1_2.GetComponent<LayoutElement>().minHeight = 300;

        go_w_1_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_1_2.texture;
        go_w_1_2.transform.parent = contents_w_1.transform;
        go_w_1_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F1%2Fw_1_2.txt?alt=media&token=a4aa2d6c-4309-41a0-ad43-1ca7536b6089");
        yield return text2;

        go_w_1_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_w_1_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/test%2F%E1%84%8B%E1%85%A7_1_3.png?alt=media&token=de109c5a-70d4-47b2-8a42-cd3780dfb35c");
        yield return list_w_1_3;
      GameObject go_w_1_3 = Instantiate(prefab) as GameObject;
      go_w_1_3.AddComponent<LayoutElement>();
      go_w_1_3.GetComponent<LayoutElement>().minWidth = 900;
      go_w_1_3.GetComponent<LayoutElement>().minHeight = 300;

        go_w_1_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_1_3.texture;
        go_w_1_3.transform.parent = contents_w_1.transform;
        go_w_1_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F1%2Fw_1_3.txt?alt=media&token=9dde3e28-ae96-45e2-a047-73d5b68ac283");
        yield return text3;

        go_w_1_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

		


   }

    IEnumerator w_2(){
             WWW list_w_2_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_1.png?alt=media&token=a0e34e52-2467-44f9-81ed-c80e6b383d9d");
      yield return list_w_2_1;
      GameObject go_w_2_1 = Instantiate(prefab) as GameObject;
      go_w_2_1.AddComponent<LayoutElement>();
      go_w_2_1.GetComponent<LayoutElement>().minWidth = 900;
      go_w_2_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_w_2_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_w_2_1.texture;
      go_w_2_1.transform.parent = contents_w_2.transform;
      go_w_2_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_1.txt?alt=media&token=25250679-8455-4605-a96b-cc0d53d51dd5");
        yield return text1;

        go_w_2_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_w_2_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_2.png?alt=media&token=b8232d99-dbe1-4580-9bb3-defa185677d3");
        yield return list_w_2_2;
      GameObject go_w_2_2 = Instantiate(prefab) as GameObject;
      go_w_2_2.AddComponent<LayoutElement>();
      go_w_2_2.GetComponent<LayoutElement>().minWidth = 900;
      go_w_2_2.GetComponent<LayoutElement>().minHeight = 300;

        go_w_2_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_2_2.texture;
        go_w_2_2.transform.parent = contents_w_2.transform;
        go_w_2_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_2.txt?alt=media&token=4854cf96-ffe4-4cd5-a8f4-f0d5a60024fa");
        yield return text2;

        go_w_2_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_w_2_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_3.png?alt=media&token=339b3895-c402-42f2-8aa7-a2e96732abf1");
        yield return list_w_2_3;
      GameObject go_w_2_3 = Instantiate(prefab) as GameObject;
      go_w_2_3.AddComponent<LayoutElement>();
      go_w_2_3.GetComponent<LayoutElement>().minWidth = 900;
      go_w_2_3.GetComponent<LayoutElement>().minHeight = 300;

        go_w_2_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_2_3.texture;
        go_w_2_3.transform.parent = contents_w_2.transform;
        go_w_2_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F2%2Fw_2_3.txt?alt=media&token=7442c51c-a9cc-400e-b559-e44889dd18d5");
        yield return text3;

        go_w_2_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }

        IEnumerator w_3(){
             WWW list_w_3_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_1.png?alt=media&token=77ea63d5-67d2-4934-bd55-5d3f9a24ea6a");
      yield return list_w_3_1;
      GameObject go_w_3_1 = Instantiate(prefab) as GameObject;
      go_w_3_1.AddComponent<LayoutElement>();
      go_w_3_1.GetComponent<LayoutElement>().minWidth = 900;
      go_w_3_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_w_3_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_w_3_1.texture;
      go_w_3_1.transform.parent = contents_w_3.transform;
      go_w_3_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_1.txt?alt=media&token=29937828-3ce8-47bf-a4aa-2f48882107d4");
        yield return text1;

        go_w_3_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_w_3_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_2.png?alt=media&token=fb4d44e1-6ab3-4590-b2ff-f397e90d7d73");
        yield return list_w_3_2;
      GameObject go_w_3_2 = Instantiate(prefab) as GameObject;
      go_w_3_2.AddComponent<LayoutElement>();
      go_w_3_2.GetComponent<LayoutElement>().minWidth = 900;
      go_w_3_2.GetComponent<LayoutElement>().minHeight = 300;

        go_w_3_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_3_2.texture;
        go_w_3_2.transform.parent = contents_w_3.transform;
        go_w_3_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_2.txt?alt=media&token=91b20e82-f9a1-4e08-9619-99c96c56ad5f");
        yield return text2;

        go_w_3_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_w_3_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_3.png?alt=media&token=369133b8-ea24-4768-a643-052890df7ee5");
        yield return list_w_3_3;
      GameObject go_w_3_3 = Instantiate(prefab) as GameObject;
      go_w_3_3.AddComponent<LayoutElement>();
      go_w_3_3.GetComponent<LayoutElement>().minWidth = 900;
      go_w_3_3.GetComponent<LayoutElement>().minHeight = 300;

        go_w_3_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_3_3.texture;
        go_w_3_3.transform.parent = contents_w_3.transform;
        go_w_3_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F3%2Fw_3_3.txt?alt=media&token=8ec810de-c35b-453d-bfbf-d6591d0b0eb2");
        yield return text3;

        go_w_3_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }

        IEnumerator w_4(){
             WWW list_w_4_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_1.png?alt=media&token=5e1fb62f-f8d5-45bb-b057-35376df16704");
      yield return list_w_4_1;
      GameObject go_w_4_1 = Instantiate(prefab) as GameObject;
      go_w_4_1.AddComponent<LayoutElement>();
      go_w_4_1.GetComponent<LayoutElement>().minWidth = 900;
      go_w_4_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_w_4_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_w_4_1.texture;
      go_w_4_1.transform.parent = contents_w_4.transform;
      go_w_4_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_1.txt?alt=media&token=6ffa90a5-d06f-40f1-8514-3b0bf2eb7a57");
        yield return text1;

        go_w_4_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_w_4_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_2.png?alt=media&token=a086a9e0-ca9c-4d19-a4ed-1deb368c4031");
        yield return list_w_4_2;
      GameObject go_w_4_2 = Instantiate(prefab) as GameObject;
      go_w_4_2.AddComponent<LayoutElement>();
      go_w_4_2.GetComponent<LayoutElement>().minWidth = 900;
      go_w_4_2.GetComponent<LayoutElement>().minHeight = 300;

        go_w_4_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_4_2.texture;
        go_w_4_2.transform.parent = contents_w_4.transform;
        go_w_4_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_2.txt?alt=media&token=f777ec44-2b96-4d10-b2e2-fc4b05787c71");
        yield return text2;

        go_w_4_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_w_4_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_3.png?alt=media&token=e0d513e5-8658-4ba6-883d-4b7cc485e715");
        yield return list_w_4_3;
      GameObject go_w_4_3 = Instantiate(prefab) as GameObject;
      go_w_4_3.AddComponent<LayoutElement>();
      go_w_4_3.GetComponent<LayoutElement>().minWidth = 900;
      go_w_4_3.GetComponent<LayoutElement>().minHeight = 300;

        go_w_4_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_4_3.texture;
        go_w_4_3.transform.parent = contents_w_4.transform;
        go_w_4_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F4%2Fw_4_3.txt?alt=media&token=22bb7ac9-9ad2-427b-940c-d636f3a9f782");
        yield return text3;

        go_w_4_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }

        IEnumerator w_5(){
             WWW list_w_5_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_1.png?alt=media&token=63b49336-7601-4bf3-a0a2-03105f782790");
      yield return list_w_5_1;
      GameObject go_w_5_1 = Instantiate(prefab) as GameObject;
      go_w_5_1.AddComponent<LayoutElement>();
      go_w_5_1.GetComponent<LayoutElement>().minWidth = 900;
      go_w_5_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_w_5_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_w_5_1.texture;
      go_w_5_1.transform.parent = contents_w_5.transform;
      go_w_5_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_1.txt?alt=media&token=18b6bddb-344e-4fa4-ab9a-80ccd14a9a0c");
        yield return text1;

        go_w_5_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_w_5_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_2.png?alt=media&token=76fe5744-0571-4702-bcb5-707567324f7e");
        yield return list_w_5_2;
      GameObject go_w_5_2 = Instantiate(prefab) as GameObject;
      go_w_5_2.AddComponent<LayoutElement>();
      go_w_5_2.GetComponent<LayoutElement>().minWidth = 900;
      go_w_5_2.GetComponent<LayoutElement>().minHeight = 300;

        go_w_5_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_5_2.texture;
        go_w_5_2.transform.parent = contents_w_5.transform;
        go_w_5_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_2.txt?alt=media&token=934f1be8-4c73-4a8d-86dc-e3c0126a2ff0");
        yield return text2;

        go_w_5_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_w_5_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_3.png?alt=media&token=12af7b88-d7cb-4e13-84a9-499125a89e90");
        yield return list_w_5_3;
      GameObject go_w_5_3 = Instantiate(prefab) as GameObject;
      go_w_5_3.AddComponent<LayoutElement>();
      go_w_5_3.GetComponent<LayoutElement>().minWidth = 900;
      go_w_5_3.GetComponent<LayoutElement>().minHeight = 300;

        go_w_5_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_w_5_3.texture;
        go_w_5_3.transform.parent = contents_w_5.transform;
        go_w_5_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fwomen%2F5%2Fw_5_3.txt?alt=media&token=ce1081c0-6c53-4512-af3c-934ea4b0cc41");
        yield return text3;

        go_w_5_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }

        IEnumerator m_1(){
             WWW list_m_1_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_1.png?alt=media&token=d68387ef-d212-4afc-aabd-3ad3ce67be40");
      yield return list_m_1_1;
      GameObject go_m_1_1 = Instantiate(prefab) as GameObject;
      go_m_1_1.AddComponent<LayoutElement>();
      go_m_1_1.GetComponent<LayoutElement>().minWidth = 900;
      go_m_1_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_m_1_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_m_1_1.texture;
      go_m_1_1.transform.parent = contents_m_1.transform;
      go_m_1_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_1.txt?alt=media&token=6c7970c6-2630-4c25-85bb-41f85775ea1a");
        yield return text1;

        go_m_1_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_m_1_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_2.png?alt=media&token=fb948ad0-b112-4a6c-b3d5-94cbe9129151");
        yield return list_m_1_2;
      GameObject go_m_1_2 = Instantiate(prefab) as GameObject;
      go_m_1_2.AddComponent<LayoutElement>();
      go_m_1_2.GetComponent<LayoutElement>().minWidth = 900;
      go_m_1_2.GetComponent<LayoutElement>().minHeight = 300;

        go_m_1_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_m_1_2.texture;
        go_m_1_2.transform.parent = contents_m_1.transform;
        go_m_1_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_2.txt?alt=media&token=5d2b801d-f3f5-4935-80e9-2a3c999685ca");
        yield return text2;

        go_m_1_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_m_1_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_3.png?alt=media&token=b8cf07e0-9a84-4d9a-a560-7e2a4331516b");
        yield return list_m_1_3;
      GameObject go_m_1_3 = Instantiate(prefab) as GameObject;
      go_m_1_3.AddComponent<LayoutElement>();
      go_m_1_3.GetComponent<LayoutElement>().minWidth = 900;
      go_m_1_3.GetComponent<LayoutElement>().minHeight = 300;

        go_m_1_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_m_1_3.texture;
        go_m_1_3.transform.parent = contents_m_1.transform;
        go_m_1_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F1%2Fm_1_3.txt?alt=media&token=f7816783-05a1-47fc-af56-e0e497e6758a");
        yield return text3;

        go_m_1_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }

        IEnumerator m_2(){
             WWW list_m_2_1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_1.png?alt=media&token=e102d841-4a7c-495b-b26a-4a31afece997");
      yield return list_m_2_1;
      GameObject go_m_2_1 = Instantiate(prefab) as GameObject;
      go_m_2_1.AddComponent<LayoutElement>();
      go_m_2_1.GetComponent<LayoutElement>().minWidth = 900;
      go_m_2_1.GetComponent<LayoutElement>().minHeight = 300;
      
      go_m_2_1.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture= list_m_2_1.texture;
      go_m_2_1.transform.parent = contents_m_2.transform;
      go_m_2_1.transform.localPosition = new Vector3(0,0,0);

        WWW text1 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_1.txt?alt=media&token=e1abcad7-87e6-4545-890d-cd0a88f20211");
        yield return text1;

        go_m_2_1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text1.text;
		

        WWW list_m_2_2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_2.png?alt=media&token=70d6fdca-3fee-4a7b-ae80-16f9adfb57a4");
        yield return list_m_2_2;
      GameObject go_m_2_2 = Instantiate(prefab) as GameObject;
      go_m_2_2.AddComponent<LayoutElement>();
      go_m_2_2.GetComponent<LayoutElement>().minWidth = 900;
      go_m_2_2.GetComponent<LayoutElement>().minHeight = 300;

        go_m_2_2.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_m_2_2.texture;
        go_m_2_2.transform.parent = contents_m_2.transform;
        go_m_2_2.transform.localPosition = new Vector3(0, 0, 0);

        WWW text2 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_2.txt?alt=media&token=3f165ba2-cd1a-4b0f-a1c7-9ae9e19bc8b1");
        yield return text2;

        go_m_2_2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text2.text;
		

        WWW list_m_2_3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_3.png?alt=media&token=a7cbcb15-569a-4b3b-b5d4-bb1ae5120156");
        yield return list_m_2_3;
      GameObject go_m_2_3 = Instantiate(prefab) as GameObject;
      go_m_2_3.AddComponent<LayoutElement>();
      go_m_2_3.GetComponent<LayoutElement>().minWidth = 900;
      go_m_2_3.GetComponent<LayoutElement>().minHeight = 300;

        go_m_2_3.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = list_m_2_3.texture;
        go_m_2_3.transform.parent = contents_m_2.transform;
        go_m_2_3.transform.localPosition = new Vector3(0, 0, 0);

        WWW text3 = new WWW("https://firebasestorage.googleapis.com/v0/b/fireb-test-e9338.appspot.com/o/Leporem%2Fmen%2F2%2Fm_2_3.txt?alt=media&token=308d45fd-a75e-4d39-af54-f5cdf919489d");
        yield return text3;

        go_m_2_3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = text3.text;

        }


        public int MenOrWoMenCategory = 2;

        public int CategoryNum = 1;

        public int beforeCategoryNum = 1;

        public int currentCategoryNum = 1;


        public void Show_Category_Men(){

          Mencategory.SetActive(true);
          WoMencategory.SetActive(false);

        }
        public void Show_Category_Women(){
          WoMencategory.SetActive(true);
          Mencategory.SetActive(false);
        }
        public void Show_Contents_W_1(){

          contents_w_1.SetActive(true);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(false);
          

        }
        public void Show_Contents_W_2(){
          contents_w_1.SetActive(false);
          contents_w_2.SetActive(true);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(false);

        }
        public void Show_Contents_W_3(){
          contents_w_1.SetActive(false);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(true);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(false);

        }
        public void Show_Contents_W_4(){

          contents_w_1.SetActive(false);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(true);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(false);

        }
        public void Show_Contents_W_5(){

          contents_w_1.SetActive(false);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(true);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(false);

        }
        public void Show_Contents_M_1(){
          contents_w_1.SetActive(false);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(true);
          contents_m_2.SetActive(false);
        }
        public void Show_Contents_M_2(){
          contents_w_1.SetActive(false);
          contents_w_2.SetActive(false);
          contents_w_3.SetActive(false);
          contents_w_4.SetActive(false);
          contents_w_5.SetActive(false);
          contents_m_1.SetActive(false);
          contents_m_2.SetActive(true);

        }

        



            




        
        



        public void OnMenCategoryButtonClick(){
          Color buttonColor;

          if(MenOrWoMenCategory == 2){

            buttonColor = MenCategoryButtonImage.color;
            buttonColor = MenCategoryButtonText.color;

            buttonColor.a = 1f;

            MenCategoryButtonImage.color = buttonColor;
            MenCategoryButtonText.color = buttonColor;

            buttonColor = WoMenCategoryButtonImage.color;
            buttonColor = WoMenCategoryButtonText.color;

            buttonColor.a = 0.5f;
            
            WoMenCategoryButtonImage.color = buttonColor;
            WoMenCategoryButtonText.color = buttonColor;

            MenOrWoMenCategory = 1;

            
          }

          

        }

        public void OnWoMenCategoryButtonClick(){

          Color buttonColor;

          if(MenOrWoMenCategory == 1){

            buttonColor = MenCategoryButtonImage.color;
            buttonColor = MenCategoryButtonText.color;

            buttonColor.a = 0.5f;

            MenCategoryButtonImage.color = buttonColor;
            MenCategoryButtonText.color = buttonColor;

            buttonColor = WoMenCategoryButtonImage.color;
            buttonColor = WoMenCategoryButtonText.color;

            buttonColor.a = 1f;
            
            WoMenCategoryButtonImage.color = buttonColor;
            WoMenCategoryButtonText.color = buttonColor;

            MenOrWoMenCategory = 2;
            
          }
          
        }

        public void onFirstProductButtonClick(){

          Debug.Log(currentCategoryNum);
          
         if(currentCategoryNum == 1){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=아보카도+안티+링클+아이크림&channel=user");
         }else if(currentCategoryNum == 2){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=세이프+미+릴리프+모이스처+클렌징+폼&channel=user");
         }else if(currentCategoryNum == 3){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=블러쉬+[섹스어필]&channel=user");
         }else if(currentCategoryNum == 4){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=룩+앳+마이+아이즈+%5BBR422+솔솔말린솔방울%5D&channel=user");
         }else if(currentCategoryNum == 5){
           Application.OpenURL("https://www.coupang.com/np/search?q=호호바%20립에센스&channel=auto");
         }else if(currentCategoryNum == 6){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=레스큐+워터+로션&channel=user");
         }else{
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=화이트닝+톤+업+크림&channel=user");
         } 
        }

        public void onSecondProductButtonClick(){

          Debug.Log(currentCategoryNum);

         if(currentCategoryNum == 1){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=1025+독도+토너&channel=user");
         }else if(currentCategoryNum == 2){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=1025+독도+클렌저&channel=user");
         }else if(currentCategoryNum == 3){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=잉크래스팅+파운데이션+슬림+핏+[SPF30/PA++]&channel=user");
         }else if(currentCategoryNum == 4){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=룩+앳+마이+아이즈+%5BBR407+해변에선코코넛%5D&channel=user");
         }else if(currentCategoryNum == 5){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=라스트+벨벳+립+틴트+%5B02+생기갑%5D&channel=user");
         }else if(currentCategoryNum == 6){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=포레스트+포+맨+모이스처+올인원+에센스&channel=user");
         }else{
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=에너지+팩토리+맨즈+밤&channel=user");
         } 
        }

        public void onThirdProductButtonClick(){

          Debug.Log(currentCategoryNum);

         if(currentCategoryNum == 1){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=레드+블레미쉬+클리어+수딩+크림&channel=user");
         }else if(currentCategoryNum == 2){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=퓨어+밸런싱+클렌징+오일&channel=user");
         }else if(currentCategoryNum == 3){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=더블+웨어+스테이+인+플레이스+메이크업+파운데이션+%5BSPF10%2FPA%2B%2B%5D+%5B쿨본%5D&channel=user");
         }else if(currentCategoryNum == 4){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=매그니피센트+메탈+글리터%26글로우+리퀴드+아이섀도우+%5B키튼카르마%5D&channel=user");
         }else if(currentCategoryNum == 5){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=불가리안+로즈+립+트리트먼트+밤+%5B퓨어레드%5D&channel=user");
         }else if(currentCategoryNum == 6){
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=올인원+모이스처라이저+스킨+밀크&channel=user");
         }else{
           Application.OpenURL("https://www.coupang.com/np/search?component=&q=화이트닝+옴므+에센스&channel=user");
         } 
        }

        public void on_W_1_ButtonClick(){

            currentCategoryNum = 1;
            Colortoggle();
          
        }
        public void on_W_2_ButtonClick(){
          currentCategoryNum = 2;
            Colortoggle();
          
        }
        public void on_W_3_ButtonClick(){
          currentCategoryNum = 3;
            Colortoggle();
        }
        public void on_W_4_ButtonClick(){
          currentCategoryNum = 4;
            Colortoggle();
          
        }
        public void on_W_5_ButtonClick(){
          currentCategoryNum = 5;
            Colortoggle();
          
        }
        public void on_M_1_ButtonClick(){
          currentCategoryNum = 6;
            Colortoggle();

        }
        public void on_M_2_ButtonClick(){
          currentCategoryNum = 7;
            Colortoggle(); 
        }

        public void Colortoggle(){
          Color CategoryColor;

          if(beforeCategoryNum == 1){
            CategoryColor = W_1.color;

            CategoryColor.a = 0.5f;

            W_1.color = CategoryColor;
          }
          else if(beforeCategoryNum == 2){
            CategoryColor = W_2.color;

            CategoryColor.a = 0.5f;

            W_2.color = CategoryColor;
            
          }
          else if(beforeCategoryNum == 3){
            CategoryColor = W_3.color;

            CategoryColor.a = 0.5f;

            W_3.color = CategoryColor;
            
          }
          else if(beforeCategoryNum == 4){
            CategoryColor = W_4.color;

            CategoryColor.a = 0.5f;

            W_4.color = CategoryColor;
          }
          else if(beforeCategoryNum == 5){
            CategoryColor = W_5.color;

            CategoryColor.a = 0.5f;

            W_5.color = CategoryColor;
            
          }
          else if(beforeCategoryNum == 6){
            CategoryColor = M_1.color;

            CategoryColor.a = 0.5f;

            M_1.color = CategoryColor;
          }
          else{
            CategoryColor = M_2.color;

            CategoryColor.a = 0.5f;

            M_2.color = CategoryColor;
          }

          if(currentCategoryNum == 1){
            CategoryColor = W_1.color;

            CategoryColor.a = 1f;

            W_1.color = CategoryColor;


            beforeCategoryNum = 1;
          }
          else if(currentCategoryNum == 2){
            CategoryColor = W_2.color;

            CategoryColor.a = 1f;

            W_2.color = CategoryColor;

            beforeCategoryNum = 2;
          }
          else if(currentCategoryNum == 3){
            CategoryColor = W_3.color;

            CategoryColor.a = 1f;

            W_3.color = CategoryColor;

            beforeCategoryNum = 3;
          }
          else if(currentCategoryNum == 4){
            CategoryColor = W_4.color;

            CategoryColor.a = 1f;

            W_4.color = CategoryColor;

            beforeCategoryNum = 4;
          }
          else if(currentCategoryNum == 5){
            CategoryColor = W_5.color;

            CategoryColor.a = 1f;

            W_5.color = CategoryColor;

            beforeCategoryNum = 5;
          }
          else if(currentCategoryNum == 6){
            CategoryColor = M_1.color;

            CategoryColor.a = 1f;

            M_1.color = CategoryColor;
            beforeCategoryNum = 6;
          }
          else {
            CategoryColor = M_2.color;

            CategoryColor.a = 1f;

            M_2.color = CategoryColor;

            beforeCategoryNum = 7;
          }


        }


}