<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebELDMySqlRoad.aspx.cs" Inherits="ELDWebService_v2._0.WebELDMySql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td colspan="2" >
                        road表
                    </td>
                 
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">r_id
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtr_id" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">r_name
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtr_name" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">picPath
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtpicPath" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">IsCreatePicture
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:CheckBox ID="chkIsCreatePicture" Text="IsCreatePicture" runat="server" Checked="False" />
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">r_width
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtr_width" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">eld_pictureWidth
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txteld_pictureWidth" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">eld_pictureHeight
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txteld_pictureHeight" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">eld_regionWidth
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txteld_regionWidth" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">eld_regionHeight
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txteld_regionHeight" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">eld_rmtHost
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txteld_rmtHost" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">IsConnectELD
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:CheckBox ID="chkIsConnectELD" Text="IsConnectELD" runat="server" Checked="False" />
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">locPort
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtlocPort" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">rmtPort
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtrmtPort" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">Remark
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">displayType
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtdisplayType" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">area
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtarea" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">IsDownloadPicture
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:CheckBox ID="chkIsDownloadPicture" Text="IsDownloadPicture" runat="server" Checked="False" />
                    </td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">status
	：</td>
                    <td height="25" width="*" align="left">
                        <asp:TextBox ID="txtstatus" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
              <tr>
                  <td colspan="2">
                        1122
                  </td>
              </tr>
             </table>
            <asp:Button runat="server"  ID="but_add" Text="添加" Width="200px"  height="25" OnClick="but_add_Click" />
        </div>
    </form>
</body>
</html>
