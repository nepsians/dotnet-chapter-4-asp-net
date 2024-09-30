<%@ Page Language="C#" Inherits="ASP.NET1.ListStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

    <style>
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }

        .inner-container {
            display: flex;
            flex-direction: column;
            padding: 0px 16px 0px 16px;
            border: dashed;
            border-width: 1px;
            border-radius: 8px;
            margin: 8px;
            width: 80vh;
        }

        .form {
            display: flex;
            flex-direction: column;
            justify-content: flex-end;
        }

        .list-view {
            display: flex;
            flex-direction: column;
            width: 60px;
        }

        /* Styles for the button */
        .custom-button {
            display: inline-block;
            padding: 8px 14px;
            background-color: #4CAF50;
            color: white;
            text-align: center;
            text-decoration: none;
            font-size: 14px;
            border-radius: 5px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

            /* Hover effect */
            .custom-button:hover {
                background-color: #45a049; /* Darker green */
            }
            
            table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #f4f4f4;
        }
    </style>
</head>

<body class="container">
    <form id="form1" runat="server">


        <div style="display: flex;">

           

            <div style="display: flex;">
                <div class="inner-container">
                    <h2>All student information</h2>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Student Id" ItemStyle-Width="100" />
                            <asp:BoundField DataField="reg_id" HeaderText="Student Reg Id" ItemStyle-Width="150" />
                            <asp:BoundField DataField="name" HeaderText="Name" ItemStyle-Width="150" />
                            <asp:BoundField DataField="marks" HeaderText="Marks" ItemStyle-Width="150" />
                            <asp:BoundField DataField="address" HeaderText="Address" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>

                    <asp:Button class="custom-button" ID="Button2" runat="server" Text="View Data" OnClick="submitButton_Click1"  style="margin:18px 0px 18px 0px;"/>

                </div>
            </div>
        </div>
    </form>

</body>
</html>
