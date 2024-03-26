using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameCore.Tool;
public class ImageData : Singleton<ImageData>
{
    //Image����·����
    public List<List<string[]>> ImagePath;
    //ͼƬ���Ʊ�·��
    public static string ImageExcelPath = Application.dataPath + "/Resources/DataExcel/Image/ImageDataExcel.xls";
    //ͼƬ��stringλ��
    public static int ImageExcelPathPlace = 1;
    //ͼƬ������
    public static int Image_Range = 10000;
    //ͼƬ����·��
    public static string ImageBasicPath = "Images/";
    public static int ImageIDPlace = 0;
    public override void Initialize()
    {
        //����ImagePath���ӹ��ò����е��ò�����·��
        ImagePath = GameComponent.LoadExcelDataByPath(ImageExcelPath);
    }
    public string GetImagePath(int imageID)
    {
        string path = null;
        int headID = int.Parse(ImagePath[0].Find(x => x[ImageIDPlace] == GetTypeID(imageID).ToString())[0]);
        if (imageID <= 10000)
        {
            Debug.LogWarning("�����ImageID:������С");
            return null;
        }
        try
        {
            //ȡIDͷλ�����������ͣ�ȡID��λ����ͼƬ����
            path = ImageBasicPath + ImagePath[0][headID][ImageExcelPathPlace]
                + "/" + ImagePath[headID].Find(x => x[ImageIDPlace] == GetCountID(imageID).ToString())[ImageExcelPathPlace];
        }
        catch(Exception e)
        {
            Debug.LogWarning(e.Message + "��ȡͼƬ·������ȷ!!!���������ImageID�Ƿ�Խ��");
            
        }
        return path;

    }
    public Sprite GetImage(int imageID)
    {
        //return null;
        Sprite sprite = Resources.Load<Sprite>(GetImagePath(imageID));
        //Debug.Log("ͼƬ·��" + sprite.name);
        return sprite;
    }
    public int GetCountID(int imageID)
    {
        return (imageID - ((imageID / Image_Range) * Image_Range));
    }
    public int GetTypeID(int imageID)
    {
        return imageID / Image_Range;
    }
    // Start is called before the first frame update
}
