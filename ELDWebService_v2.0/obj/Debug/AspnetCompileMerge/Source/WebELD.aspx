<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebELD.aspx.cs" Inherits="ELDWebService_v2._0.WebELD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="border: solid 1px red;">
                <tr>
                    <td colspan="2" align="center">分区写入信息（只含静态信息）
                    </td>
                </tr>
                  <tr>
                    <td>IP
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_ip" TextMode="MultiLine" Text="192.168.0.102" Height="60" Width="600"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>region1
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_region1" TextMode="MultiLine" Text="123" Height="60" Width="600"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>region2
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_region2" TextMode="MultiLine" Text="456" Height="60" Width="600"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="but_fenpingAndWrite" Text="分区和写屏（整屏写入）" OnClick="but_fenpingAndWrite_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <table style="border: solid 1px red;">
                <tr>
                    <td colspan="2" align="center">分区写入信息（含动态态信息）</td>
                </tr>
                <tr>
                    <td>region1
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt2_r1_1" Text="aaaa"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txt2_r1_2" Text="bbbb"></asp:TextBox>
                    </td>
                    <td>间隔时间：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_next_time1" Text="10"></asp:TextBox>秒/次
                    </td>
                </tr>
                <tr>
                    <td>region2
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt2_r2_1" Text="cccc"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txt2_r2_2" Text="dddd"></asp:TextBox>
                    </td>
                    <td>间隔时间：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_next_time2" Text="10"></asp:TextBox>秒/次
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="but2_fenping2" Text="发布信息含轮流播放" OnClick="but2_fenping2_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <%--      <asp:FileUpload runat="server"  ID="file1"/>--%>
            <label>图片名称：</label><asp:TextBox runat="server" ID="txt_imgName" Text="op.bmp"></asp:TextBox>
            <asp:Button runat="server" ID="but_uploadFile" Text="上传文件SqlServerDB" OnClick="but_uploadFile_Click" />
            <asp:Button runat="server" ID="but_createLukuang" Text="生成路况SqlServerDB" OnClick="but_createLukuang_Click" />
            <asp:Button runat="server" ID="but_sendimg" Text="发送图片SqlServerDB" OnClick="but_sendimg_Click" />
            <asp:Button runat="server" ID="but_sendimgII" Text="发送图片IISqlServerDB" OnClick="but_sendimgII_Click" />
            <hr />
            <div id="mysql_div">
                <label>字体大小：</label><asp:TextBox runat="server" ID="txt_fontsize" Text="10"></asp:TextBox>
                <asp:Button runat="server" ID="but_uploadFileMySql" Text="上传文件MySqlDB" OnClick="but_uploadFileMySql_Click" />
                <asp:Button runat="server" ID="but_createLukuangMySqlDB" Text="生成路况MySqlDB" OnClick="but_createLukuangMySqlDB_Click" />
                <asp:Button runat="server" ID="but_sendimgMySqlDB" Text="发送图片MySqlDB" OnClick="but_sendimgMySqlDB_Click" />
                   <asp:Button runat="server" ID="but_sendimgIIMySqlDB" Text="发送图片IIMySqlDB" OnClick="but_sendimgIIMySqlDB_Click" />
            </div>
        </div>
    </form>
</body>
</html>
