Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        persona.Nombre = txt_nombre.Text
        persona.Apellido = txt_apellido.Text
        persona.Edad = txt_edad.Text
        If dbHelper.create(persona) Then
            lbl_mensaje.Text = "Persona guardada correctamente."
            txt_nombre.Text = ""
            txt_apellido.Text = ""
            txt_edad.Text = ""
        Else
            lbl_mensaje.Text = "Error al guardar la persona."
        End If


        gvPersonas.DataBind()
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

        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim ID As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()

        txt_nombre.Text = row.Cells(3).Text
        txt_apellido.Text = row.Cells(4).Text
        txt_edad.Text = row.Cells(5).Text
        Editanto.Value = ID
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        Dim persona As Persona = New Persona With {
            .ID = Editanto.Value(),
            .Nombre = txt_nombre.Text(),
            .Apellido = txt_apellido.Text(),
            .Edad = txt_edad.Text()
        }
        dbHelper.update(persona)
        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
    End Sub
End Class