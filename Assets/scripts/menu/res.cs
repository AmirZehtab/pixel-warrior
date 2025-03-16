using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Res : MonoBehaviour
{
    public TMP_Dropdown resd; // Dropdown برای انتخاب رزولوشن
    private Resolution[] allRes; // آرایه‌ای از تمام رزولوشن‌های سیستم
    private List<Resolution> selectedList = new List<Resolution>(); // لیستی برای ذخیره رزولوشن‌های یکتا

    void Start()
    {
        allRes = Screen.resolutions; // دریافت لیست رزولوشن‌های پشتیبانی شده

        List<string> resStringList = new List<string>();
        string newRes;
        int currentResIndex = 0; // ذخیره موقعیت رزولوشن فعلی در لیست

        // دریافت رزولوشن فعلی مانیتور
        Resolution currentRes = Screen.currentResolution;

        foreach (Resolution res in allRes)
        {
            newRes = res.width.ToString() + " x " + res.height.ToString();

            if (!resStringList.Contains(newRes))
            {
                resStringList.Add(newRes);
                selectedList.Add(res);
                
                // بررسی اینکه این رزولوشن همان رزولوشن فعلی است یا خیر
                if (res.width == currentRes.width && res.height == currentRes.height)
                {
                    currentResIndex = selectedList.Count - 1; // ذخیره موقعیت در لیست
                }
            }
        }

        // اضافه کردن گزینه‌ها به Dropdown فقط یکبار
        resd.ClearOptions();
        resd.AddOptions(resStringList);

        // تنظیم مقدار پیش‌فرض مطابق رزولوشن فعلی
        resd.value = currentResIndex;
        resd.RefreshShownValue();
    }

    public void ChangeRes()
    {
        int selected = resd.value;
        Screen.SetResolution(selectedList[selected].width, selectedList[selected].height, true);


    }
}

