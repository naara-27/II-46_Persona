Namespace Utils

    Public Module SwalUtils
        Public Sub ShowSwalMessage(page As System.Web.UI.Page, title As String, message As String, icon As String)
            ScriptManager.RegisterStartupScript(page, page.GetType(), Guid.NewGuid().ToString(), ShowSwalScript(title, message, icon), True)
        End Sub

        Public Function ShowSwalScript(title As String, message As String, icon As String) As String
            Return $"swal.fire({{title: '{title}', text: '{message}', icon: {icon}'}});"
        End Function
    End Module
End Namespace