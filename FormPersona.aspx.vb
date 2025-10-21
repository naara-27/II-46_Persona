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

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim ID As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .ID = ID,
            .Nombre = e.NewValues("NOMBRE"),
            .Apellido = e.NewValues("APELLIDO"),
            .Edad = e.NewValues("EDAD")
        }
        dbHelper.update(persona)
        gvPersonas.DataBind()
        e.Cancel = True
        gvPersonas.EditIndex = -1

    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ID As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.Equals(ID)))
        Dim persona As Persona = New Persona()
    End Sub
End Class