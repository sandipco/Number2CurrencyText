using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ConvertNumber.Models;
using System.Web.UI.WebControls;

namespace ConvertNumber
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            double i;
            try
            {
                if (Page.IsValid)
                {
                    if (double.TryParse(txtNo.Text, out i))
                    {
                        i = Math.Round(i, 2);
                        txtNo.Text = i.ToString();
                        NumberToText _obj = new NumberToText();
                        _obj.noToConvert = i;
                        lblResult.Text = _obj.getConvertedValue();

                    }
                }
            }
            catch(System.Exception ex)
            {
                //No time to catch error systematically
                lblResult.Text = ex.ToString();
            }
        }
    }
}