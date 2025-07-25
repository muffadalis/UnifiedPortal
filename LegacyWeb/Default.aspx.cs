﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegacyWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionTextBox.Text = Session["Mumin_ID"]?.ToString() ?? string.Empty;
            }
        }

        protected void SubmitSessionButton_Click(object sender, EventArgs e)
        {
            Session["Mumin_ID"] = SessionTextBox.Text;
        }
    }
}