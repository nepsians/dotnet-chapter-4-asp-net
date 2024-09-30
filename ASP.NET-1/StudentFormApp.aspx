<%@ Page Language="C#" Inherits="ASP.NET1.StudentFormApp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }

        .container {
            width: 100%;
            max-width: 480px;
            margin: 20px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        form {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        label {
            font-weight: bold;
            color: #555;
        }

        input[type="text"], input[type="number"], input[type="email"], input[type="submit"] {
            padding: 10px;
            margin-top: 5px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }

        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        input[type="submit"]:hover {
            background-color: #45a049;
        }

        .error {
            color: red;
            font-size: 12px;
            margin-top: -10px;
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

        .delete-button {
            color: white;
            background-color: red;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
            border-radius: 3px;
        }

        .delete-button:hover {
            background-color: darkred;
        }

        @media (max-width: 600px) {
            .container {
                padding: 10px;
            }

            form {
                gap: 10px;
            }

            input[type="submit"] {
                padding: 8px;
            }

            th, td {
                padding: 8px;
            }
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>Student Registration Form</h2>
        <form id="form1" runat="server">
            <label for="txtName" >Name:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="Name is required." CssClass="error" />

            <label for="txtAge">Age:</label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge"
                ErrorMessage="Age is required." CssClass="error" />
            <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge"
                MinimumValue="5" MaximumValue="100" Type="Integer" ErrorMessage="Age must be between 5 and 100."
                CssClass="error" />
            

            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="Invalid email format."
                CssClass="error" />
                
            <label for="txtPhone">Phone Number:</label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

            <asp:CustomValidator ID="cvPhone" runat="server" ControlToValidate="txtPhone"
                ErrorMessage="Phone number must be exactly 10 digits." CssClass="error"
                OnServerValidate="cvPhone_ServerValidate" ValidateEmptyText="true"/>
                
            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />

            <asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="Red" />

            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvStudents_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>
</html>
