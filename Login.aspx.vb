
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim loginAccountStr As String = LoginPageAccount.Text
        Dim loginPassword As String = LoginPagePassword.Text

        'Dim checkLoginAll As Boolean = LoginAccountEmpty.IsValid And LoginPasswordEmpty.IsValid
        If Not (LoginAccountEmpty.IsValid And LoginPasswordEmpty.IsValid) Then
            Exit Sub
        End If

        Try
            Dim jptConn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection
            jptConn.ConnectionString = ConfigurationManager.ConnectionStrings("JustPhotoDBConnStr").ConnectionString.ToString()

            Dim jptCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand
            jptCommand.Connection = jptConn
            jptCommand.CommandType = Data.CommandType.StoredProcedure
            jptCommand.CommandText = "GETACCOUNT"
            jptCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@account", System.Data.SqlDbType.NVarChar, 15))
            jptCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 50))
            jptCommand.Parameters("@account").Value = loginAccountStr
            jptCommand.Parameters("@email").Value = loginAccountStr

            Dim jptDataReader As System.Data.SqlClient.SqlDataReader = Nothing

            Try
                jptConn.Open()
                jptDataReader = jptCommand.ExecuteReader

                Dim FoundAccount As Boolean = False

                While jptDataReader.Read()
                    Dim getID As String = jptDataReader(0)
                    Dim getAccount As String = jptDataReader(1)
                    Dim getEmail As String = jptDataReader(2)
                    Dim getPassword As String = jptDataReader(3)
                    Dim getHeadPic As String = jptDataReader(4)
                    Dim getName As String = jptDataReader(5)
                    Dim getDescription As String = jptDataReader(6)

                    'if find account or email
                    If (getAccount = loginAccountStr) Or (getEmail = loginAccountStr) Then
                        'if the password is correct
                        If (getPassword = loginPassword) Then
                            FoundAccount = True     'represent find account, if not then the account is not registed

                            'Response.Write("<Script language='JavaScript'>alert('登入成功');</Script>")

                            ' process login success 
                            Session("jpt_id") = getID
                            Session("jpt_memberAcc") = getAccount
                            Session("jpt_memberHeadPic") = getHeadPic
                            Session("jpt_memberName") = getName
                            Session("jpt_memberDescrip") = getDescription
                            Session("isLoginState") = "OK"
                            Response.Redirect("~/Home.aspx")

                            ' login success end
                            Exit While
                        End If
                    End If
                End While

                ' if not find account then represent the account is not regiseted
                If Not FoundAccount Then
                    LoginAccountNotFound.IsValid = False
                    LoginPagePassword.Text = ""
                End If
            Catch ex As Exception
                Response.Write("<Script language='JavaScript'>alert('" & ex.Message & "');</Script>")
            Finally
                If Not (jptDataReader Is Nothing) Then
                    jptCommand.Cancel()
                    jptDataReader.Close()
                End If

                If (jptConn.State = System.Data.ConnectionState.Open) Then
                    jptConn.Close()
                    jptConn.Dispose()
                End If
            End Try
        Catch ex As Exception
            Response.Write("<Script language='JavaScript'>alert('" & ex.Message & "');</Script>")
        End Try
    End Sub


End Class
