Imports System.Web.Services.Description
Imports Persona.Utils
Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If txt_nombre.Text = "" Or txt_apellido.Text = "" Or txt_edad.Text = "" Then
            ShowSwalError(Me, "Se deben completar todos los campos")
            Return
        End If

        persona.Nombre = txt_nombre.Text
        persona.Apellido = txt_apellido.Text
        persona.Edad = txt_edad.Text

        If persona.Edad < 0 Then
            lbl_mensaje.Text = "La edad no puede ser negativa."
            lbl_mensaje.CssClass = "alert alert-danger"
            Return
        End If

        If dbHelper.create(persona) Then
            ShowSwal(Me, "Persona guardada correctamente.")
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
            ShowSwalError(Me, "Error al eliminar la persona: " & ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        e.Cancel = True
        Dim ID As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .ID = ID,
            .Nombre = e.NewValues("NOMBRE"),
            .Apellido = e.NewValues("APELLIDO"),
            .Edad = e.NewValues("EDAD")
        }
        Dim mensaje = dbHelper.update(persona)
        If mensaje.Contains("Error") Then
            ShowSwalError(Me, mensaje)
            Return
        Else
            ShowSwal(Me, mensaje)
        End If
        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
        btnGuardar.Visible = True

    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim idpersona As Integer
        Integer.TryParse(gvPersonas.SelectedDataKey.Value.ToString(), idpersona)
        Dim persona As Persona = New Persona()

        txt_nombre.Text = row.Cells(3).Text
        txt_apellido.Text = row.Cells(4).Text
        txt_edad.Text = row.Cells(5).Text

        Editanto.Value = idpersona

        btnActualizar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = True

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        Dim persona As Persona = New Persona With {
            .ID = Editanto.Value(),
            .Nombre = txt_nombre.Text(),
            .Apellido = txt_apellido.Text(),
            .Edad = txt_edad.Text()
        }
        Dim mensaje = dbHelper.update(persona)
        If mensaje.Contains("Error") Then
            ShowSwalError(Me, mensaje)
            Return
        Else
            ShowSwal(Me, mensaje)
        End If
        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
        btnGuardar.Visible = True

        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1

        LimpiarCampos()
    End Sub

    Protected Sub LimpiarCampos()
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = False
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_edad.Text = ""
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
    End Sub
End Class