<%@ Page Language="C#" Inherits="ASP.NET1.FormPage" %>

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
            width: 50vh;
            flex-direction: column;
            padding: 0px 16px 0px 16px;
            border: dashed;
            border-width: 1px;
            border-radius: 8px;
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
            background-color: gray;
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
    </style>
</head>

<body class="container">
    <div class="inner-container">
        <h2>Registration Page</h2>

        <form id="form1" runat="server">
            <div class="form">

                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>

                <asp:TextBox ID="textName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>

                <asp:TextBox ID="textAddress" runat="server"></asp:TextBox>
                <br />

                <div>
                    <div class="list-view">
                        <asp:Label ID="lblAcademic"     runat="server" Text="Academic:"></asp:Label>
                        <asp:ListBox ID="academicListBox" runat="server"></asp:ListBox>
                        <br />
                    </div>
                </div>

                <div>
                    <asp:Label ID="GenderLbl" runat="server" Text="Gender:"></asp:Label>
                    <br />
                    <asp:RadioButton ID="radioMale" runat="server" Text="Male" GroupName="gender" />
                    <asp:RadioButton ID="radioFemale" runat="server" Text="Female" GroupName="gender" />
                    <br />
                    <br />
                </div>

                <div>
                    <asp:CheckBox ID="consentCheck" runat="server" />
                    <asp:Label ID="ConsentLbl" runat="server" Text="I agree to the terms and conditions."></asp:Label>
                    <br />
                    <br />
                </div>

                <asp:Button class="custom-button" ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />

                <div ID="resultDiv" runat="server">
                    <br />
                    <hr />
                    <br />
                    <asp:Label ID="lblResult" runat="server" Style="display:flex; border: dashed; border-width: 1px; padding: 6px;" />
                    <br />
                </div>
            </div>

            <br />

        </form>
    </div>
</body>
</html>
