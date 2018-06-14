<%@ Page Title="Team And Condition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teamandcondition.aspx.cs" Inherits="Website.teamandcondition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-info" style="padding-left: 10px; margin-top: 10px">Team And Condition</h2>
    <hr />
    <div class="container">
        <div class="text" style="text-align: justify; color: black;">
            1. Students are requested to apply for the books if and only if you are NEEDY. 
        <br />
            <br />
            2. Student will have to re-apply for the books if he / she fails.
        <br />
            <br />
            3. You have to attach the xerox copy of mark sheet of the previous class.
        <br />
            <br />

            4. Books have to be returned Within Seven Days of the last exam.
        <br />
            <br />

            5. You wil have to reimburse the full cost of a book/books in case you loose them or damage them.
        <br />
            <br />
            6. You pledge to help others when you will start earning.
            <br />
            <br />
            7. You assure that you will bind the books as soon you take it from us. No Returns will be accepted if the books are not binded.
                <p>
                    <input type="checkbox" required name="terms">
                    I accept the <u>Terms and Conditions</u>
                </p>
            <br />
            <asp:Button ID="btnaccept" runat="server" Text="Accept" class=" col-md-2 font-weight-bold bg-success" OnClick="btnaccept_Click" TabIndex="0" />
        </div>
    </div>
</asp:Content>
