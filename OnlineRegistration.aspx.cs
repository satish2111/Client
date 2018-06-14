using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelperLibrary;
using Website.Util;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;


namespace Website.forms
{
    public partial class OnlineRegistration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control myControlMenu = Page.Master.FindControl("navbarNav");
                Control lo = Page.Master.FindControl("Logoutid");
                Control loging = Page.Master.FindControl("loginid");
                if (myControlMenu != null)
                {
                    myControlMenu.Visible = false;
                    lo.Visible = false;
                    loging.Visible = true;
                }
                first.Visible = true;
                second.Visible = false;
                third.Visible = false;
                txtfirstname.Focus();
            }
            else if (this.IsPostBack)
            {
                if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
                {
                    string pwd = txtPassword.Text;
                    txtPassword.Attributes.Add("values", pwd);
                }
            }
        }

        protected void btufirst_Click(object sender, EventArgs e)
        {
            clsSqlHelper ObjBD = new clsSqlHelper(clsSettings.strsqlcon);
            Dictionary<string, object> DicData = new Dictionary<string, object>();
            DicData.Add("@emailid ", txtUserEmail.Text.Trim());
            if (ObjBD.objExecuteQuery("SpEmailIdAlready", HelperLibrary.clsSqlHelper.QueryExcution.storeProcedure, DicData))
            {
                DataTable dt = new DataTable();
                dt = ObjBD.objDataset.Tables[0];
                if (Convert.ToInt32(dt.Rows[0][0]) != -99 && txtPassword.Text == txtConfirmPassword.Text)
                {
                    first.Visible = false;
                    second.Visible = true;
                    third.Visible = false;
                    txtfamilyno.Focus();
                }
                else if (Convert.ToInt32(dt.Rows[0][0]) == -99 && txtPassword.Text == txtConfirmPassword.Text)
                {
                    Response.Write("<script>alert('Email ID is Already Exist');</script>");
                    txtUserEmail.Focus();
                    return;
                }
                else if (Convert.ToInt32(dt.Rows[0][0]) != -99 && txtPassword.Text != txtConfirmPassword.Text)
                {
                    Response.Write("<script>alert('The password and its confirm are not the same');</script>");
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }
            }
        }

        protected void btusecond_Click(object sender, EventArgs e)
        {
            first.Visible = false;
            second.Visible = false;
            third.Visible = true;
            filedadmomphoto.Focus();
        }

        protected void btuthird_Click(object sender, EventArgs e)
        {
            //bool isCaptchavalid = false;
            //if (Session["CaptchaText"] != null && Session["CaptchaText"].ToString() == txtcatcha.Text)
            //{
            //    isCaptchavalid = true;
            //}
            //if (isCaptchavalid)
            //{
            //    //lblMessage.Text = "Captcha Validation Success";
            //    //lblMessage.ForeColor = Color.Green;
            //}
            //else
            //{
            //    lblMessage.Text = "Captcha Validation fail";
            //    lblMessage.ForeColor = Color.Red;

            //}
            StringBuilder sb = new StringBuilder();
            int count = 1;
            if (string.IsNullOrEmpty(txtfirstname.Text))
            {
                sb.Append("first name, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtmiddlename.Text))
            {
                sb.Append("Middle name, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                sb.Append("Last name, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtaddress1.Text))
            {
                sb.Append("Address, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtUserPhone.Text))
            {
                sb.Append("Phone Number, ");
                count++;
            }
            if (string.IsNullOrEmpty(inputcity.Text))
            {
                sb.Append("City, ");
                count++;
            }
            if (string.IsNullOrEmpty(inputstatus.Text))
            {
                sb.Append("State, ");
                count++;
            }
            if (string.IsNullOrEmpty(inputcountry.Text))
            {
                sb.Append("Country, ");
                count++;
            }
            if (string.IsNullOrEmpty(inputpincode.Text))
            {
                sb.Append("Pincode, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtUserEmail.Text))
            {
                sb.Append("Email Id, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtfamilyno.Text))
            {
                sb.Append("Family No, ");
                count++;
            }
            if (string.IsNullOrEmpty(totalearning.Text))
            {
                sb.Append("Total Income, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtownrenthouse.Text))
            {
                sb.Append("Rent Or Own House, ");
                count++;
            }
            if (string.IsNullOrEmpty(txttotalmark.Text))
            {
                sb.Append("Total Mark, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtpercentage.Text))
            {
                sb.Append("Percentage, ");
                count++;
            }
            if (string.IsNullOrEmpty(inputcaste.Text))
            {
                sb.Append("Caste, ");
                count++;
            }
            if (string.IsNullOrEmpty(collagename.Text))
            {
                sb.Append("Collage Name, ");
                count++;
            }
            if (string.IsNullOrEmpty(txtstd.Text))
            {
                sb.Append("Standard, ");
                count++;
            }
            if (string.IsNullOrEmpty(filestudent.FileName))
            {
                sb.Append("Self Photo, ");
                count++;
            }
            if (string.IsNullOrEmpty(filelight.FileName))
            {
                sb.Append("Light Bill, ");
                count++;
            }
            if (string.IsNullOrEmpty(filemarksheet.FileName))
            {
                sb.Append("MarkSheet, ");
                count++;
            }
            if (string.IsNullOrEmpty(filecollage.FileName))
            {
                sb.Append("Collage Id, ");
                count++;
            }
            if (string.IsNullOrEmpty(fileaadhar.FileName))
            {
                sb.Append("Aadhar, ");
                count++;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(sb)))
            {
                string myError = sb.ToString().Trim().TrimEnd(',');

                Response.Write("<script>alert('Please fill the missing " + count + " details " + myError + "');</script>");
            }
            else
            {
                //To replace the filename, we need extension to be same, that's why took extension
                string PATH1 = "";
                string extsalary = Path.GetExtension(filesalary.FileName.ToString().ToLower());
                string extstudent = Path.GetExtension(filestudent.FileName.ToString().ToLower());
                string extlight = Path.GetExtension(filelight.FileName.ToString().ToLower());
                string extmarksheet = Path.GetExtension(filemarksheet.FileName.ToString().ToLower());
                string extcollage = Path.GetExtension(filecollage.FileName.ToString().ToLower());
                string extaadhar = Path.GetExtension(fileaadhar.FileName.ToString().ToLower());
                string extdadmom = Path.GetExtension(filedadmomphoto.FileName.ToString().ToLower());
                //

                //if client folder is not present
                var folder = Server.MapPath(@"~\clientimages");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }

                //validation of files
                FileUpload[] myFiles = new FileUpload[] { filestudent, filelight, filemarksheet, filecollage, fileaadhar, filedadmomphoto };
                if (!validationFile(myFiles))
                {
                    Response.Write("<script>alert('Please Select file ');</script>");
                    return;
                }

                // to get random folder name for users
                Guid objguid = Guid.NewGuid();
                string P = (objguid).ToString();
                var clientid = Server.MapPath(@"~\clientimages\" + (P.Replace("-", "")));
                if (!System.IO.Directory.Exists(clientid))
                {
                    System.IO.Directory.CreateDirectory(clientid);
                }

                //saving files in db with our names
                if (!string.IsNullOrEmpty(filesalary.FileName))
                {
                    filesalary.PostedFile.SaveAs(clientid + @"\salary" + extsalary);
                }
                filestudent.PostedFile.SaveAs(clientid + @"\student" + extstudent);
                filelight.PostedFile.SaveAs(clientid + @"\light" + extlight);
                filemarksheet.PostedFile.SaveAs(clientid + @"\marksheet" + extmarksheet);
                filecollage.PostedFile.SaveAs(clientid + @"\collage" + extcollage);
                fileaadhar.PostedFile.SaveAs(clientid + @"\aadhar" + extaadhar);
                fileaadhar.PostedFile.SaveAs(clientid + @"\guardian" + extdadmom);
                PATH1 = @"\clientimages\" + (P.Replace("-", ""));
                string PATH = PATH1;
                clsSqlHelper ObjBD = new clsSqlHelper(clsSettings.strsqlcon);
                Dictionary<string, object> DicData = new Dictionary<string, object>();
                DicData.Add("@firstname", txtfirstname.Text.ToUpper().Trim());
                DicData.Add("@middlename", txtmiddlename.Text.ToUpper().Trim());
                DicData.Add("@lastname", txtlastname.Text.ToUpper().Trim());
                DicData.Add("@address1", txtaddress1.Text.ToUpper().Trim());
                DicData.Add("@address2", txtaddress2.Text.ToUpper().Trim());
                DicData.Add("@moblie", txtUserPhone.Text.ToUpper().Trim());
                DicData.Add("@city", inputcity.Text.ToUpper().Trim());
                DicData.Add("@state", inputstatus.Text.ToUpper().Trim());
                DicData.Add("@country", inputcountry.Text.ToUpper().Trim());
                DicData.Add("@pincode", inputpincode.Text.ToUpper().Trim());
                DicData.Add("@emailid", txtUserEmail.Text.Trim());
                DicData.Add("@username", txtUserEmail.Text.Trim());
                DicData.Add("@password", txtPassword.Text);
                DicData.Add("@familymemberno", txtfamilyno.Text.Trim());
                DicData.Add("@familyincome", totalearning.Text.Trim());
                string house = string.Empty;
                if (txtownrenthouse.SelectedIndex == 1)
                    house = "Own House";
                else
                    house = "Rent House";
                DicData.Add("@ownhouseorrent", house);
                DicData.Add("@scholarship", txtscholarship.Text.Trim());
                DicData.Add("@totalmark", txttotalmark.Text.Trim());
                DicData.Add("@percentage", txtpercentage.Text.Trim());
                DicData.Add("@caste", inputcaste.Text.Trim());
                DicData.Add("@collagename", collagename.Text.ToUpper().Trim());
                DicData.Add("@std", txtstd.Text.Trim());
                DicData.Add("@attachsalaryproof", PATH + @"\salary" + extsalary);
                DicData.Add("@parentphoto", PATH + @"\guardian" + extdadmom);
                DicData.Add("@selfphoto", PATH + @"\student" + extstudent);
                DicData.Add("@lightbill", PATH + @"\light" + extlight);
                DicData.Add("@marksheet", PATH + @"\marksheet" + extmarksheet);
                DicData.Add("@collegeid", PATH + @"\collage" + extcollage);
                DicData.Add("@aadharcard", PATH + @"\aadhar" + extaadhar);
                DicData.Add("@StatementType", "INSERT");
                if (ObjBD.objExecuteQuery("SpInsertUserinfrom", HelperLibrary.clsSqlHelper.QueryExcution.storeProcedure, DicData))
                {
                    DataTable dt = new DataTable();
                    dt = ObjBD.objDataset.Tables[0];
                    if (Convert.ToInt32(dt.Rows[0][0]) != -99)
                    {
                        Session["name"] = dt.Rows[0][1].ToString();
                        Session["id"] = dt.Rows[0][0].ToString();
                        Response.Write("<script>alert('Please Accept The Terms And Conditions');</script>");
                        Server.Transfer("teamandcondition.aspx", true);

                        ClearTextBoxes(Page);
                    }
                    else if (Convert.ToInt32(dt.Rows[0][0]) == -99)
                    {
                        Response.Write("<script>alert('Email ID is Already Exist');</script>");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// To check file is present or not and size of file to be 2mb
        /// </summary>
        /// <param name="files"></param>
        /// <returns>true or false</returns>
        private bool validationFile(FileUpload[] files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (!file.HasFile && file.PostedFile.ContentLength > 2000000 && string.IsNullOrEmpty(file.FileName))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }

        protected void btuback1_Click(object sender, EventArgs e)
        {
            first.Visible = true;
            second.Visible = false;
            third.Visible = false;
        }

        protected void btuback2_Click(object sender, EventArgs e)
        {
            first.Visible = false;
            second.Visible = true;
            third.Visible = false;
        }

        //protected void btunewcode_Click(object sender, EventArgs e)
        //{
        //    imgcatcha.ImageUrl = "~/imagecatcha.aspx";
        //}

    }
}

