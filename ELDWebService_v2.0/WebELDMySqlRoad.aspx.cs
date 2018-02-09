using ELDWebService_v2._0.BusinessLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELDWebService_v2._0
{
    public partial class WebELDMySql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void but_add_Click(object sender, EventArgs e)
        {
            Entity.Road model = new Entity.Road();
            int r_id = int.Parse(this.txtr_id.Text);
            string r_name = this.txtr_name.Text;
            string picPath = this.txtpicPath.Text;
            bool IsCreatePicture = this.chkIsCreatePicture.Checked;
            decimal r_width = decimal.Parse(this.txtr_width.Text);
            int eld_pictureWidth = int.Parse(this.txteld_pictureWidth.Text);
            int eld_pictureHeight = int.Parse(this.txteld_pictureHeight.Text);
            int eld_regionWidth = int.Parse(this.txteld_regionWidth.Text);
            int eld_regionHeight = int.Parse(this.txteld_regionHeight.Text);
            string eld_rmtHost = this.txteld_rmtHost.Text;
            bool IsConnectELD = this.chkIsConnectELD.Checked;
            int locPort = int.Parse(this.txtlocPort.Text);
            int rmtPort = int.Parse(this.txtrmtPort.Text);
            string Remark = this.txtRemark.Text;
            int displayType = int.Parse(this.txtdisplayType.Text);
            string area = this.txtarea.Text;
            bool IsDownloadPicture = this.chkIsDownloadPicture.Checked;
            int status = int.Parse(this.txtstatus.Text);

    
            model.r_id = r_id;
            model.r_name = r_name;
            model.picPath = picPath;
            model.IsCreatePicture = IsCreatePicture;
            model.r_width = r_width;
            model.eld_pictureWidth = eld_pictureWidth;
            model.eld_pictureHeight = eld_pictureHeight;
            model.eld_regionWidth = eld_regionWidth;
            model.eld_regionHeight = eld_regionHeight;
            model.eld_rmtHost = eld_rmtHost;
            model.IsConnectELD = IsConnectELD;
            model.locPort = locPort;
            model.rmtPort = rmtPort;
            model.Remark = Remark;
            model.displayType = displayType;
            model.area = area;
            model.IsDownloadPicture = IsDownloadPicture;
            model.status = status;

            DAMySql bll = new DAMySql();
            bll.AddRoad(model);
        }
    }
}