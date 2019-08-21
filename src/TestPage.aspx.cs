using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class TestPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //m1();
    }

    void m3()
    {
    }

    void m2()
    {
        string[] names = { "amit", "tushar", "panda", "ritesh", "chandan", "saga", "suchi", "sanket", "soumya", "sam", "sammy", "sandy", "micheal", "andy", "pete", "steve", "bill" };

        TextBox1.Text = "names:\t";

        foreach (string element in names)
            TextBox1.Text += element.ToString() + " ";

        TextBox1.Text += "\n\nresults:\t";

        foreach (string element in names)
            TextBox1.Text += element[0].ToString() + " ";
    }

    void m1()
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

        string[] names = new string[DB.UserInfos.Count() * 3];

        var res = from v in DB.GetTable<UserInfo>() select v;
        int i = -1;
        foreach (var r in res)
        {
            names[++i] = r.UserFirstName.ToString().Trim();
            names[++i] = r.UserLastName.ToString().Trim();
            names[++i] = r.Username.ToString().Trim();
        }

        TextBox1.Text = "names:\t";
        foreach (string s in names)
            TextBox1.Text += s + " ";
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "SearchTerm = '" + txtName.Text + "'";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() != "")
            if (txtName.Text[0] == '[')
                TextBox1.Text = "'[' found!";
            else TextBox1.Text = "'[' not found!";
    }
}