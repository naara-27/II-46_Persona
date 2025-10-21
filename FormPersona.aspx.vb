Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Persona.Nombre = txt_nombre.Text
        Persona.Apellido = txt_apellido.Text
        Persona.Edad = txt_edad.Text
        lbl_mensaje.Text = dbHelper.create(persona)
    End Sub

    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim ID As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(ID)
            e.Cancel = True
            gvPersonas.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try
    End Sub
End Class