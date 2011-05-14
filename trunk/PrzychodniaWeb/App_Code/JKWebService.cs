using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;
using BLL;
using DAL;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for JKWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class JKWebService : System.Web.Services.WebService {

    public JKWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetKjgContent(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        List<Kod_jednostki_grupa> kjgl = Repository.GetAllKJG();

        foreach (Kod_jednostki_grupa k in kjgl)
        {
            values.Add(new CascadingDropDownNameValue(k.Name, k.id.ToString()));
        }

        return values.ToArray<CascadingDropDownNameValue>();

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetKjpgContent(string knownCategoryValues, string category)
    {
        
        int targetID = 0;
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        if (!kv.ContainsKey("KJG") || !Int32.TryParse(kv["KJG"], out targetID))
        {
            return null;
        }

        //if (!string.IsNullOrEmpty(knownCategoryValues))
        //    int.TryParse(
        //        Regex.Match(knownCategoryValues,
        //                     @"(\d+)",
        //                     RegexOptions.Compiled).Groups[0].Value,
        //                     out targetID);


        IEnumerable<CascadingDropDownNameValue> vals = null;

        vals =
            from x in Repository.GetAllKJPG(targetID)
            select new CascadingDropDownNameValue { name = x.Name, value = x.id.ToString() };


        return vals.ToArray<CascadingDropDownNameValue>();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetKjContent(string knownCategoryValues, string category)
    {      
        int targetID = 0;

        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        if (!kv.ContainsKey("KJPG") || !Int32.TryParse(kv["KJPG"], out targetID))
        {
            return null;
        }

        //if (!string.IsNullOrEmpty(knownCategoryValues))
        //    int.TryParse(
        //        Regex.Match(knownCategoryValues,
        //                     @"(\d+)",
        //                     RegexOptions.Compiled).Groups[0].Value,
        //                     out targetID);

        IEnumerable<CascadingDropDownNameValue> vals = null;

        vals =
            from x in Repository.GetAllKJ(targetID)
            select new CascadingDropDownNameValue { name = x.Name, value = x.id.ToString() };

        return vals.ToArray<CascadingDropDownNameValue>();
    }
    
}
