using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameCore.Tool;
public class ImageData : Singleton<ImageData>
{
    //Image数据路径表
    public List<List<string[]>> ImagePath;
    //图片名称表路径
    public static string ImageExcelPath = Application.dataPath + "/Resources/DataExcel/Image/ImageDataExcel.xls";
    //图片表string位置
    public static int ImageExcelPathPlace = 1;
    //图片表类间距
    public static int Image_Range = 10000;
    //图片基础路径
    public static string ImageBasicPath = "Images/";
    public static int ImageIDPlace = 0;
    public override void Initialize()
    {
        //载入ImagePath表，从公用参数中调用并输入路径
        ImagePath = GameComponent.LoadExcelDataByPath(ImageExcelPath);
    }
    public string GetImagePath(int imageID)
    {
        string path = null;
        int headID = int.Parse(ImagePath[0].Find(x => x[ImageIDPlace] == GetTypeID(imageID).ToString())[0]);
        if (imageID <= 10000)
        {
            Debug.LogWarning("错误的ImageID:过大或过小");
            return null;
        }
        try
        {
            //取ID头位数得所属类型，取ID子位数得图片名字
            path = ImageBasicPath + ImagePath[0][headID][ImageExcelPathPlace]
                + "/" + ImagePath[headID].Find(x => x[ImageIDPlace] == GetCountID(imageID).ToString())[ImageExcelPathPlace];
        }
        catch(Exception e)
        {
            Debug.LogWarning(e.Message + "获取图片路径不正确!!!请检查输入的ImageID是否越界");
            
        }
        return path;

    }
    public Sprite GetImage(int imageID)
    {
        //return null;
        Sprite sprite = Resources.Load<Sprite>(GetImagePath(imageID));
        //Debug.Log("图片路径" + sprite.name);
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
